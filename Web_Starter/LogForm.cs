using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Web_Starter
{
    public partial class LogForm : Form
    {
        private readonly ServerManager serverManager;
        private readonly List<Action<string>> logHandlers = new List<Action<string>>();

        public LogForm(ServerManager serverManager)
        {
            InitializeComponent();
            this.serverManager = serverManager;
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            // RichTextBox와 서비스를 순서대로 매핑
            var rtbList = new[] { rtbFarmosBE, rtbShopBE, rtbFarmosFE, rtbShopFE };
            var lblList = new[] { lblFarmosBE, lblShopBE, lblFarmosFE, lblShopFE };

            for (int i = 0; i < serverManager.Services.Count && i < rtbList.Length; i++)
            {
                var svc = serverManager.Services[i];
                var rtb = rtbList[i];
                var lbl = lblList[i];

                // PID 표시
                lbl.Text = $"PID: {svc.Pid} | Port: {svc.Port}";

                // 버퍼된 로그를 먼저 표시 (시작 시점부터의 모든 로그)
                string buffered = svc.LogBuffer.ToString();
                if (!string.IsNullOrEmpty(buffered))
                {
                    rtb.Text = buffered;
                    rtb.SelectionStart = rtb.TextLength;
                    rtb.ScrollToCaret();
                }

                // 실시간 로그 구독
                var capturedRtb = rtb;
                Action<string> handler = (message) => AppendLog(capturedRtb, message);
                logHandlers.Add(handler);
                svc.OnLog += handler;
            }
        }

        private void AppendLog(RichTextBox rtb, string text)
        {
            if (text == null) return;

            if (rtb.InvokeRequired)
            {
                try
                {
                    rtb.Invoke(new Action(() => AppendLog(rtb, text)));
                }
                catch (ObjectDisposedException) { }
                return;
            }

            rtb.AppendText(text + Environment.NewLine);
            rtb.SelectionStart = rtb.TextLength;
            rtb.ScrollToCaret();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            rtbFarmosBE.Clear();
            rtbShopBE.Clear();
            rtbFarmosFE.Clear();
            rtbShopFE.Clear();
        }

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 이벤트 구독 해제
            var rtbList = new[] { rtbFarmosBE, rtbShopBE, rtbFarmosFE, rtbShopFE };

            for (int i = 0; i < serverManager.Services.Count && i < logHandlers.Count; i++)
            {
                serverManager.Services[i].OnLog -= logHandlers[i];
            }
            logHandlers.Clear();
        }
    }
}
