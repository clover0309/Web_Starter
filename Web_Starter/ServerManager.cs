using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Web_Starter
{
    public class ServiceInfo
    {
        public string Name { get; set; }
        public string Dir { get; set; }
        public string Command { get; set; }
        public string Args { get; set; }
        public int Port { get; set; }
        public Process Process { get; set; }
        public int Pid { get; set; }
        public StringBuilder LogBuffer { get; set; } = new StringBuilder();
        public event Action<string> OnLog;

        public void RaiseLog(string message)
        {
            if (message == null) return;
            LogBuffer.AppendLine(message);
            OnLog?.Invoke(message);
        }

        public bool IsAlive
        {
            get
            {
                try { return Process != null && !Process.HasExited; }
                catch { return false; }
            }
        }
    }

    public class ServerManager
    {
        private string _projectRoot;
        public List<ServiceInfo> Services { get; private set; } = new List<ServiceInfo>();

        public bool IsRunning
        {
            get
            {
                foreach (var svc in Services)
                    if (!svc.IsAlive) return false;
                return Services.Count > 0;
            }
        }

        public string ProjectRoot
        {
            get
            {
                if (_projectRoot == null)
                    _projectRoot = ResolveProjectRoot();
                return _projectRoot;
            }
        }

        public void ResetSettings()
        {
            _projectRoot = null;
        }

        private string ResolveProjectRoot()
        {
            // 1. 설정에서 명시적 경로 확인
            string configured = AppSettings.Instance.ProjectRoot;
            if (!string.IsNullOrEmpty(configured) && Directory.Exists(configured))
                return Path.GetFullPath(configured);

            // 2. exe 기준 상위로 올라가며 start-all.bat 탐색
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            while (!string.IsNullOrEmpty(dir))
            {
                if (File.Exists(Path.Combine(dir, "start-all.bat")))
                    return dir;
                DirectoryInfo parent = Directory.GetParent(dir);
                if (parent == null) break;
                dir = parent.FullName;
            }

            return null;
        }

        public bool StartAll()
        {
            string root = ProjectRoot;
            if (string.IsNullOrEmpty(root))
                return false;

            // 로그 디렉토리 생성
            string logDir = Path.Combine(root, "logs");
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);

            // 4개 서비스 정의
            Services = new List<ServiceInfo>
            {
                new ServiceInfo
                {
                    Name = "FarmOS Backend",
                    Dir = Path.Combine(root, "backend"),
                    Command = "uv",
                    Args = "run main.py",
                    Port = 8000
                },
                new ServiceInfo
                {
                    Name = "Shop Backend",
                    Dir = Path.Combine(root, "shopping_mall", "backend"),
                    Command = "uv",
                    Args = "run main.py",
                    Port = 4000
                },
                new ServiceInfo
                {
                    Name = "FarmOS Frontend",
                    Dir = Path.Combine(root, "frontend"),
                    Command = "cmd.exe",
                    Args = "/c npm run dev",
                    Port = 5173
                },
                new ServiceInfo
                {
                    Name = "Shop Frontend",
                    Dir = Path.Combine(root, "shopping_mall", "frontend"),
                    Command = "cmd.exe",
                    Args = "/c npm run dev",
                    Port = 5174
                }
            };

            try
            {
                foreach (var svc in Services)
                {
                    if (!Directory.Exists(svc.Dir))
                    {
                        svc.RaiseLog($"[ERROR] Directory not found: {svc.Dir}");
                        continue;
                    }

                    var psi = new ProcessStartInfo
                    {
                        FileName = svc.Command,
                        Arguments = svc.Args,
                        WorkingDirectory = svc.Dir,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                        StandardOutputEncoding = Encoding.UTF8,
                        StandardErrorEncoding = Encoding.UTF8
                    };

                    // Python UTF-8 강제
                    psi.EnvironmentVariables["PYTHONIOENCODING"] = "utf-8";

                    svc.Process = new Process { StartInfo = psi };

                    svc.Process.OutputDataReceived += (sender, e) => svc.RaiseLog(e.Data);
                    svc.Process.ErrorDataReceived += (sender, e) => svc.RaiseLog(e.Data);

                    svc.Process.Start();
                    svc.Pid = svc.Process.Id;
                    svc.Process.BeginOutputReadLine();
                    svc.Process.BeginErrorReadLine();

                    svc.RaiseLog($"[{svc.Name}] Started (PID: {svc.Pid}, Port: {svc.Port})");
                }

                return true;
            }
            catch (Exception ex)
            {
                foreach (var svc in Services)
                    svc.RaiseLog($"[ERROR] Startup failed: {ex.Message}");
                StopAll();
                return false;
            }
        }

        public void StopAll()
        {
            foreach (var svc in Services)
            {
                KillProcessTree(svc.Pid);
                if (svc.Process != null)
                {
                    try { svc.Process.Dispose(); } catch { }
                    svc.Process = null;
                }
                svc.Pid = 0;
            }

            // 포트 기반 추가 정리
            foreach (var svc in Services)
            {
                KillByPort(svc.Port);
            }
        }

        private void KillProcessTree(int pid)
        {
            if (pid <= 0) return;
            try
            {
                var kill = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "taskkill",
                        Arguments = $"/F /T /PID {pid}",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    }
                };
                kill.Start();
                kill.WaitForExit(5000);
                kill.Dispose();
            }
            catch { }
        }

        private void KillByPort(int port)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c \"for /f \"tokens=5\" %a in ('netstat -ano ^| findstr :{port} ^| findstr LISTENING') do taskkill /PID %a /F /T\"",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                var p = Process.Start(psi);
                p.WaitForExit(5000);
                p.Dispose();
            }
            catch { }
        }
    }
}
