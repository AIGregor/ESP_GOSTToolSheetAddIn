using Microsoft.Win32;
using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESP_GOSTToolSheetAddIn.Resources;

namespace ESP_GOSTToolSheetAddIn
{
    /// <summary>
    /// Класс хранения и обработки настроек плагина
    /// Все настройки хранятся в XML файле
    /// </summary>
    class ReportSettings
    {
        private string defaultReportPath = "";
        private string defaultReportName = "";

        public bool useLocalHost = true;
        public string hostName = "";

        public string DefaultReportPath
        {
            get
            {
                return defaultReportPath;
            }

            set
            {
                defaultReportPath = value;
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
            if (hostName != "")
                return;

            XmlDocument docEspritHost = new XmlDocument();
            try
            {
                docEspritHost.Load(StringResource.xmlAddinSettingsName);
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

        // Загрузить все настройки
        public void loadAllSettings()
        {
            if (hostName != "")
                return;

            XmlDocument docEspritHost = new XmlDocument();
            try
            {
                docEspritHost.Load(StringResource.xmlAddinSettingsName);
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
                    defaultReportPath = node["DefaultReportPath"].InnerText;
                    defaultReportName = node["DefaultReportName"].InnerText;
                }
            }
            catch (Exception E)
            {
                //MessageBox.Show("Не удалось выполнить чтение параметров настроек подключения! Текст ошибки:" + E.ToString(), "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Сохранить все настройки
        public void saveAllSettings()
        {
            XmlDocument docEspritHost = new XmlDocument();
            try
            {
                docEspritHost.Load(StringResource.xmlAddinSettingsName);
            }
            catch (Exception E)
            {
                //MessageBox.Show("Текст ошибки:" + E.ToString(), "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            foreach (XmlNode node in docEspritHost.DocumentElement)
            {
                node["HostName"].InnerText = hostName;
                node["LocalHost"].InnerText = useLocalHost.ToString();
                node["DefaultReportPath"].InnerText = defaultReportPath;
                node["DefaultReportName"].InnerText = defaultReportName;
            }
            docEspritHost.Save(StringResource.xmlAddinSettingsName);
        }


    }
}
