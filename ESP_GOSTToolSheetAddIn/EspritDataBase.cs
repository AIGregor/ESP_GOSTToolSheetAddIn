using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESP_GOSTToolSheetAddIn
{
    class EspritDataBase
    {

        bool Connection()
        {
            String currentMashineName;
            String newConnection = "";

            try
            {
                EspritXML settings = new EspritXML();
                if (settings.useLocalHost)
                {
                    currentMashineName = System.Environment.MachineName;
                    newConnection = string.Format("Data Source={0}\\KBMSS;Initial Catalog=KBM;Persist Security Info=True;User ID=sa;Password=KBMsa64125#", currentMashineName);
                }
                else
                {
                    currentMashineName = settings.hostName;
                    newConnection = string.Format("Data Source={0}\\KBMSS;Initial Catalog=KBM;Persist Security Info=True;User ID=sa;Password=KBMsa64125#", currentMashineName);
                }

                MessageBox.Show("Чтение файла настроек подключения к Базе Знаний выполнено успешно!", "Запуск", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception E)
            {
                MessageBox.Show("Не удалось прочитать файл настроек подключения к Базе Знаний! Текст ошибки:" + E.ToString(), "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                tblCuttingToolParameterTableAdapter.Connection.ConnectionString = newConnection;
                //String newConnection = @"Data Source=NICK-W7\KBMSS;Initial Catalog=KBM;Persist Security Info=True;User ID=sa;Password=KBMsa64125#";

                // TODO: This line of code loads data into the 'kBMDataSet.tblCuttingToolParameter' table. You can move, or remove it, as needed.
                this.tblCuttingToolParameterTableAdapter.Fill(this.kBMDataSet.tblCuttingToolParameter);
                // TODO: This line of code loads data into the 'kBMDataSet.tblCuttingToolParameter' table. You can move, or remove it, as needed.
                this.tblCuttingToolParameterTableAdapter.Fill(this.kBMDataSet.tblCuttingToolParameter);
                // TODO: This line of code loads data into the 'kBMDataSet.tblCuttingToolParameter' table. You can move, or remove it, as needed.
                this.tblCuttingToolParameterTableAdapter.Fill(this.kBMDataSet.tblCuttingToolParameter);

                MessageBox.Show("Подключение к Базе Знаний выполнено успешно!", "Запуск", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception E)
            {
                MessageBox.Show("Не удалось подключиться к Базе Знаний! Текст ошибки:" + E.ToString(), "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            toolStripMenuItem1.Checked = true;
            toolStripMenuItem1.ForeColor = Color.Green;
            tblCuttingToolParameterBindingSource.Filter = string.Format("[{0}] > {1}", "fldCLFileCode_tblCuttingToolParameter", 9990);

            MessageBox.Show("Настройка параметров графического окна выполнена успешно!", "Запуск", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
        }
    }
}
