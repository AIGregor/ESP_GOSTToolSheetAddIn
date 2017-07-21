using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESP_GOSTToolSheetAddIn.Resources;

namespace ESP_GOSTToolSheetAddIn.Forms
{
    public partial class CreateUserParameters : Form
    {
        frmEspToolsParameters m_parentFrame;

        public CreateUserParameters()
        {
            InitializeComponent();
        }

        public CreateUserParameters(Form parentFrame)
        {
            m_parentFrame = (frmEspToolsParameters) parentFrame;
            InitializeComponent();
        }

        private void btCreateUserParameter_Click(object sender, EventArgs e)
        {
            if (txtUserParameterName.Text != "")
                m_parentFrame.addNewUserParameter(txtUserParameterName.Text);
            else
                MessageBox.Show(StringResource.msgNewParamError);

            this.Close();
        }
        
    }
}
