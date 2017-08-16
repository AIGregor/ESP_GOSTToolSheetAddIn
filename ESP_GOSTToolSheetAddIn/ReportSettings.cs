using Microsoft.Win32;
using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ESP_GOSTToolSheetAddIn
{
    /// <summary>
    /// Класс хранения и обработки настроек плагина
    /// Все настройки хранятся в разделе реестра 
    /// HKEY_CURRENT_USER\Software\D.P.Technology\esprit\AddInSettings\ESPRIT.ReportGost31404-86
    /// </summary>
    class ReportSettings
    {
        private string reportPath = "";
        private string defaultReportName = "";

        public bool useLocalHost = true;
        public string hostName = "";

        public string ReportPath
        {
            get
            {
                return reportPath;
            }

            set
            {
                reportPath = value;
            }
        }

        public string DefaultReportName
        {
            get
            {
                return defaultReportName;
            }

            set
            {
                defaultReportName = value;
            }
        }

        public ReportSettings()
        {
        }

        public void saveSettings()
        {
        }

        public void loadHostSettings()
        {
            XmlDocument docEspritHost = new XmlDocument();
            try
            {
                docEspritHost.Load("./Resources/ServerName.xml");
            }
            catch (Exception E)
            {
                //MessageBox.Show("Не удалось ЗАГРУЗИТЬ файл настроек подключения к Базе Знаний! Текст ошибки:" + E.ToString(), "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                foreach (XmlNode node in docEspritHost.DocumentElement)
                {
                    hostName = node["HostName"].InnerText;
                    useLocalHost = bool.Parse(node["LocalHost"].InnerText);
                }
            }
            catch (Exception E)
            {
                //MessageBox.Show("Не удалось выполнить чтение параметров настроек подключения! Текст ошибки:" + E.ToString(), "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
