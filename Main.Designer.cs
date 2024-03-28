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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbTranslations = new System.Windows.Forms.CheckBox();
            this.cbWatermarks = new System.Windows.Forms.CheckBox();
            this.cbSettings = new System.Windows.Forms.CheckBox();
            this.cbFunctionalPermissions = new System.Windows.Forms.CheckBox();
            this.cbClassificationPermissions = new System.Windows.Forms.CheckBox();
            this.cbClassifications = new System.Windows.Forms.CheckBox();
            this.cbFieldDefinitions = new System.Windows.Forms.CheckBox();
            this.cbFieldGroups = new System.Windows.Forms.CheckBox();
            this.cbUserGroups = new System.Windows.Forms.CheckBox();
            this.cbRules = new System.Windows.Forms.CheckBox();
            this.cbContentTypes = new System.Windows.Forms.CheckBox();
            this.cbSelectAll = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(488, 365);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(225, 35);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Subdomain:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Client ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 123);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 165);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "User token:";
            // 
            // txtSubdomain
            // 
            this.txtSubdomain.Location = new System.Drawing.Point(112, 35);
            this.txtSubdomain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSubdomain.Name = "txtSubdomain";
            this.txtSubdomain.Size = new System.Drawing.Size(315, 26);
            this.txtSubdomain.TabIndex = 5;
            // 
            // txtClientId
            // 
            this.txtClientId.Location = new System.Drawing.Point(112, 77);
            this.txtClientId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.Size = new System.Drawing.Size(315, 26);
            this.txtClientId.TabIndex = 6;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(112, 118);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(315, 26);
            this.txtUserName.TabIndex = 7;
            // 
            // txtUserToken
            // 
            this.txtUserToken.Location = new System.Drawing.Point(112, 160);
            this.txtUserToken.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserToken.Name = "txtUserToken";
            this.txtUserToken.Size = new System.Drawing.Size(315, 26);
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
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(447, 215);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 255);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(230, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Output configuration workbook:";
            // 
            // txtOutputFilePath
            // 
            this.txtOutputFilePath.Location = new System.Drawing.Point(267, 249);
            this.txtOutputFilePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOutputFilePath.Name = "txtOutputFilePath";
            this.txtOutputFilePath.Size = new System.Drawing.Size(756, 26);
            this.txtOutputFilePath.TabIndex = 9;
            // 
            // btnBrowseForOutputFile
            // 
            this.btnBrowseForOutputFile.Location = new System.Drawing.Point(1034, 248);
            this.btnBrowseForOutputFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBrowseForOutputFile.Name = "btnBrowseForOutputFile";
            this.btnBrowseForOutputFile.Size = new System.Drawing.Size(45, 31);
            this.btnBrowseForOutputFile.TabIndex = 11;
            this.btnBrowseForOutputFile.Text = "...";
            this.btnBrowseForOutputFile.UseVisualStyleBackColor = true;
            this.btnBrowseForOutputFile.Click += new System.EventHandler(this.BtnBrowseForOutputFile_Click);
            // 
            // btnBrowseForInputFile
            // 
            this.btnBrowseForInputFile.Location = new System.Drawing.Point(1034, 289);
            this.btnBrowseForInputFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBrowseForInputFile.Name = "btnBrowseForInputFile";
            this.btnBrowseForInputFile.Size = new System.Drawing.Size(45, 31);
            this.btnBrowseForInputFile.TabIndex = 14;
            this.btnBrowseForInputFile.Text = "...";
            this.btnBrowseForInputFile.UseVisualStyleBackColor = true;
            this.btnBrowseForInputFile.Click += new System.EventHandler(this.BtnBrowseForInputFile_Click);
            // 
            // txtInputFilePath
            // 
            this.txtInputFilePath.Location = new System.Drawing.Point(267, 289);
            this.txtInputFilePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtInputFilePath.Name = "txtInputFilePath";
            this.txtInputFilePath.Size = new System.Drawing.Size(756, 26);
            this.txtInputFilePath.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 295);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Input configuration workbook:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(262, 325);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(816, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "(Providing an input workbook is optional. This file will only be used to copy ove" +
    "r the \"Notes\"-column for a config item)";
            // 
            // progressBarMainProcess
            // 
            this.progressBarMainProcess.Location = new System.Drawing.Point(20, 409);
            this.progressBarMainProcess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBarMainProcess.Name = "progressBarMainProcess";
            this.progressBarMainProcess.Size = new System.Drawing.Size(1137, 35);
            this.progressBarMainProcess.TabIndex = 16;
            // 
            // progressBarSubProcess
            // 
            this.progressBarSubProcess.Location = new System.Drawing.Point(18, 454);
            this.progressBarSubProcess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBarSubProcess.Name = "progressBarSubProcess";
            this.progressBarSubProcess.Size = new System.Drawing.Size(1137, 35);
            this.progressBarSubProcess.TabIndex = 17;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(18, 500);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(1135, 342);
            this.txtLog.TabIndex = 18;
            // 
            // btnResetOutputFileName
            // 
            this.btnResetOutputFileName.Location = new System.Drawing.Point(1088, 249);
            this.btnResetOutputFileName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnResetOutputFileName.Name = "btnResetOutputFileName";
            this.btnResetOutputFileName.Size = new System.Drawing.Size(68, 31);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbSelectAll);
            this.groupBox2.Controls.Add(this.cbContentTypes);
            this.groupBox2.Controls.Add(this.cbRules);
            this.groupBox2.Controls.Add(this.cbTranslations);
            this.groupBox2.Controls.Add(this.cbWatermarks);
            this.groupBox2.Controls.Add(this.cbSettings);
            this.groupBox2.Controls.Add(this.cbFunctionalPermissions);
            this.groupBox2.Controls.Add(this.cbClassificationPermissions);
            this.groupBox2.Controls.Add(this.cbClassifications);
            this.groupBox2.Controls.Add(this.cbFieldDefinitions);
            this.groupBox2.Controls.Add(this.cbFieldGroups);
            this.groupBox2.Controls.Add(this.cbUserGroups);
            this.groupBox2.Location = new System.Drawing.Point(488, 20);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(628, 215);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "What do you want to export:";
            // 
            // cbTranslations
            // 
            this.cbTranslations.AutoSize = true;
            this.cbTranslations.Checked = true;
            this.cbTranslations.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTranslations.Location = new System.Drawing.Point(421, 141);
            this.cbTranslations.Name = "cbTranslations";
            this.cbTranslations.Size = new System.Drawing.Size(121, 24);
            this.cbTranslations.TabIndex = 22;
            this.cbTranslations.Text = "Translations";
            this.cbTranslations.UseVisualStyleBackColor = true;
            // 
            // cbWatermarks
            // 
            this.cbWatermarks.AutoSize = true;
            this.cbWatermarks.Checked = true;
            this.cbWatermarks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWatermarks.Location = new System.Drawing.Point(421, 171);
            this.cbWatermarks.Name = "cbWatermarks";
            this.cbWatermarks.Size = new System.Drawing.Size(121, 24);
            this.cbWatermarks.TabIndex = 21;
            this.cbWatermarks.Text = "Watermarks";
            this.cbWatermarks.UseVisualStyleBackColor = true;
            // 
            // cbSettings
            // 
            this.cbSettings.AutoSize = true;
            this.cbSettings.Checked = true;
            this.cbSettings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSettings.Location = new System.Drawing.Point(421, 81);
            this.cbSettings.Name = "cbSettings";
            this.cbSettings.Size = new System.Drawing.Size(94, 24);
            this.cbSettings.TabIndex = 20;
            this.cbSettings.Text = "Settings";
            this.cbSettings.UseVisualStyleBackColor = true;
            // 
            // cbFunctionalPermissions
            // 
            this.cbFunctionalPermissions.AutoSize = true;
            this.cbFunctionalPermissions.Checked = true;
            this.cbFunctionalPermissions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFunctionalPermissions.Location = new System.Drawing.Point(18, 142);
            this.cbFunctionalPermissions.Name = "cbFunctionalPermissions";
            this.cbFunctionalPermissions.Size = new System.Drawing.Size(198, 24);
            this.cbFunctionalPermissions.TabIndex = 5;
            this.cbFunctionalPermissions.Text = "Functional Permissions";
            this.cbFunctionalPermissions.UseVisualStyleBackColor = true;
            // 
            // cbClassificationPermissions
            // 
            this.cbClassificationPermissions.AutoSize = true;
            this.cbClassificationPermissions.Checked = true;
            this.cbClassificationPermissions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbClassificationPermissions.Location = new System.Drawing.Point(18, 112);
            this.cbClassificationPermissions.Name = "cbClassificationPermissions";
            this.cbClassificationPermissions.Size = new System.Drawing.Size(217, 24);
            this.cbClassificationPermissions.TabIndex = 4;
            this.cbClassificationPermissions.Text = "Classification Permissions";
            this.cbClassificationPermissions.UseVisualStyleBackColor = true;
            // 
            // cbClassifications
            // 
            this.cbClassifications.AutoSize = true;
            this.cbClassifications.Checked = true;
            this.cbClassifications.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbClassifications.Location = new System.Drawing.Point(241, 135);
            this.cbClassifications.Name = "cbClassifications";
            this.cbClassifications.Size = new System.Drawing.Size(136, 24);
            this.cbClassifications.TabIndex = 3;
            this.cbClassifications.Text = "Classifications";
            this.cbClassifications.UseVisualStyleBackColor = true;
            // 
            // cbFieldDefinitions
            // 
            this.cbFieldDefinitions.AutoSize = true;
            this.cbFieldDefinitions.Checked = true;
            this.cbFieldDefinitions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFieldDefinitions.Location = new System.Drawing.Point(241, 107);
            this.cbFieldDefinitions.Name = "cbFieldDefinitions";
            this.cbFieldDefinitions.Size = new System.Drawing.Size(148, 24);
            this.cbFieldDefinitions.TabIndex = 2;
            this.cbFieldDefinitions.Text = "Field Definitions";
            this.cbFieldDefinitions.UseVisualStyleBackColor = true;
            // 
            // cbFieldGroups
            // 
            this.cbFieldGroups.AutoSize = true;
            this.cbFieldGroups.Checked = true;
            this.cbFieldGroups.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFieldGroups.Location = new System.Drawing.Point(241, 78);
            this.cbFieldGroups.Name = "cbFieldGroups";
            this.cbFieldGroups.Size = new System.Drawing.Size(126, 24);
            this.cbFieldGroups.TabIndex = 1;
            this.cbFieldGroups.Text = "Field Groups";
            this.cbFieldGroups.UseVisualStyleBackColor = true;
            // 
            // cbUserGroups
            // 
            this.cbUserGroups.AutoSize = true;
            this.cbUserGroups.Checked = true;
            this.cbUserGroups.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUserGroups.Location = new System.Drawing.Point(18, 82);
            this.cbUserGroups.Name = "cbUserGroups";
            this.cbUserGroups.Size = new System.Drawing.Size(126, 24);
            this.cbUserGroups.TabIndex = 0;
            this.cbUserGroups.Text = "User Groups";
            this.cbUserGroups.UseVisualStyleBackColor = true;
            // 
            // cbRules
            // 
            this.cbRules.AutoSize = true;
            this.cbRules.Checked = true;
            this.cbRules.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRules.Location = new System.Drawing.Point(421, 111);
            this.cbRules.Name = "cbRules";
            this.cbRules.Size = new System.Drawing.Size(76, 24);
            this.cbRules.TabIndex = 23;
            this.cbRules.Text = "Rules";
            this.cbRules.UseVisualStyleBackColor = true;
            // 
            // cbContentTypes
            // 
            this.cbContentTypes.AutoSize = true;
            this.cbContentTypes.Checked = true;
            this.cbContentTypes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbContentTypes.Location = new System.Drawing.Point(241, 165);
            this.cbContentTypes.Name = "cbContentTypes";
            this.cbContentTypes.Size = new System.Drawing.Size(138, 24);
            this.cbContentTypes.TabIndex = 24;
            this.cbContentTypes.Text = "Content Types";
            this.cbContentTypes.UseVisualStyleBackColor = true;
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.AutoSize = true;
            this.cbSelectAll.Checked = true;
            this.cbSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSelectAll.Location = new System.Drawing.Point(18, 35);
            this.cbSelectAll.Name = "cbSelectAll";
            this.cbSelectAll.Size = new System.Drawing.Size(168, 24);
            this.cbSelectAll.TabIndex = 25;
            this.cbSelectAll.Text = "Select/Deselect All";
            this.cbSelectAll.UseVisualStyleBackColor = true;
            this.cbSelectAll.CheckedChanged += new System.EventHandler(this.cbSelectAll_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 873);
            this.Controls.Add(this.groupBox2);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
            this.Text = "Generate Configuration Workbook";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbUserGroups;
        private System.Windows.Forms.CheckBox cbFieldGroups;
        private System.Windows.Forms.CheckBox cbFieldDefinitions;
        private System.Windows.Forms.CheckBox cbClassifications;
        private System.Windows.Forms.CheckBox cbClassificationPermissions;
        private System.Windows.Forms.CheckBox cbFunctionalPermissions;
        private System.Windows.Forms.CheckBox cbSettings;
        private System.Windows.Forms.CheckBox cbWatermarks;
        private System.Windows.Forms.CheckBox cbTranslations;
        private System.Windows.Forms.CheckBox cbContentTypes;
        private System.Windows.Forms.CheckBox cbRules;
        private System.Windows.Forms.CheckBox cbSelectAll;
    }
}

