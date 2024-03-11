namespace Aprimo.ConfigurationWorkbookGenerator
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubdomain = new System.Windows.Forms.TextBox();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserToken = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOutputFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowseForOutputFile = new System.Windows.Forms.Button();
            this.btnBrowseForInputFile = new System.Windows.Forms.Button();
            this.txtInputFilePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBarMainProcess = new System.Windows.Forms.ProgressBar();
            this.progressBarSubProcess = new System.Windows.Forms.ProgressBar();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnResetOutputFileName = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(325, 237);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(150, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Subdomain:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Client ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "User token:";
            // 
            // txtSubdomain
            // 
            this.txtSubdomain.Location = new System.Drawing.Point(75, 23);
            this.txtSubdomain.Name = "txtSubdomain";
            this.txtSubdomain.Size = new System.Drawing.Size(300, 20);
            this.txtSubdomain.TabIndex = 5;
            // 
            // txtClientId
            // 
            this.txtClientId.Location = new System.Drawing.Point(75, 50);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(300, 20);
            this.txtClientId.TabIndex = 6;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(75, 77);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(300, 20);
            this.txtUserName.TabIndex = 7;
            // 
            // txtUserToken
            // 
            this.txtUserToken.Location = new System.Drawing.Point(75, 104);
            this.txtUserToken.Name = "txtUserToken";
            this.txtUserToken.Size = new System.Drawing.Size(300, 20);
            this.txtUserToken.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUserToken);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtClientId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSubdomain);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 140);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Output configuration workbook:";
            // 
            // txtOutputFilePath
            // 
            this.txtOutputFilePath.Location = new System.Drawing.Point(178, 162);
            this.txtOutputFilePath.Name = "txtOutputFilePath";
            this.txtOutputFilePath.Size = new System.Drawing.Size(505, 20);
            this.txtOutputFilePath.TabIndex = 9;
            // 
            // btnBrowseForOutputFile
            // 
            this.btnBrowseForOutputFile.Location = new System.Drawing.Point(689, 161);
            this.btnBrowseForOutputFile.Name = "btnBrowseForOutputFile";
            this.btnBrowseForOutputFile.Size = new System.Drawing.Size(30, 20);
            this.btnBrowseForOutputFile.TabIndex = 11;
            this.btnBrowseForOutputFile.Text = "...";
            this.btnBrowseForOutputFile.UseVisualStyleBackColor = true;
            this.btnBrowseForOutputFile.Click += new System.EventHandler(this.BtnBrowseForOutputFile_Click);
            // 
            // btnBrowseForInputFile
            // 
            this.btnBrowseForInputFile.Location = new System.Drawing.Point(689, 188);
            this.btnBrowseForInputFile.Name = "btnBrowseForInputFile";
            this.btnBrowseForInputFile.Size = new System.Drawing.Size(30, 20);
            this.btnBrowseForInputFile.TabIndex = 14;
            this.btnBrowseForInputFile.Text = "...";
            this.btnBrowseForInputFile.UseVisualStyleBackColor = true;
            this.btnBrowseForInputFile.Click += new System.EventHandler(this.BtnBrowseForInputFile_Click);
            // 
            // txtInputFilePath
            // 
            this.txtInputFilePath.Location = new System.Drawing.Point(178, 188);
            this.txtInputFilePath.Name = "txtInputFilePath";
            this.txtInputFilePath.Size = new System.Drawing.Size(505, 20);
            this.txtInputFilePath.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Input configuration workbook:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(175, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(556, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "(Providing an input workbook is optional. This file will only be used to copy ove" +
    "r the \"Notes\"-column for a config item)";
            // 
            // progressBarMainProcess
            // 
            this.progressBarMainProcess.Location = new System.Drawing.Point(13, 266);
            this.progressBarMainProcess.Name = "progressBarMainProcess";
            this.progressBarMainProcess.Size = new System.Drawing.Size(758, 23);
            this.progressBarMainProcess.TabIndex = 16;
            // 
            // progressBarSubProcess
            // 
            this.progressBarSubProcess.Location = new System.Drawing.Point(12, 295);
            this.progressBarSubProcess.Name = "progressBarSubProcess";
            this.progressBarSubProcess.Size = new System.Drawing.Size(758, 23);
            this.progressBarSubProcess.TabIndex = 17;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 325);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(758, 224);
            this.txtLog.TabIndex = 18;
            // 
            // btnResetOutputFileName
            // 
            this.btnResetOutputFileName.Location = new System.Drawing.Point(725, 162);
            this.btnResetOutputFileName.Name = "btnResetOutputFileName";
            this.btnResetOutputFileName.Size = new System.Drawing.Size(45, 20);
            this.btnResetOutputFileName.TabIndex = 19;
            this.btnResetOutputFileName.Text = "Reset";
            this.btnResetOutputFileName.UseVisualStyleBackColor = true;
            this.btnResetOutputFileName.Click += new System.EventHandler(this.BtnResetOutputFileName_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Select folder to place configuration workbook file";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "\"Excel documents|*.xlsx|All files|8.8";
            this.openFileDialog1.Title = "Input configuration workbook";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnResetOutputFileName);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.progressBarSubProcess);
            this.Controls.Add(this.progressBarMainProcess);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnBrowseForInputFile);
            this.Controls.Add(this.txtInputFilePath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnBrowseForOutputFile);
            this.Controls.Add(this.txtOutputFilePath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Text = "Generate Configuration Workbook";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubdomain;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtUserToken;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOutputFilePath;
        private System.Windows.Forms.Button btnBrowseForOutputFile;
        private System.Windows.Forms.Button btnBrowseForInputFile;
        private System.Windows.Forms.TextBox txtInputFilePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ProgressBar progressBarMainProcess;
        internal System.Windows.Forms.ProgressBar progressBarSubProcess;
        internal System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnResetOutputFileName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

