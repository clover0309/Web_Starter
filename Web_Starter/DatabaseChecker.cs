using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Npgsql;

namespace Web_Starter
{
    public enum DbStatus
    {
        Ready,
        NoDatabaseExists,
        TablesCreated,
        DataSeeded,
        DataSeedFailed,
        Error
    }

    public class DbCheckResult
    {
        public DbStatus Status { get; set; }
        public string Message { get; set; }
    }

    public class DatabaseChecker
    {
        private const int MinimumRowsPerTable = 1;

        private string GetConnectionString()
        {
            return AppSettings.Instance.ConnectionString;
        }

        private string GetPostgresConnectionString()
        {
            return AppSettings.Instance.PostgresConnectionString;
        }

        public bool CheckDatabaseExists()
        {
            using (var conn = new NpgsqlConnection(GetPostgresConnectionString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(
                    "SELECT 1 FROM pg_database WHERE datname = @db", conn))
                {
                    cmd.Parameters.AddWithValue("@db", AppSettings.Instance.DbName);
                    var result = cmd.ExecuteScalar();
                    return result != null;
                }
            }
        }

        public bool CheckTablesExist()
        {
            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(
                    "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'public'", conn))
                {
                    var count = Convert.ToInt64(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public bool CheckDataSufficiency()
        {
            using (var conn = new NpgsqlConnection(GetConnectionString()))
            {
                conn.Open();

                var tables = new List<string>();
                using (var cmd = new NpgsqlCommand(
                    "SELECT table_name FROM information_schema.tables WHERE table_schema = 'public'", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            tables.Add(reader.GetString(0));
                    }
                }

                if (tables.Count == 0)
                    return false;

                foreach (var table in tables)
                {
                    using (var cmd = new NpgsqlCommand(
                        string.Format("SELECT COUNT(*) FROM \"{0}\"",
                            table.Replace("\"", "\"\"")), conn))
                    {
                        var count = Convert.ToInt64(cmd.ExecuteScalar());
                        if (count < MinimumRowsPerTable)
                            return false;
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// bootstrap/farmos_seed.py --mode ensure --skip-sync 실행
        /// </summary>
        private RunResult RunBootstrapSeed(string projectRoot, string scriptName)
        {
            string bootstrapDir = Path.Combine(projectRoot, "bootstrap");
            string scriptPath = Path.Combine(bootstrapDir, scriptName);

            if (!File.Exists(scriptPath))
                return new RunResult { Success = false, Output = $"스크립트 미존재: {scriptPath}" };

            // 실행 디렉토리 결정
            string workDir;
            if (scriptName.StartsWith("shoppingmall"))
                workDir = Path.Combine(projectRoot, "shopping_mall", "backend");
            else
                workDir = Path.Combine(projectRoot, "backend");

            try
            {
                // seed_ai_agent.py는 --mode 옵션 없이 단순 실행 (멱등)
                string args = scriptName.StartsWith("seed_")
                    ? $"run python \"{scriptPath}\""
                    : $"run python \"{scriptPath}\" --mode ensure --skip-sync";

                var psi = new ProcessStartInfo
                {
                    FileName = "uv",
                    Arguments = args,
                    WorkingDirectory = workDir,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    StandardOutputEncoding = Encoding.UTF8,
                    StandardErrorEncoding = Encoding.UTF8
                };
                psi.EnvironmentVariables["PYTHONIOENCODING"] = "utf-8";

                var output = new StringBuilder();
                using (var process = Process.Start(psi))
                {
                    process.OutputDataReceived += (s, e) => { if (e.Data != null) output.AppendLine(e.Data); };
                    process.ErrorDataReceived += (s, e) => { if (e.Data != null) output.AppendLine(e.Data); };
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    process.WaitForExit(120000); // 2분 타임아웃

                    return new RunResult
                    {
                        Success = process.ExitCode == 0,
                        Output = output.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                return new RunResult { Success = false, Output = ex.Message };
            }
        }

        public DbCheckResult CheckAndPrepare(string projectRoot)
        {
            try
            {
                // Step 1: DB 존재 확인
                if (!CheckDatabaseExists())
                {
                    return new DbCheckResult
                    {
                        Status = DbStatus.NoDatabaseExists,
                        Message = $"PostgreSQL에 '{AppSettings.Instance.DbName}' 데이터베이스가 존재하지 않습니다."
                    };
                }

                // Step 2: 테이블/데이터 확인 → bootstrap seed 실행
                bool tablesExist = CheckTablesExist();
                bool dataOk = tablesExist && CheckDataSufficiency();

                if (dataOk)
                {
                    return new DbCheckResult
                    {
                        Status = DbStatus.Ready,
                        Message = "데이터베이스 준비 완료."
                    };
                }

                // 테이블이 없거나 데이터가 부족하면 bootstrap seed 실행
                var farmosResult = RunBootstrapSeed(projectRoot, "farmos_seed.py");
                var shopResult = RunBootstrapSeed(projectRoot, "shoppingmall_seed.py");
                var aiAgentResult = RunBootstrapSeed(projectRoot, "seed_ai_agent.py");

                if (farmosResult.Success && shopResult.Success && aiAgentResult.Success)
                {
                    return new DbCheckResult
                    {
                        Status = tablesExist ? DbStatus.DataSeeded : DbStatus.TablesCreated,
                        Message = tablesExist
                            ? "데이터 시딩이 완료되었습니다."
                            : "테이블 생성 및 데이터 시딩이 완료되었습니다."
                    };
                }

                // 일부 실패해도 서버 구동은 계속 진행
                var failedParts = new List<string>();
                if (!farmosResult.Success) failedParts.Add("FarmOS");
                if (!shopResult.Success) failedParts.Add("ShoppingMall");
                if (!aiAgentResult.Success) failedParts.Add("AI Agent");

                return new DbCheckResult
                {
                    Status = DbStatus.DataSeedFailed,
                    Message = $"{string.Join(", ", failedParts)} 시딩에 실패했습니다.\n서버는 정상 구동됩니다.\n\n" +
                              (!farmosResult.Success ? $"[FarmOS]\n{farmosResult.Output}\n" : "") +
                              (!shopResult.Success ? $"[ShoppingMall]\n{shopResult.Output}\n" : "") +
                              (!aiAgentResult.Success ? $"[AI Agent]\n{aiAgentResult.Output}" : "")
                };
            }
            catch (Exception ex)
            {
                return new DbCheckResult
                {
                    Status = DbStatus.Error,
                    Message = $"데이터베이스 확인 중 오류: {ex.Message}"
                };
            }
        }

        private class RunResult
        {
            public bool Success { get; set; }
            public string Output { get; set; }
        }
    }
}
