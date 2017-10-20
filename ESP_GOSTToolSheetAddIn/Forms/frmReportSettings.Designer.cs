namespace ESP_GOSTToolSheetAddIn.Forms
{
    partial class frmReportSettings
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
            this.tbReportField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dlgDistFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectDistFolder = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDefaultReportName = new System.Windows.Forms.TextBox();
            this.cbRemoteHost = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHostName = new System.Windows.Forms.TextBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.tbSQLServerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbReportField
            // 
            this.tbReportField.Location = new System.Drawing.Point(12, 29);
            this.tbReportField.Name = "tbReportField";
            this.tbReportField.Size = new System.Drawing.Size(271, 20);
            this.tbReportField.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Папка для сохранения отчета";
            // 
            // btnSelectDistFolder
            // 
            this.btnSelectDistFolder.Location = new System.Drawing.Point(294, 27);
            this.btnSelectDistFolder.Name = "btnSelectDistFolder";
            this.btnSelectDistFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelectDistFolder.TabIndex = 2;
            this.btnSelectDistFolder.Text = "Выбор";
            this.btnSelectDistFolder.UseVisualStyleBackColor = true;
            this.btnSelectDistFolder.Click += new System.EventHandler(this.btnSelectDistFolder_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(294, 214);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(213, 214);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Имя файла отчета по умолчанию";
            // 
            // tbDefaultReportName
            // 
            this.tbDefaultReportName.Location = new System.Drawing.Point(12, 73);
            this.tbDefaultReportName.Name = "tbDefaultReportName";
            this.tbDefaultReportName.Size = new System.Drawing.Size(357, 20);
            this.tbDefaultReportName.TabIndex = 4;
            this.tbDefaultReportName.MouseLeave += new System.EventHandler(this.tbDefaultReportName_MouseLeave);
            // 
            // cbRemoteHost
            // 
            this.cbRemoteHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRemoteHost.AutoSize = true;
            this.cbRemoteHost.Location = new System.Drawing.Point(6, 60);
            this.cbRemoteHost.Name = "cbRemoteHost";
            this.cbRemoteHost.Size = new System.Drawing.Size(216, 17);
            this.cbRemoteHost.TabIndex = 0;
            this.cbRemoteHost.Text = "Подключиться к удаленному серверу";
            this.cbRemoteHost.UseVisualStyleBackColor = true;
            this.cbRemoteHost.CheckedChanged += new System.EventHandler(this.cbRemoteHost_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbSQLServerName);
            this.groupBox1.Controls.Add(this.tbHostName);
            this.groupBox1.Controls.Add(this.cbRemoteHost);
            this.groupBox1.Controls.Add(this.btnTestConnection);
            this.groupBox1.Location = new System.Drawing.Point(12, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 109);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сетевые настройки";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Имя сервера";
            // 
            // tbHostName
            // 
            this.tbHostName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHostName.Location = new System.Drawing.Point(86, 83);
            this.tbHostName.Name = "tbHostName";
            this.tbHostName.Size = new System.Drawing.Size(265, 20);
            this.tbHostName.TabIndex = 2;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestConnection.Location = new System.Drawing.Point(276, 54);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(75, 23);
            this.btnTestConnection.TabIndex = 1;
            this.btnTestConnection.Text = "Тест";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // tbSQLServerName
            // 
            this.tbSQLServerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSQLServerName.Location = new System.Drawing.Point(110, 28);
            this.tbSQLServerName.Name = "tbSQLServerName";
            this.tbSQLServerName.Size = new System.Drawing.Size(241, 20);
            this.tbSQLServerName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Имя SQL сервера";
            // 
            // frmReportSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 249);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbDefaultReportName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSelectDistFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbReportField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReportSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры карты наладки";
            this.Load += new System.EventHandler(this.frmReportSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbReportField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog dlgDistFolderBrowser;
        private System.Windows.Forms.Button btnSelectDistFolder;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDefaultReportName;
        private System.Windows.Forms.CheckBox cbRemoteHost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbHostName;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSQLServerName;
    }
}