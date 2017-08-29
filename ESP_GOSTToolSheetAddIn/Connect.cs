﻿using System;
using Extensibility;
using System.Runtime.InteropServices;
using System.IO;
using ESP_GOSTToolSheetAddIn.Resources;
using ESP_GOSTToolSheetAddIn.Forms;
using System.Windows.Forms;
using NLog;

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

        static public Logger logger = LogManager.GetCurrentClassLogger();

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
            ConfigureLogger();

            sEspApp = (Esprit.Application)Application;
            sEspDocument = sEspApp.Document;
            sAddIn = sEspApp.AddIn;
            sCookie = sAddIn.GetCookie();

            logger.Info("Подключение плагина");

            //Защита !!!------------------- 
            SecurityFile security = new SecurityFile();
            if (!security.mergeLicFiles())
            {
                logger.Error("Не найдена лицензия");
                MessageBox.Show(StringResource.msgErrorSecurityAccess, "Лицензия",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Защита !!!-------------------  

            logger.Info("Лицензия найдена");

            newCommand = sAddIn.AddCommand(sCookie, 1, StringResource.menuName);

            EspritMenus.Menus allMenu = sEspApp.Menus;
            fileMenu = allMenu[1]; // Меню "Файл"
            // добавляем команду в меню
            fileMenu.Add(EspritConstants.espMenuItemType.espMenuItemCommand, StringResource.menuName, newCommand, 18);
            logger.Info("Добавлен новый пункт меню");
            // привязываем вызов команды к обработчику
            sAddIn.OnCommand += OnCommand;

            //Загрузить все настроки плагина
            logger.Info("Загрузка настроек плагина");
            AdditionalToolParameters.gostReportSettings.loadAllSettings();

            Marshal.ReleaseComObject(allMenu);
        }

        // Открыть главное окно
        void showReportMainFrame()
        {
            // Проверка файла-шаблона
            if (!File.Exists(StringResource.xmlPathToolsParams))
            {
                logger.Info("Создание файла шаблона параметров инструмента");
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
            logger.Info("Отключение плагина");
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
                logger.Info("Вызов команды Показать Главное окно");
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

        private void ConfigureLogger()
        {
            logger.Info("Конфигурирование логирования");

            // Step 1. Create configuration object 
            var config = new NLog.Config.LoggingConfiguration();

            // Step 2. Create targets and add them to the configuration 
            var fileTarget = new NLog.Targets.FileTarget();
            config.AddTarget("File", fileTarget);

            // Step 3. Set target properties
            fileTarget.FileName = Directory.GetCurrentDirectory() + @"\logs\${shortdate}.log";
            fileTarget.Layout = "${longdate} ${uppercase:${level}} ${callsite} | ${message}";

            // Step 4. Define rules
            var rule1 = new NLog.Config.LoggingRule("*", LogLevel.Debug, fileTarget);
            config.LoggingRules.Add(rule1);

            // Step 5. Activate the configuration
            LogManager.Configuration = config;
        }

    }
}
