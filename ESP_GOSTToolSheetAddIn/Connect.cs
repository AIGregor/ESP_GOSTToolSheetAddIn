using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensibility;
using System.Runtime.InteropServices;
using System.IO;
using ESP_GOSTToolSheetAddIn.Resources;

namespace ESP_GOSTToolSheetAddIn
{
    /// <summary>
    ///  Главный класс подключение плагина ESPRIT
    /// </summary>
    [ProgId("ESP_GOSTToolSheetAddIn.Connect"),
       Guid("878742AB-E143-4841-8BAB-1B1CFE7BAC5E"),
       ClassInterface(ClassInterfaceType.None), ComVisible(true)]
    public class Connect : IDTExtensibility2
    {
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
            // Проверка файла-шаблона
            if (!File.Exists(StringResource.xmlPathToolsParams))
            {
                AdditionalToolParameters.creatPatternFile(StringResource.xmlPathToolsParams);
            }

            frmEspToolsParameters frmSettingsToolsParams = new frmEspToolsParameters();
            frmSettingsToolsParams.Show();            
        }

        /// <summary>
        ///     Действия выполняемые при отключении плагина, при закрытии приложения
        /// </summary>
        /// <param name="RemoveMode"></param>
        /// <param name="custom"></param>
        public void OnDisconnection(ext_DisconnectMode RemoveMode, ref Array custom)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custom"></param>
        public void OnStartupComplete(ref Array custom)
        {
            //throw new NotImplementedException();
        }
    }
}
