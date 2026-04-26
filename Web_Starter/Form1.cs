using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Starter
{
    public partial class Form1 : Form
    {
        private ServerManager serverManager;
        private bool isServerRunning = false;

        public Form1()
        {
            InitializeComponent();
            serverManager = new ServerManager();
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            Server_Starting.Enabled = !isServerRunning;
            btnServerStop.Enabled = isServerRunning;
            btnSettings.Enabled = !isServerRunning;
        }

        // 서버 구동 버튼
        private async void button1_Click_1(object sender, EventArgs e)
        {
            Server_Starting.Enabled = false;
            textBox1.ForeColor = SystemColors.ControlText;
            textBox1.Text = "구동 중..";

            try
            {
                // Step 1: 프로젝트 루트 확인
                string projectRoot = serverManager.ProjectRoot;
                if (string.IsNullOrEmpty(projectRoot))
                {
                    SetStatus(false, "경로 미발견!");
                    MessageBox.Show(
                        "FarmOS 프로젝트 경로를 찾을 수 없습니다.\n\n" +
                        "설정의 ProjectRoot 값을 확인해주세요.",
                        "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateButtonStates();
                    return;
                }

                // Step 2: 4개 서버 시작 (DB 검증은 각 서버/팀원이 담당)
                textBox1.Text = "서버 시작 중..";
                bool started = await Task.Run(() => serverManager.StartAll());

                if (started)
                {
                    isServerRunning = true;
                    SetStatus(true, "서버 가동 성공!");
                }
                else
                {
                    isServerRunning = false;
                    SetStatus(false, "서버 구동 실패!");
                }
            }
            catch (Exception ex)
            {
                isServerRunning = false;
                SetStatus(false, "서버 구동 실패!");
                MessageBox.Show("서버 구동 중 오류 발생:\n" + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UpdateButtonStates();
            }
        }

        // 서버 중지 버튼
        private async void btnServerStop_Click(object sender, EventArgs e)
        {
            btnServerStop.Enabled = false;
            textBox1.ForeColor = SystemColors.ControlText;
            textBox1.Text = "중지 중..";

            await Task.Run(() => serverManager.StopAll());

            isServerRunning = false;
            SetStatus(false, "서버 중지됨");
            textBox1.ForeColor = Color.Orange;
            UpdateButtonStates();
        }

        // 로그 보기 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            if (!isServerRunning)
            {
                MessageBox.Show("서버를 실행하여주세요!",
                    "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LogForm logForm = new LogForm(serverManager);
            logForm.Show();
        }

        // 설정 버튼
        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new SettingsForm())
            {
                if (settingsForm.ShowDialog(this) == DialogResult.OK)
                {
                    AppSettings.Reload();
                    serverManager.ResetSettings();
                }
            }
        }

        private void SetStatus(bool success, string message)
        {
            textBox1.Text = message;
            textBox1.ForeColor = success ? Color.Green : Color.Red;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (isServerRunning)
            {
                var result = MessageBox.Show(
                    "4개 서버가 실행 중입니다. 종료하시겠습니까?",
                    "확인",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                serverManager.StopAll();
            }

            base.OnFormClosing(e);
        }
    }
}
