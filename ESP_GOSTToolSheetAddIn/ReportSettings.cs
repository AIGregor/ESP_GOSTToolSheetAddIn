using Microsoft.Win32;
using System;
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
            RegistryKey currentUserKey = Registry.CurrentUser;

            currentUserKey.OpenSubKey("Software\\D.P.Technology\\esprit\\AddInSettings");
            currentUserKey.CreateSubKey("ESPRIT.ReportGost31404-86");
            currentUserKey.SetValue("defaultRaportPath", ReportPath);
            currentUserKey.SetValue("defaultRaportName", DefaultReportName);

            currentUserKey.Close();
        }

    }
}
