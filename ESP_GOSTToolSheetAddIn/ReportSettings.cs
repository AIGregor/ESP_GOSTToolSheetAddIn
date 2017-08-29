using System;
using System.Xml;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
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

        //Загрузить имя хоста
        public void loadHostSettings()
        {
            if (hostName != "")
                return;

            // Загрузка
            XmlDocument docEspritHost = new XmlDocument();
            try
            {
                docEspritHost.Load(Connect.assemblyFolder + StringResource.xmlAddinSettingsName);
            }
            catch (Exception E)
            {
                Connect.logger.Error("Не удалось загрузить файл настроке плагина " + E.Message);
                MessageBox.Show("Не удалось загрузить файл настроек подключения к Базе Знаний! Текст ошибки:" + E.ToString(), "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Чтение
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
                Connect.logger.Error("Не удалось прочитать файл настроек плагина " + E.Message);
                MessageBox.Show("Не удалось прочитать файл настроек подключения к Базе Знаний! Текст ошибки:" + E.ToString(), "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузить все настройки
        public void loadAllSettings()
        {
            if (hostName != "")
                return;
            // Загрузка
            XmlDocument docEspritHost = new XmlDocument();
            try
            {
                docEspritHost.Load(Connect.assemblyFolder + StringResource.xmlAddinSettingsName);
            }
            catch (Exception E)
            {
                Connect.logger.Error("Не удалось загрузить файл настроек плагина " + E.Message);
                MessageBox.Show("Не удалось зфгрузить файл настроек подключения к Базе Знаний! Текст ошибки:" + E.ToString(), "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Чтение
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
                Connect.logger.Error("Ошибка чтения файла настроек " + E.Message);
            }
        }

        // Сохранить все настройки
        public void saveAllSettings()
        {
            Connect.logger.Info("Сохранение файла настроек");

            XmlDocument docEspritHost = new XmlDocument();
            try
            {
                docEspritHost.Load(Connect.assemblyFolder + StringResource.xmlAddinSettingsName);
            }
            catch (Exception E)
            {
                Connect.logger.Error("Ошибка загрузки настроке при сохранении " + E.Message);
                MessageBox.Show("Текст ошибки:" + E.ToString(), "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            foreach (XmlNode node in docEspritHost.DocumentElement)
            {
                node["HostName"].InnerText = hostName;
                node["LocalHost"].InnerText = useLocalHost.ToString();
                node["DefaultReportPath"].InnerText = defaultReportPath;
                node["DefaultReportName"].InnerText = defaultReportName;
            }
            docEspritHost.Save(Connect.assemblyFolder + StringResource.xmlAddinSettingsName);
        }


    }
}
