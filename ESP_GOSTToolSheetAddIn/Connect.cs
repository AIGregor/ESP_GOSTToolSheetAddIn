using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensibility;
using System.Runtime.InteropServices;
using System.IO;
using ESP_GOSTToolSheetAddIn.Resources;
using ESP_GOSTToolSheetAddIn.Forms;
using EspritCommands;
using System.Windows.Forms;

namespace ESP_GOSTToolSheetAddIn
{
    /// <summary>
    ///  Главный класс подключение плагина ESPRIT
    /// </summary>
    [ProgId("ESP_GOSTToolSheetAddIn.Connect"),
       Guid("878742AB-E143-4841-8BAB-1B1CFE7BAC5E"),
       ClassInterface(ClassInterfaceType.None), ComVisible(true)]
    public class Connect : IDTExtensibility2, EspritCommands._IAddInEvents
    {
        int sCookie = 0;
        int newCommand = 0;
        /// <summary>
        /// Объект запущенной программы ESPRIT
        /// </summary>
        static public Esprit.Application sEspApp;
        static public Esprit.Document sEspDocument;
        EspritCommands.AddIn sAddIn;
        EspritMenus.Menu fileMenu;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custom"></param>
        public void OnAddInsUpdate(ref Array custom)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custom"></param>
        public void OnBeginShutdown(ref Array custom)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        ///     Действия выполняемые при загрузки плагина
        /// </summary>
        /// <param name="Application"></param>
        /// <param name="ConnectMode"></param>
        /// <param name="AddInInst"></param>
        /// <param name="custom"></param>
        public void OnConnection(object Application, ext_ConnectMode ConnectMode, object AddInInst, ref Array custom)
        {
            sEspApp = (Esprit.Application)Application;
            sEspDocument = sEspApp.Document;
            sAddIn = sEspApp.AddIn;
            sCookie = sAddIn.GetCookie();

            //Защита !!!------------------- 
            SecurityFile security = new SecurityFile();
            if (!security.mergeLicFiles())
            {
                MessageBox.Show(StringResource.msgErrorSecurityAccess, "Лицензия",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Защита !!!-------------------  

            newCommand = sAddIn.AddCommand(sCookie, 1, StringResource.menuName);

            EspritMenus.Menus allMenu = sEspApp.Menus;
            fileMenu = allMenu[1]; // Меню "Файл"
            // добавляем команду в меню
            fileMenu.Add(EspritConstants.espMenuItemType.espMenuItemCommand, StringResource.menuName, newCommand, 18);
            // привязываем вызов команды к обработчику
            sAddIn.OnCommand += OnCommand;

            //Загрузить все настроки плагина
            AdditionalToolParameters.gostReportSettings.loadAllSettings();

           Marshal.ReleaseComObject(allMenu);
        }

        // Открыть главное окно
        void showReportMainFrame()
        {
            // Проверка файла-шаблона
            if (!File.Exists(StringResource.xmlPathToolsParams))
            {
                AdditionalToolParameters.creatPatternFile(StringResource.xmlPathToolsParams);
            }
            MainFrame mainFrame = new MainFrame();
            mainFrame.Show();
        }

        /// <summary>
        ///     Действия выполняемые при отключении плагина, при закрытии приложения
        /// </summary>
        /// <param name="RemoveMode"></param>
        /// <param name="custom"></param>
        public void OnDisconnection(ext_DisconnectMode RemoveMode, ref Array custom)
        {
            fileMenu.Remove(StringResource.menuName);
            Marshal.ReleaseComObject(fileMenu);
            Marshal.ReleaseComObject(sAddIn);
            Marshal.ReleaseComObject(sEspApp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custom"></param>
        public void OnStartupComplete(ref Array custom)
        {
            //throw new NotImplementedException();
        }

        //
        /// <summary>
        /// Выполнение действий по команде в главном меню
        /// </summary>
        /// <param name="Cookie"></param>
        /// <param name="UserId"></param>
        public void OnCommand(int Cookie, int UserId)
        {
            if (Cookie == sCookie)
            {
                showReportMainFrame();
            }
        }

        /// <summary>
        /// Изменение доступности команды меню в зависимости от условий
        /// </summary>
        /// <param name="Cookie"></param>
        /// <param name="UserId"></param>
        /// <param name="Enabled"></param>
        /// <param name="Checked"></param>
        public void OnCommandUI(int Cookie, int UserId, ref bool Enabled, ref bool Checked)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Контекстная справка
        /// </summary>
        /// <param name="Cookie"></param>
        /// <param name="UserId"></param>
        public void OnContextHelp(int Cookie, int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
