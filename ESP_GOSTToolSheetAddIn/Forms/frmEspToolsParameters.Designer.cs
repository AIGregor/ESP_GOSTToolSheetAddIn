namespace ESP_GOSTToolSheetAddIn
{
    partial class frmEspToolsParameters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEspToolsParameters));
            this.listEspGostParams = new System.Windows.Forms.ListView();
            this.clmNewParametersName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbSortToolList = new System.Windows.Forms.ComboBox();
            this.lstTools = new System.Windows.Forms.ListBox();
            this.listEspStandardParameters = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripCreate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listEspGostParams
            // 
            this.listEspGostParams.AllowDrop = true;
            this.listEspGostParams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmNewParametersName});
            this.listEspGostParams.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listEspGostParams.Location = new System.Drawing.Point(533, 28);
            this.listEspGostParams.Name = "listEspGostParams";
            this.listEspGostParams.Size = new System.Drawing.Size(270, 354);
            this.listEspGostParams.TabIndex = 7;
            this.listEspGostParams.UseCompatibleStateImageBehavior = false;
            this.listEspGostParams.View = System.Windows.Forms.View.Details;
            // 
            // clmNewParametersName
            // 
            this.clmNewParametersName.Text = "Параметры для карты наладки";
            this.clmNewParametersName.Width = 138;
            // 
            // cbSortToolList
            // 
            this.cbSortToolList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSortToolList.FormattingEnabled = true;
            this.cbSortToolList.Items.AddRange(new object[] {
            "Все инструменты",
            "Фрезерный инструмент",
            "Токарный инструмент"});
            this.cbSortToolList.Location = new System.Drawing.Point(12, 28);
            this.cbSortToolList.Name = "cbSortToolList";
            this.cbSortToolList.Size = new System.Drawing.Size(223, 21);
            this.cbSortToolList.TabIndex = 6;
            // 
            // lstTools
            // 
            this.lstTools.FormattingEnabled = true;
            this.lstTools.Location = new System.Drawing.Point(12, 56);
            this.lstTools.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstTools.Name = "lstTools";
            this.lstTools.Size = new System.Drawing.Size(223, 355);
            this.lstTools.TabIndex = 5;
            this.lstTools.Click += new System.EventHandler(this.lstTools_Click);
            // 
            // listEspStandardParameters
            // 
            this.listEspStandardParameters.AllowDrop = true;
            this.listEspStandardParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listEspStandardParameters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listEspStandardParameters.Location = new System.Drawing.Point(241, 28);
            this.listEspStandardParameters.Name = "listEspStandardParameters";
            this.listEspStandardParameters.Size = new System.Drawing.Size(286, 354);
            this.listEspStandardParameters.TabIndex = 7;
            this.listEspStandardParameters.UseCompatibleStateImageBehavior = false;
            this.listEspStandardParameters.View = System.Windows.Forms.View.Details;
            this.listEspStandardParameters.DragDrop += new System.Windows.Forms.DragEventHandler(this.listEspStandardParameters_DragDrop);
            this.listEspStandardParameters.DragEnter += new System.Windows.Forms.DragEventHandler(this.listEspStandardParameters_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Все параметры инстремунта";
            this.columnHeader1.Width = 139;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(566, 388);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(647, 388);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(728, 388);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 11;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAdd,
            this.toolStripCreate,
            this.toolStripSeparator1,
            this.toolStripDelete,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(814, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripAdd
            // 
            this.toolStripAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAdd.Image")));
            this.toolStripAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAdd.Name = "toolStripAdd";
            this.toolStripAdd.Size = new System.Drawing.Size(79, 22);
            this.toolStripAdd.Text = "Добавить";
            this.toolStripAdd.Click += new System.EventHandler(this.toolStripAdd_Click);
            // 
            // toolStripCreate
            // 
            this.toolStripCreate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripCreate.Image")));
            this.toolStripCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripCreate.Name = "toolStripCreate";
            this.toolStripCreate.Size = new System.Drawing.Size(70, 22);
            this.toolStripCreate.Text = "Создать";
            this.toolStripCreate.Click += new System.EventHandler(this.toolStripCreate_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDelete
            // 
            this.toolStripDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDelete.Image")));
            this.toolStripDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDelete.Name = "toolStripDelete";
            this.toolStripDelete.Size = new System.Drawing.Size(71, 22);
            this.toolStripDelete.Text = "Удалить";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // frmEspToolsParameters
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 422);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.listEspStandardParameters);
            this.Controls.Add(this.listEspGostParams);
            this.Controls.Add(this.cbSortToolList);
            this.Controls.Add(this.lstTools);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmEspToolsParameters";
            this.Text = "Параметры инструмента для карте наладки";
            this.Load += new System.EventHandler(this.EspToolsParameters_Load);
            this.Shown += new System.EventHandler(this.frmEspToolsParameters_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listEspGostParams;
        private System.Windows.Forms.ColumnHeader clmNewParametersName;
        private System.Windows.Forms.ComboBox cbSortToolList;
        private System.Windows.Forms.ListBox lstTools;
        private System.Windows.Forms.ListView listEspStandardParameters;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripCreate;
    }
}