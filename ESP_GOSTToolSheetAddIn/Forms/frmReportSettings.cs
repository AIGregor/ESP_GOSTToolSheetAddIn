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
    public partial class frmReportSettings : Form
    {
        public frmReportSettings()
        {
            InitializeComponent();
        }

        private void btnSelectDistFolder_Click(object sender, EventArgs e)
        {
            dlgDistFolderBrowser.ShowDialog();
            tbReportField.Text = dlgDistFolderBrowser.SelectedPath + @"\";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            AdditionalToolParameters.gostReportSettings.DefaultReportPath = tbReportField.Text;
            AdditionalToolParameters.gostReportSettings.DefaultReportName = tbDefaultReportName.Text;
            AdditionalToolParameters.gostReportSettings.useLocalHost = !cbRemoteHost.Checked;
            AdditionalToolParameters.gostReportSettings.sqlServerName = tbSQLServerName.Text;

            if (cbRemoteHost.Checked)
                AdditionalToolParameters.gostReportSettings.hostName = tbHostName.Text;
            
            // Сохранить все настройки
            AdditionalToolParameters.gostReportSettings.saveAllSettings();
            // Закрыть форму
            Close();
        }

        private void frmReportSettings_Load(object sender, EventArgs e)
        {
            tbReportField.Text = AdditionalToolParameters.gostReportSettings.DefaultReportPath;
            tbDefaultReportName.Text = AdditionalToolParameters.gostReportSettings.DefaultReportName;
            tbSQLServerName.Text = AdditionalToolParameters.gostReportSettings.sqlServerName;

            if (AdditionalToolParameters.gostReportSettings.useLocalHost)
                tbHostName.Text = "";
            else
                tbHostName.Text = AdditionalToolParameters.gostReportSettings.hostName;

            cbRemoteHost.Checked = !AdditionalToolParameters.gostReportSettings.useLocalHost;

            tbHostName.Enabled = cbRemoteHost.Checked;
            btnTestConnection.Enabled = cbRemoteHost.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbRemoteHost_CheckedChanged(object sender, EventArgs e)
        {
            tbHostName.Enabled = cbRemoteHost.Checked;
            btnTestConnection.Enabled = cbRemoteHost.Checked;
        }

        private void tbDefaultReportName_MouseLeave(object sender, EventArgs e)
        {
            string result = tbDefaultReportName.Text;
            if (result.IndexOf(".xlsx") < 0)
            {
                tbDefaultReportName.Text = tbDefaultReportName.Text + ".xlsx";
            }
        }


        /// <summary>
        /// Тестирование соединения с базой данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            DatabaseInterface dataBase = new DatabaseInterface();

            if (dataBase.testConnection())
            {
                MessageBox.Show("Соединение успешно установлено.", "Тестирование соединения", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось подключиться к Базе Знаний", "Тестирование соединения", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
