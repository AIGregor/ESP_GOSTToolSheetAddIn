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
            this.lstTools = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripCreate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listEspStandardParameters = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listEspGostParams = new System.Windows.Forms.ListView();
            this.clmNewParametersName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmNewParameterName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmNewParameterType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmNewParameterClCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTools
            // 
            this.lstTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstTools.FormattingEnabled = true;
            this.lstTools.Location = new System.Drawing.Point(0, 0);
            this.lstTools.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstTools.Name = "lstTools";
            this.lstTools.Size = new System.Drawing.Size(249, 420);
            this.lstTools.TabIndex = 5;
            this.lstTools.Click += new System.EventHandler(this.lstTools_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(477, 388);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAdd,
            this.toolStripCreate,
            this.toolStripSeparator1,
            this.toolStripDelete,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(249, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(395, 25);
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
            this.toolStripDelete.Click += new System.EventHandler(this.toolStripDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(258, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listEspStandardParameters);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listEspGostParams);
            this.splitContainer1.Size = new System.Drawing.Size(374, 354);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 15;
            // 
            // listEspStandardParameters
            // 
            this.listEspStandardParameters.AllowDrop = true;
            this.listEspStandardParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2});
            this.listEspStandardParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listEspStandardParameters.FullRowSelect = true;
            this.listEspStandardParameters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listEspStandardParameters.Location = new System.Drawing.Point(0, 0);
            this.listEspStandardParameters.Name = "listEspStandardParameters";
            this.listEspStandardParameters.Size = new System.Drawing.Size(193, 354);
            this.listEspStandardParameters.TabIndex = 17;
            this.listEspStandardParameters.UseCompatibleStateImageBehavior = false;
            this.listEspStandardParameters.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Параметры инстремунта";
            this.columnHeader1.Width = 256;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Имя параметра";
            this.columnHeader3.Width = 130;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "CL Code";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listEspGostParams
            // 
            this.listEspGostParams.AllowDrop = true;
            this.listEspGostParams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmNewParametersName,
            this.clmNewParameterName,
            this.clmNewParameterType,
            this.clmNewParameterClCode});
            this.listEspGostParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listEspGostParams.FullRowSelect = true;
            this.listEspGostParams.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listEspGostParams.Location = new System.Drawing.Point(0, 0);
            this.listEspGostParams.Name = "listEspGostParams";
            this.listEspGostParams.Size = new System.Drawing.Size(177, 354);
            this.listEspGostParams.TabIndex = 18;
            this.listEspGostParams.UseCompatibleStateImageBehavior = false;
            this.listEspGostParams.View = System.Windows.Forms.View.Details;
            // 
            // clmNewParametersName
            // 
            this.clmNewParametersName.Text = "Параметры для карты наладки";
            this.clmNewParametersName.Width = 227;
            // 
            // clmNewParameterName
            // 
            this.clmNewParameterName.Text = "Имя параметра";
            this.clmNewParameterName.Width = 136;
            // 
            // clmNewParameterType
            // 
            this.clmNewParameterType.Text = "Тип параметры";
            this.clmNewParameterType.Width = 120;
            // 
            // clmNewParameterClCode
            // 
            this.clmNewParameterClCode.Text = "CL Code";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(395, 388);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(76, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(556, 388);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(76, 23);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmEspToolsParameters
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(644, 420);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lstTools);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEspToolsParameters";
            this.Text = "Параметры инструмента для карте наладки";
            this.Load += new System.EventHandler(this.EspToolsParameters_Load);
            this.Shown += new System.EventHandler(this.frmEspToolsParameters_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstTools;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripCreate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listEspStandardParameters;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView listEspGostParams;
        private System.Windows.Forms.ColumnHeader clmNewParametersName;
        private System.Windows.Forms.ColumnHeader clmNewParameterName;
        private System.Windows.Forms.ColumnHeader clmNewParameterType;
        private System.Windows.Forms.ColumnHeader clmNewParameterClCode;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnApply;
    }
}