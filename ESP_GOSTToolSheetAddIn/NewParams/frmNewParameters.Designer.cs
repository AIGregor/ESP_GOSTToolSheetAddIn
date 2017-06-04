namespace ESP_GOSTToolSheetAddIn.Forms
{
    partial class frmNewParameters
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
            this.lstTools = new System.Windows.Forms.ListBox();
            this.dtgAddParams = new System.Windows.Forms.DataGridView();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.paramName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paramValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAddParams)).BeginInit();
            this.SuspendLayout();
            // 
            // lstTools
            // 
            this.lstTools.FormattingEnabled = true;
            this.lstTools.Location = new System.Drawing.Point(12, 12);
            this.lstTools.Name = "lstTools";
            this.lstTools.Size = new System.Drawing.Size(142, 264);
            this.lstTools.TabIndex = 0;
            // 
            // dtgAddParams
            // 
            this.dtgAddParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAddParams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.paramName,
            this.paramValue});
            this.dtgAddParams.Location = new System.Drawing.Point(160, 12);
            this.dtgAddParams.Name = "dtgAddParams";
            this.dtgAddParams.Size = new System.Drawing.Size(315, 264);
            this.dtgAddParams.TabIndex = 1;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(400, 282);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(319, 282);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(238, 282);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // paramName
            // 
            this.paramName.HeaderText = "Название";
            this.paramName.Name = "paramName";
            // 
            // paramValue
            // 
            this.paramValue.HeaderText = "Значение";
            this.paramValue.Name = "paramValue";
            // 
            // frmNewParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 314);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.dtgAddParams);
            this.Controls.Add(this.lstTools);
            this.Name = "frmNewParameters";
            this.Text = "frmNewParameters";
            ((System.ComponentModel.ISupportInitialize)(this.dtgAddParams)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstTools;
        private System.Windows.Forms.DataGridView dtgAddParams;
        private System.Windows.Forms.DataGridViewTextBoxColumn paramName;
        private System.Windows.Forms.DataGridViewTextBoxColumn paramValue;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}