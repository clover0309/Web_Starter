namespace Web_Starter
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Log_View = new System.Windows.Forms.Button();
            this.Server_StatusLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Server_Starting = new System.Windows.Forms.Button();
            this.btnServerStop = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // Server_Starting
            //
            this.Server_Starting.Location = new System.Drawing.Point(35, 12);
            this.Server_Starting.Name = "Server_Starting";
            this.Server_Starting.Size = new System.Drawing.Size(112, 62);
            this.Server_Starting.TabIndex = 0;
            this.Server_Starting.Text = "서버 구동";
            this.Server_Starting.UseVisualStyleBackColor = true;
            this.Server_Starting.Click += new System.EventHandler(this.button1_Click_1);
            //
            // btnServerStop
            //
            this.btnServerStop.Enabled = false;
            this.btnServerStop.Location = new System.Drawing.Point(35, 80);
            this.btnServerStop.Name = "btnServerStop";
            this.btnServerStop.Size = new System.Drawing.Size(112, 50);
            this.btnServerStop.TabIndex = 1;
            this.btnServerStop.Text = "서버 중지";
            this.btnServerStop.UseVisualStyleBackColor = true;
            this.btnServerStop.Click += new System.EventHandler(this.btnServerStop_Click);
            //
            // Log_View
            //
            this.Log_View.Location = new System.Drawing.Point(35, 136);
            this.Log_View.Name = "Log_View";
            this.Log_View.Size = new System.Drawing.Size(112, 50);
            this.Log_View.TabIndex = 2;
            this.Log_View.Text = "로그 보기";
            this.Log_View.UseVisualStyleBackColor = true;
            this.Log_View.Click += new System.EventHandler(this.button1_Click);
            //
            // btnSettings
            //
            this.btnSettings.Location = new System.Drawing.Point(35, 192);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(112, 50);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "설정";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            //
            // Server_StatusLabel
            //
            this.Server_StatusLabel.AutoSize = true;
            this.Server_StatusLabel.Location = new System.Drawing.Point(15, 260);
            this.Server_StatusLabel.Name = "Server_StatusLabel";
            this.Server_StatusLabel.Size = new System.Drawing.Size(67, 15);
            this.Server_StatusLabel.TabIndex = 4;
            this.Server_StatusLabel.Text = "서버상태";
            //
            // textBox1
            //
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(88, 257);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(92, 25);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "대기중..";
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 295);
            this.Controls.Add(this.Server_Starting);
            this.Controls.Add(this.btnServerStop);
            this.Controls.Add(this.Log_View);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Server_StatusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Web Starter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Server_Starting;
        private System.Windows.Forms.Button btnServerStop;
        private System.Windows.Forms.Button Log_View;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label Server_StatusLabel;
        private System.Windows.Forms.TextBox textBox1;
    }
}
