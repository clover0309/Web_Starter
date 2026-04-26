using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Web_Starter
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            var settings = AppSettings.Instance;
            txtDbHost.Text = settings.DbHost;
            txtDbPort.Text = settings.DbPort.ToString();
            txtDbName.Text = settings.DbName;
            txtDbUsername.Text = settings.DbUsername;
            txtDbPassword.Text = settings.DbPassword;
            txtProjectRoot.Text = settings.ProjectRoot;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "FarmOS 프로젝트 폴더를 선택하세요";
                dialog.ShowNewFolderButton = false;

                if (!string.IsNullOrEmpty(txtProjectRoot.Text))
                    dialog.SelectedPath = txtProjectRoot.Text;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtProjectRoot.Text = dialog.SelectedPath;
                }
            }
        }

        private async void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDbHost.Text) ||
                string.IsNullOrWhiteSpace(txtDbPort.Text) ||
                string.IsNullOrWhiteSpace(txtDbUsername.Text))
            {
                lblTestResult.ForeColor = Color.Red;
                lblTestResult.Text = "입력값을 확인해주세요.";
                return;
            }

            btnTestConnection.Enabled = false;
            lblTestResult.ForeColor = Color.Gray;
            lblTestResult.Text = "연결 중...";

            string connStr = $"Host={txtDbHost.Text.Trim()};Port={txtDbPort.Text.Trim()};" +
                             $"Username={txtDbUsername.Text.Trim()};Password={txtDbPassword.Text};" +
                             $"Database=postgres;Timeout=5";

            string result = await Task.Run(() =>
            {
                try
                {
                    using (var conn = new NpgsqlConnection(connStr))
                    {
                        conn.Open();
                        return "OK";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            });

            if (result == "OK")
            {
                lblTestResult.ForeColor = Color.Green;
                lblTestResult.Text = "연결 성공!";
            }
            else
            {
                lblTestResult.ForeColor = Color.Red;
                lblTestResult.Text = "연결 실패";
                MessageBox.Show("DB 연결 실패:\n\n" + result,
                    "연결 테스트", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnTestConnection.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDbHost.Text) ||
                string.IsNullOrWhiteSpace(txtDbPort.Text) ||
                string.IsNullOrWhiteSpace(txtDbUsername.Text))
            {
                MessageBox.Show("DB Host, Port, Username은 필수 입력값입니다.",
                    "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtProjectRoot.Text))
            {
                MessageBox.Show("프로젝트 경로를 입력해주세요.",
                    "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var settings = AppSettings.Instance;
                settings.DbHost = txtDbHost.Text.Trim();
                settings.DbPort = int.Parse(txtDbPort.Text.Trim());
                settings.DbName = txtDbName.Text.Trim();
                settings.DbUsername = txtDbUsername.Text.Trim();
                settings.DbPassword = txtDbPassword.Text;
                settings.ProjectRoot = txtProjectRoot.Text.Trim();

                settings.Save();

                MessageBox.Show("설정이 저장되었습니다.",
                    "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("설정 저장 중 오류가 발생했습니다.\n\n" + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
