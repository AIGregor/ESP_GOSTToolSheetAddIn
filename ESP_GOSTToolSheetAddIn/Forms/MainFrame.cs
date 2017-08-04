using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESP_GOSTToolSheetAddIn.Forms
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
        }

        private void ShowPatternFileMenuItem_Click(object sender, EventArgs e)
        {
            frmEspToolsParameters frmSettingsToolsParams = new frmEspToolsParameters();
            frmSettingsToolsParams.Show();
        }
    }
}
