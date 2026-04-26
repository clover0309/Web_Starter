namespace Web_Starter
{
    partial class LogForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabFarmosBE = new System.Windows.Forms.TabPage();
            this.rtbFarmosBE = new System.Windows.Forms.RichTextBox();
            this.lblFarmosBE = new System.Windows.Forms.Label();
            this.tabShopBE = new System.Windows.Forms.TabPage();
            this.rtbShopBE = new System.Windows.Forms.RichTextBox();
            this.lblShopBE = new System.Windows.Forms.Label();
            this.tabFarmosFE = new System.Windows.Forms.TabPage();
            this.rtbFarmosFE = new System.Windows.Forms.RichTextBox();
            this.lblFarmosFE = new System.Windows.Forms.Label();
            this.tabShopFE = new System.Windows.Forms.TabPage();
            this.rtbShopFE = new System.Windows.Forms.RichTextBox();
            this.lblShopFE = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabFarmosBE.SuspendLayout();
            this.tabShopBE.SuspendLayout();
            this.tabFarmosFE.SuspendLayout();
            this.tabShopFE.SuspendLayout();
            this.SuspendLayout();
            //
            // tabControl1
            //
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabFarmosBE);
            this.tabControl1.Controls.Add(this.tabShopBE);
            this.tabControl1.Controls.Add(this.tabFarmosFE);
            this.tabControl1.Controls.Add(this.tabShopFE);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 450);
            this.tabControl1.TabIndex = 0;
            //
            // tabFarmosBE
            //
            this.tabFarmosBE.Controls.Add(this.rtbFarmosBE);
            this.tabFarmosBE.Controls.Add(this.lblFarmosBE);
            this.tabFarmosBE.Location = new System.Drawing.Point(4, 25);
            this.tabFarmosBE.Name = "tabFarmosBE";
            this.tabFarmosBE.Padding = new System.Windows.Forms.Padding(3);
            this.tabFarmosBE.Size = new System.Drawing.Size(752, 421);
            this.tabFarmosBE.TabIndex = 0;
            this.tabFarmosBE.Text = "FarmOS Backend (:8000)";
            this.tabFarmosBE.UseVisualStyleBackColor = true;
            //
            // lblFarmosBE
            //
            this.lblFarmosBE.AutoSize = true;
            this.lblFarmosBE.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFarmosBE.Location = new System.Drawing.Point(3, 3);
            this.lblFarmosBE.Name = "lblFarmosBE";
            this.lblFarmosBE.Padding = new System.Windows.Forms.Padding(0, 3, 0, 5);
            this.lblFarmosBE.Size = new System.Drawing.Size(40, 23);
            this.lblFarmosBE.TabIndex = 0;
            this.lblFarmosBE.Text = "PID: ";
            //
            // rtbFarmosBE
            //
            this.rtbFarmosBE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rtbFarmosBE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbFarmosBE.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbFarmosBE.ForeColor = System.Drawing.Color.LightGreen;
            this.rtbFarmosBE.Location = new System.Drawing.Point(3, 23);
            this.rtbFarmosBE.Name = "rtbFarmosBE";
            this.rtbFarmosBE.ReadOnly = true;
            this.rtbFarmosBE.Size = new System.Drawing.Size(746, 395);
            this.rtbFarmosBE.TabIndex = 1;
            this.rtbFarmosBE.Text = "";
            //
            // tabShopBE
            //
            this.tabShopBE.Controls.Add(this.rtbShopBE);
            this.tabShopBE.Controls.Add(this.lblShopBE);
            this.tabShopBE.Location = new System.Drawing.Point(4, 25);
            this.tabShopBE.Name = "tabShopBE";
            this.tabShopBE.Padding = new System.Windows.Forms.Padding(3);
            this.tabShopBE.Size = new System.Drawing.Size(752, 421);
            this.tabShopBE.TabIndex = 1;
            this.tabShopBE.Text = "Shop Backend (:4000)";
            this.tabShopBE.UseVisualStyleBackColor = true;
            //
            // lblShopBE
            //
            this.lblShopBE.AutoSize = true;
            this.lblShopBE.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblShopBE.Location = new System.Drawing.Point(3, 3);
            this.lblShopBE.Name = "lblShopBE";
            this.lblShopBE.Padding = new System.Windows.Forms.Padding(0, 3, 0, 5);
            this.lblShopBE.Size = new System.Drawing.Size(40, 23);
            this.lblShopBE.TabIndex = 0;
            this.lblShopBE.Text = "PID: ";
            //
            // rtbShopBE
            //
            this.rtbShopBE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rtbShopBE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbShopBE.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbShopBE.ForeColor = System.Drawing.Color.LightGreen;
            this.rtbShopBE.Location = new System.Drawing.Point(3, 23);
            this.rtbShopBE.Name = "rtbShopBE";
            this.rtbShopBE.ReadOnly = true;
            this.rtbShopBE.Size = new System.Drawing.Size(746, 395);
            this.rtbShopBE.TabIndex = 1;
            this.rtbShopBE.Text = "";
            //
            // tabFarmosFE
            //
            this.tabFarmosFE.Controls.Add(this.rtbFarmosFE);
            this.tabFarmosFE.Controls.Add(this.lblFarmosFE);
            this.tabFarmosFE.Location = new System.Drawing.Point(4, 25);
            this.tabFarmosFE.Name = "tabFarmosFE";
            this.tabFarmosFE.Padding = new System.Windows.Forms.Padding(3);
            this.tabFarmosFE.Size = new System.Drawing.Size(752, 421);
            this.tabFarmosFE.TabIndex = 2;
            this.tabFarmosFE.Text = "FarmOS Frontend (:5173)";
            this.tabFarmosFE.UseVisualStyleBackColor = true;
            //
            // lblFarmosFE
            //
            this.lblFarmosFE.AutoSize = true;
            this.lblFarmosFE.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFarmosFE.Location = new System.Drawing.Point(3, 3);
            this.lblFarmosFE.Name = "lblFarmosFE";
            this.lblFarmosFE.Padding = new System.Windows.Forms.Padding(0, 3, 0, 5);
            this.lblFarmosFE.Size = new System.Drawing.Size(40, 23);
            this.lblFarmosFE.TabIndex = 0;
            this.lblFarmosFE.Text = "PID: ";
            //
            // rtbFarmosFE
            //
            this.rtbFarmosFE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rtbFarmosFE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbFarmosFE.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbFarmosFE.ForeColor = System.Drawing.Color.LightGreen;
            this.rtbFarmosFE.Location = new System.Drawing.Point(3, 23);
            this.rtbFarmosFE.Name = "rtbFarmosFE";
            this.rtbFarmosFE.ReadOnly = true;
            this.rtbFarmosFE.Size = new System.Drawing.Size(746, 395);
            this.rtbFarmosFE.TabIndex = 1;
            this.rtbFarmosFE.Text = "";
            //
            // tabShopFE
            //
            this.tabShopFE.Controls.Add(this.rtbShopFE);
            this.tabShopFE.Controls.Add(this.lblShopFE);
            this.tabShopFE.Location = new System.Drawing.Point(4, 25);
            this.tabShopFE.Name = "tabShopFE";
            this.tabShopFE.Padding = new System.Windows.Forms.Padding(3);
            this.tabShopFE.Size = new System.Drawing.Size(752, 421);
            this.tabShopFE.TabIndex = 3;
            this.tabShopFE.Text = "Shop Frontend (:5174)";
            this.tabShopFE.UseVisualStyleBackColor = true;
            //
            // lblShopFE
            //
            this.lblShopFE.AutoSize = true;
            this.lblShopFE.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblShopFE.Location = new System.Drawing.Point(3, 3);
            this.lblShopFE.Name = "lblShopFE";
            this.lblShopFE.Padding = new System.Windows.Forms.Padding(0, 3, 0, 5);
            this.lblShopFE.Size = new System.Drawing.Size(40, 23);
            this.lblShopFE.TabIndex = 0;
            this.lblShopFE.Text = "PID: ";
            //
            // rtbShopFE
            //
            this.rtbShopFE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rtbShopFE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbShopFE.Font = new System.Drawing.Font("Consolas", 9F);
            this.rtbShopFE.ForeColor = System.Drawing.Color.LightGreen;
            this.rtbShopFE.Location = new System.Drawing.Point(3, 23);
            this.rtbShopFE.Name = "rtbShopFE";
            this.rtbShopFE.ReadOnly = true;
            this.rtbShopFE.Size = new System.Drawing.Size(746, 395);
            this.rtbShopFE.TabIndex = 1;
            this.rtbShopFE.Text = "";
            //
            // btnClearLog
            //
            this.btnClearLog.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClearLog.Location = new System.Drawing.Point(340, 470);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(100, 30);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "로그 지우기";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            //
            // LogForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "LogForm";
            this.Text = "서버 로그 뷰어 - FarmOS";
            this.Load += new System.EventHandler(this.LogForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabFarmosBE.ResumeLayout(false);
            this.tabFarmosBE.PerformLayout();
            this.tabShopBE.ResumeLayout(false);
            this.tabShopBE.PerformLayout();
            this.tabFarmosFE.ResumeLayout(false);
            this.tabFarmosFE.PerformLayout();
            this.tabShopFE.ResumeLayout(false);
            this.tabShopFE.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFarmosBE;
        private System.Windows.Forms.TabPage tabShopBE;
        private System.Windows.Forms.TabPage tabFarmosFE;
        private System.Windows.Forms.TabPage tabShopFE;
        private System.Windows.Forms.Label lblFarmosBE;
        private System.Windows.Forms.Label lblShopBE;
        private System.Windows.Forms.Label lblFarmosFE;
        private System.Windows.Forms.Label lblShopFE;
        private System.Windows.Forms.RichTextBox rtbFarmosBE;
        private System.Windows.Forms.RichTextBox rtbShopBE;
        private System.Windows.Forms.RichTextBox rtbFarmosFE;
        private System.Windows.Forms.RichTextBox rtbShopFE;
        private System.Windows.Forms.Button btnClearLog;
    }
}
