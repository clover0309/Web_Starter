namespace Web_Starter
{
    partial class SettingsForm
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
            this.grpDatabase = new System.Windows.Forms.GroupBox();
            this.txtDbPassword = new System.Windows.Forms.TextBox();
            this.txtDbUsername = new System.Windows.Forms.TextBox();
            this.txtDbPort = new System.Windows.Forms.TextBox();
            this.txtDbHost = new System.Windows.Forms.TextBox();
            this.txtDbName = new System.Windows.Forms.TextBox();
            this.lblDbPassword = new System.Windows.Forms.Label();
            this.lblDbUsername = new System.Windows.Forms.Label();
            this.lblDbPort = new System.Windows.Forms.Label();
            this.lblDbHost = new System.Windows.Forms.Label();
            this.lblDbName = new System.Windows.Forms.Label();
            this.grpProject = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtProjectRoot = new System.Windows.Forms.TextBox();
            this.lblProjectRoot = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpDatabase.SuspendLayout();
            this.grpProject.SuspendLayout();
            this.SuspendLayout();
            //
            // grpDatabase
            //
            this.grpDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDatabase.Controls.Add(this.lblDbName);
            this.grpDatabase.Controls.Add(this.txtDbName);
            this.grpDatabase.Controls.Add(this.lblDbHost);
            this.grpDatabase.Controls.Add(this.txtDbHost);
            this.grpDatabase.Controls.Add(this.lblDbPort);
            this.grpDatabase.Controls.Add(this.txtDbPort);
            this.grpDatabase.Controls.Add(this.lblDbUsername);
            this.grpDatabase.Controls.Add(this.txtDbUsername);
            this.grpDatabase.Controls.Add(this.lblDbPassword);
            this.grpDatabase.Controls.Add(this.txtDbPassword);
            this.grpDatabase.Controls.Add(this.btnTestConnection);
            this.grpDatabase.Controls.Add(this.lblTestResult);
            this.grpDatabase.Location = new System.Drawing.Point(12, 12);
            this.grpDatabase.Name = "grpDatabase";
            this.grpDatabase.Size = new System.Drawing.Size(360, 230);
            this.grpDatabase.TabIndex = 0;
            this.grpDatabase.TabStop = false;
            this.grpDatabase.Text = "데이터베이스 설정";
            //
            // lblDbHost
            //
            this.lblDbHost.AutoSize = true;
            this.lblDbHost.Location = new System.Drawing.Point(15, 30);
            this.lblDbHost.Name = "lblDbHost";
            this.lblDbHost.Size = new System.Drawing.Size(42, 15);
            this.lblDbHost.Text = "Host";
            //
            // txtDbHost
            //
            this.txtDbHost.Location = new System.Drawing.Point(120, 27);
            this.txtDbHost.Name = "txtDbHost";
            this.txtDbHost.Size = new System.Drawing.Size(220, 25);
            //
            // lblDbPort
            //
            this.lblDbPort.AutoSize = true;
            this.lblDbPort.Location = new System.Drawing.Point(15, 62);
            this.lblDbPort.Name = "lblDbPort";
            this.lblDbPort.Size = new System.Drawing.Size(35, 15);
            this.lblDbPort.Text = "Port";
            //
            // txtDbPort
            //
            this.txtDbPort.Location = new System.Drawing.Point(120, 59);
            this.txtDbPort.Name = "txtDbPort";
            this.txtDbPort.Size = new System.Drawing.Size(220, 25);
            //
            // lblDbName
            //
            this.lblDbName.AutoSize = true;
            this.lblDbName.Location = new System.Drawing.Point(15, 94);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(80, 15);
            this.lblDbName.Text = "Database";
            //
            // txtDbName
            //
            this.txtDbName.Location = new System.Drawing.Point(120, 91);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(220, 25);
            //
            // lblDbUsername
            //
            this.lblDbUsername.AutoSize = true;
            this.lblDbUsername.Location = new System.Drawing.Point(15, 126);
            this.lblDbUsername.Name = "lblDbUsername";
            this.lblDbUsername.Size = new System.Drawing.Size(75, 15);
            this.lblDbUsername.Text = "Username";
            //
            // txtDbUsername
            //
            this.txtDbUsername.Location = new System.Drawing.Point(120, 123);
            this.txtDbUsername.Name = "txtDbUsername";
            this.txtDbUsername.Size = new System.Drawing.Size(220, 25);
            //
            // lblDbPassword
            //
            this.lblDbPassword.AutoSize = true;
            this.lblDbPassword.Location = new System.Drawing.Point(15, 158);
            this.lblDbPassword.Name = "lblDbPassword";
            this.lblDbPassword.Size = new System.Drawing.Size(73, 15);
            this.lblDbPassword.Text = "Password";
            //
            // txtDbPassword
            //
            this.txtDbPassword.Location = new System.Drawing.Point(120, 155);
            this.txtDbPassword.Name = "txtDbPassword";
            this.txtDbPassword.Size = new System.Drawing.Size(220, 25);
            this.txtDbPassword.UseSystemPasswordChar = true;
            //
            // btnTestConnection
            //
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnTestConnection.Location = new System.Drawing.Point(15, 190);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(100, 28);
            this.btnTestConnection.Text = "연결 테스트";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            //
            // lblTestResult
            //
            this.lblTestResult = new System.Windows.Forms.Label();
            this.lblTestResult.AutoSize = true;
            this.lblTestResult.Location = new System.Drawing.Point(120, 196);
            this.lblTestResult.Name = "lblTestResult";
            this.lblTestResult.Size = new System.Drawing.Size(0, 15);
            //
            // grpProject
            //
            this.grpProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProject.Controls.Add(this.lblProjectRoot);
            this.grpProject.Controls.Add(this.txtProjectRoot);
            this.grpProject.Controls.Add(this.btnBrowse);
            this.grpProject.Location = new System.Drawing.Point(12, 252);
            this.grpProject.Name = "grpProject";
            this.grpProject.Size = new System.Drawing.Size(360, 70);
            this.grpProject.TabIndex = 1;
            this.grpProject.TabStop = false;
            this.grpProject.Text = "프로젝트 설정";
            //
            // lblProjectRoot
            //
            this.lblProjectRoot.AutoSize = true;
            this.lblProjectRoot.Location = new System.Drawing.Point(15, 30);
            this.lblProjectRoot.Name = "lblProjectRoot";
            this.lblProjectRoot.Size = new System.Drawing.Size(80, 15);
            this.lblProjectRoot.Text = "프로젝트 경로";
            //
            // txtProjectRoot
            //
            this.txtProjectRoot.Location = new System.Drawing.Point(120, 27);
            this.txtProjectRoot.Name = "txtProjectRoot";
            this.txtProjectRoot.Size = new System.Drawing.Size(185, 25);
            //
            // btnBrowse
            //
            this.btnBrowse.Location = new System.Drawing.Point(311, 26);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(30, 25);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(190, 338);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 32);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(285, 338);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // SettingsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 385);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpProject);
            this.Controls.Add(this.grpDatabase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "설정";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.grpDatabase.ResumeLayout(false);
            this.grpDatabase.PerformLayout();
            this.grpProject.ResumeLayout(false);
            this.grpProject.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpDatabase;
        private System.Windows.Forms.GroupBox grpProject;
        private System.Windows.Forms.Label lblDbHost;
        private System.Windows.Forms.Label lblDbPort;
        private System.Windows.Forms.Label lblDbName;
        private System.Windows.Forms.Label lblDbUsername;
        private System.Windows.Forms.Label lblDbPassword;
        private System.Windows.Forms.TextBox txtDbHost;
        private System.Windows.Forms.TextBox txtDbPort;
        private System.Windows.Forms.TextBox txtDbName;
        private System.Windows.Forms.TextBox txtDbUsername;
        private System.Windows.Forms.TextBox txtDbPassword;
        private System.Windows.Forms.Label lblProjectRoot;
        private System.Windows.Forms.TextBox txtProjectRoot;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label lblTestResult;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
