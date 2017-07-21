namespace ESP_GOSTToolSheetAddIn.Forms
{
    partial class CreateUserParameters
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserParameterName = new System.Windows.Forms.TextBox();
            this.btCreateUserParameter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название параметра";
            // 
            // txtUserParameterName
            // 
            this.txtUserParameterName.Location = new System.Drawing.Point(151, 12);
            this.txtUserParameterName.Name = "txtUserParameterName";
            this.txtUserParameterName.Size = new System.Drawing.Size(263, 20);
            this.txtUserParameterName.TabIndex = 1;
            // 
            // btCreateUserParameter
            // 
            this.btCreateUserParameter.Location = new System.Drawing.Point(172, 38);
            this.btCreateUserParameter.Name = "btCreateUserParameter";
            this.btCreateUserParameter.Size = new System.Drawing.Size(95, 23);
            this.btCreateUserParameter.TabIndex = 2;
            this.btCreateUserParameter.Text = "Создать";
            this.btCreateUserParameter.UseVisualStyleBackColor = true;
            this.btCreateUserParameter.Click += new System.EventHandler(this.btCreateUserParameter_Click);
            // 
            // CreateUserParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 68);
            this.Controls.Add(this.btCreateUserParameter);
            this.Controls.Add(this.txtUserParameterName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CreateUserParameters";
            this.Text = "Новый параметр";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserParameterName;
        private System.Windows.Forms.Button btCreateUserParameter;
    }
}