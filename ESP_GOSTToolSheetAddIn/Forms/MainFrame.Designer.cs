namespace ESP_GOSTToolSheetAddIn.Forms
{
    partial class MainFrame
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemDataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveDataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemUpdataDataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowPatternFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemReportSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnSaveInFile = new System.Windows.Forms.Button();
            this.tbFIOControl = new System.Windows.Forms.TextBox();
            this.tbFIOAccept = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFIOCheck = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFIODev = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCncMachineName = new System.Windows.Forms.TextBox();
            this.tbCNCName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbDetailSign = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDetailName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCompanyName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listDocumentTools = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dgvReportToolParameters = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dsReportParameters = new System.Data.DataSet();
            this.dtReportParams = new System.Data.DataTable();
            this.dColParamName = new System.Data.DataColumn();
            this.dColParamValue = new System.Data.DataColumn();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportToolParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReportParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReportParams)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemDataBase,
            this.MenuItemSettings,
            this.MenuItemHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(708, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemDataBase
            // 
            this.MenuItemDataBase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemSaveDataBase,
            this.MenuItemUpdataDataBase});
            this.MenuItemDataBase.Name = "MenuItemDataBase";
            this.MenuItemDataBase.Size = new System.Drawing.Size(85, 20);
            this.MenuItemDataBase.Text = "База знаний";
            // 
            // MenuItemSaveDataBase
            // 
            this.MenuItemSaveDataBase.Name = "MenuItemSaveDataBase";
            this.MenuItemSaveDataBase.Size = new System.Drawing.Size(160, 22);
            this.MenuItemSaveDataBase.Text = "Сохранить в БЗ";
            this.MenuItemSaveDataBase.Click += new System.EventHandler(this.MenuItemSaveDataBase_Click);
            // 
            // MenuItemUpdataDataBase
            // 
            this.MenuItemUpdataDataBase.Name = "MenuItemUpdataDataBase";
            this.MenuItemUpdataDataBase.Size = new System.Drawing.Size(160, 22);
            this.MenuItemUpdataDataBase.Text = "Загрузить из БЗ";
            this.MenuItemUpdataDataBase.Click += new System.EventHandler(this.MenuItemUpdataDataBase_Click);
            // 
            // MenuItemSettings
            // 
            this.MenuItemSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowPatternFileMenuItem,
            this.MenuItemReportSetting});
            this.MenuItemSettings.Name = "MenuItemSettings";
            this.MenuItemSettings.Size = new System.Drawing.Size(78, 20);
            this.MenuItemSettings.Text = "Настройка";
            // 
            // ShowPatternFileMenuItem
            // 
            this.ShowPatternFileMenuItem.Name = "ShowPatternFileMenuItem";
            this.ShowPatternFileMenuItem.Size = new System.Drawing.Size(269, 22);
            this.ShowPatternFileMenuItem.Text = "Шаблон параметров инструментов";
            this.ShowPatternFileMenuItem.Click += new System.EventHandler(this.ShowPatternFileMenuItem_Click);
            // 
            // MenuItemReportSetting
            // 
            this.MenuItemReportSetting.Name = "MenuItemReportSetting";
            this.MenuItemReportSetting.Size = new System.Drawing.Size(269, 22);
            this.MenuItemReportSetting.Text = "Параметры карты наладки";
            this.MenuItemReportSetting.Click += new System.EventHandler(this.MenuItemReportSetting_Click);
            // 
            // MenuItemHelp
            // 
            this.MenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemHelpAbout});
            this.MenuItemHelp.Name = "MenuItemHelp";
            this.MenuItemHelp.Size = new System.Drawing.Size(65, 20);
            this.MenuItemHelp.Text = "Справка";
            // 
            // MenuItemHelpAbout
            // 
            this.MenuItemHelpAbout.Name = "MenuItemHelpAbout";
            this.MenuItemHelpAbout.Size = new System.Drawing.Size(154, 22);
            this.MenuItemHelpAbout.Text = "О дополнении";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 77);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(686, 363);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnSaveInFile);
            this.tabPage3.Controls.Add(this.tbFIOControl);
            this.tabPage3.Controls.Add(this.tbFIOAccept);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.tbFIOCheck);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.tbFIODev);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.tbCncMachineName);
            this.tabPage3.Controls.Add(this.tbCNCName);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.tbDetailSign);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.tbDetailName);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.tbCompanyName);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(678, 337);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Параметры карты наладки";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnSaveInFile
            // 
            this.btnSaveInFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveInFile.Location = new System.Drawing.Point(478, 302);
            this.btnSaveInFile.Name = "btnSaveInFile";
            this.btnSaveInFile.Size = new System.Drawing.Size(194, 29);
            this.btnSaveInFile.TabIndex = 0;
            this.btnSaveInFile.TabStop = false;
            this.btnSaveInFile.Text = "Сохранить в текущем файле";
            this.btnSaveInFile.UseVisualStyleBackColor = true;
            // 
            // tbFIOControl
            // 
            this.tbFIOControl.Location = new System.Drawing.Point(104, 94);
            this.tbFIOControl.Name = "tbFIOControl";
            this.tbFIOControl.Size = new System.Drawing.Size(170, 20);
            this.tbFIOControl.TabIndex = 3;
            this.tbFIOControl.Leave += new System.EventHandler(this.tbFIOControl_Leave);
            // 
            // tbFIOAccept
            // 
            this.tbFIOAccept.Location = new System.Drawing.Point(104, 68);
            this.tbFIOAccept.Name = "tbFIOAccept";
            this.tbFIOAccept.Size = new System.Drawing.Size(170, 20);
            this.tbFIOAccept.TabIndex = 2;
            this.tbFIOAccept.Leave += new System.EventHandler(this.tbFIOAccept_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "ФИО Н.контр.";
            // 
            // tbFIOCheck
            // 
            this.tbFIOCheck.Location = new System.Drawing.Point(104, 42);
            this.tbFIOCheck.Name = "tbFIOCheck";
            this.tbFIOCheck.Size = new System.Drawing.Size(170, 20);
            this.tbFIOCheck.TabIndex = 1;
            this.tbFIOCheck.Leave += new System.EventHandler(this.tbFIOCheck_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "ФИО Утв.";
            // 
            // tbFIODev
            // 
            this.tbFIODev.Location = new System.Drawing.Point(104, 16);
            this.tbFIODev.Name = "tbFIODev";
            this.tbFIODev.Size = new System.Drawing.Size(170, 20);
            this.tbFIODev.TabIndex = 0;
            this.tbFIODev.Leave += new System.EventHandler(this.tbFIODev_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "ФИО Пров.";
            // 
            // tbCncMachineName
            // 
            this.tbCncMachineName.Location = new System.Drawing.Point(452, 120);
            this.tbCncMachineName.Name = "tbCncMachineName";
            this.tbCncMachineName.Size = new System.Drawing.Size(170, 20);
            this.tbCncMachineName.TabIndex = 8;
            this.tbCncMachineName.Leave += new System.EventHandler(this.tbCncMachineName_Leave);
            // 
            // tbCNCName
            // 
            this.tbCNCName.Location = new System.Drawing.Point(452, 94);
            this.tbCNCName.Name = "tbCNCName";
            this.tbCNCName.Size = new System.Drawing.Size(170, 20);
            this.tbCNCName.TabIndex = 7;
            this.tbCNCName.Leave += new System.EventHandler(this.tbCNCName_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(295, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Наименование станка";
            // 
            // tbDetailSign
            // 
            this.tbDetailSign.Location = new System.Drawing.Point(452, 68);
            this.tbDetailSign.Name = "tbDetailSign";
            this.tbDetailSign.Size = new System.Drawing.Size(170, 20);
            this.tbDetailSign.TabIndex = 6;
            this.tbDetailSign.Leave += new System.EventHandler(this.tbDetailSign_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(295, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Наименование УП";
            // 
            // tbDetailName
            // 
            this.tbDetailName.Location = new System.Drawing.Point(452, 42);
            this.tbDetailName.Name = "tbDetailName";
            this.tbDetailName.Size = new System.Drawing.Size(170, 20);
            this.tbDetailName.TabIndex = 5;
            this.tbDetailName.Leave += new System.EventHandler(this.tbDetailName_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(295, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Обозначение детали";
            // 
            // tbCompanyName
            // 
            this.tbCompanyName.Location = new System.Drawing.Point(452, 16);
            this.tbCompanyName.Name = "tbCompanyName";
            this.tbCompanyName.Size = new System.Drawing.Size(170, 20);
            this.tbCompanyName.TabIndex = 4;
            this.tbCompanyName.Leave += new System.EventHandler(this.tbCompanyName_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(295, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Наименование детали";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "ФИО Разраб.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Наименование организации";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(678, 337);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Текущий документ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listDocumentTools);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvReportToolParameters);
            this.splitContainer1.Size = new System.Drawing.Size(672, 331);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.TabIndex = 0;
            // 
            // listDocumentTools
            // 
            this.listDocumentTools.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1});
            this.listDocumentTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDocumentTools.FullRowSelect = true;
            this.listDocumentTools.HideSelection = false;
            this.listDocumentTools.Location = new System.Drawing.Point(0, 0);
            this.listDocumentTools.MultiSelect = false;
            this.listDocumentTools.Name = "listDocumentTools";
            this.listDocumentTools.Size = new System.Drawing.Size(262, 331);
            this.listDocumentTools.TabIndex = 0;
            this.listDocumentTools.UseCompatibleStateImageBehavior = false;
            this.listDocumentTools.View = System.Windows.Forms.View.Details;
            this.listDocumentTools.Click += new System.EventHandler(this.listDocumentTools_Click);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID Инструмента";
            this.columnHeader2.Width = 121;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Тип инструмента";
            this.columnHeader1.Width = 188;
            // 
            // dgvReportToolParameters
            // 
            this.dgvReportToolParameters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReportToolParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportToolParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvReportToolParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReportToolParameters.Location = new System.Drawing.Point(0, 0);
            this.dgvReportToolParameters.Name = "dgvReportToolParameters";
            this.dgvReportToolParameters.Size = new System.Drawing.Size(406, 331);
            this.dgvReportToolParameters.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 150F;
            this.Column1.HeaderText = "Название параметра";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 200F;
            this.Column2.HeaderText = "Значение параметра";
            this.Column2.Name = "Column2";
            // 
            // btnGenerate
            // 
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerate.Location = new System.Drawing.Point(12, 30);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(686, 41);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Сгенерировать карту наладки";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // dsReportParameters
            // 
            this.dsReportParameters.DataSetName = "NewDataSet";
            this.dsReportParameters.Tables.AddRange(new System.Data.DataTable[] {
            this.dtReportParams});
            // 
            // dtReportParams
            // 
            this.dtReportParams.Columns.AddRange(new System.Data.DataColumn[] {
            this.dColParamName,
            this.dColParamValue});
            this.dtReportParams.TableName = "ReportParameters";
            // 
            // dColParamName
            // 
            this.dColParamName.Caption = "Название параметра";
            this.dColParamName.ColumnName = "clmParameterName";
            // 
            // dColParamValue
            // 
            this.dColParamValue.Caption = "Значение параметра";
            this.dColParamValue.ColumnName = "clmParameterValue";
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 452);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ГОСТ 3.14.04-86 Карта наладки";
            this.Shown += new System.EventHandler(this.MainFrame_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportToolParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReportParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReportParams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDataBase;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem ShowPatternFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemReportSetting;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHelpAbout;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveDataBase;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUpdataDataBase;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listDocumentTools;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.DataGridView dgvReportToolParameters;
        private System.Windows.Forms.TextBox tbFIOCheck;
        private System.Windows.Forms.TextBox tbFIODev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCompanyName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFIOControl;
        private System.Windows.Forms.TextBox tbFIOAccept;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDetailSign;
        private System.Windows.Forms.TextBox tbDetailName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCncMachineName;
        private System.Windows.Forms.TextBox tbCNCName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSaveInFile;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Data.DataSet dsReportParameters;
        private System.Data.DataTable dtReportParams;
        private System.Data.DataColumn dColParamName;
        private System.Data.DataColumn dColParamValue;
    }
}