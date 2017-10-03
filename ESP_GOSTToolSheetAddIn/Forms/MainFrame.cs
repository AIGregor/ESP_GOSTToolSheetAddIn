using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using EspritTechnology;
using ESP_GOSTToolSheetAddIn.Resources;
using System.Collections.Generic;

namespace ESP_GOSTToolSheetAddIn.Forms
{
    public partial class MainFrame : Form
    {
        EspritTools.Tools currentTool;
        private int selectedToolIndex = 0;

        public MainFrame()
        {
            InitializeComponent();
        }
        private void ShowPatternFileMenuItem_Click(object sender, EventArgs e)
        {
            frmEspToolsParameters frmSettingsToolsParams = new frmEspToolsParameters();
            frmSettingsToolsParams.ShowDialog();
        }
        // Перед тем как показать форму считываем инструмент из файла и заполняем поля
        private void MainFrame_Shown(object sender, EventArgs e)
        {
            Connect.logger.Info("Выполнение отображения Главного окна");

            InitMainForm();
            // Заполняем поля для шапки
            fillHatsFields(); 
        }
        private void fillHatsFields()
        {
            AdditionalToolParameters.gostReportFields.getFIOFieldsFromDocument();

            tbFIOCheck.Text         = AdditionalToolParameters.gostReportFields.FIOChecker; 
            tbFIODev.Text           = AdditionalToolParameters.gostReportFields.FIODev;
            tbFIOControl.Text       = AdditionalToolParameters.gostReportFields.FIONormChecker;
            tbFIOAccept.Text        = AdditionalToolParameters.gostReportFields.FIOAccepter;
            tbDetailSign.Text       = AdditionalToolParameters.gostReportFields.DetailDesignation;
            tbDetailName.Text       = AdditionalToolParameters.gostReportFields.DetailName;
            tbCncMachineName.Text   = AdditionalToolParameters.gostReportFields.CNCMachineName;
            tbCNCName.Text          = AdditionalToolParameters.gostReportFields.CNCProgName;
            tbCompanyName.Text      = AdditionalToolParameters.gostReportFields.CompanyName;
        }
        // Заполнение главного окна
        private void InitMainForm()
        {
            // Очистка данных из прошлого сеанса
            AdditionalToolParameters.gostReportToolsArray.Clear();

            // Загружаем параметры инструмента из файла
            AdditionalToolParameters.LoadToolsParameters();

            // Собираем инструмент из текущего документа
            Esprit.Document curDocument = Connect.sEspApp.Document;

            if (curDocument == null)
            {
                Connect.logger.Error("Инициализация формы: пустая ссылка на документ");
            }                

            Connect.sEspDocument = curDocument;
            //currentTool = curDocument.Tools;
            currentTool = getOperationTools();

            // Идем по списку инструментов в документе
            foreach (Tool Tool in currentTool)
            {
                // Добавляем инструмент в массив отчета
                Connect.logger.Info("Инициализация главного окна. Добавление инструмента в список для отчета");
                addReportTool(Tool);
                Connect.logger.Info("Инициализация главного окна. Инструмент обавлен в список для отчета");

                Technology toolTech = (Technology)Tool;
                string[] reportTool = new string[2];
                reportTool[0] = toolTech.Caption;
                reportTool[1] = toolTech.Name;

                ListViewItem newReportTool = new ListViewItem(reportTool);
                Connect.logger.Info("Инициализация главного окна. Добавление инструмента на форму");
                listDocumentTools.Items.Add(newReportTool);
            }

            // Заполнить таблицу параметров первого инструмента
            Connect.logger.Info("Инициализация главного окна. Заполнение параметров первого инструмента");
            fillFormReportToolParameters(0);
        }
        /// <summary>
        /// Получить список инструментов из операций в документе
        /// </summary>
        /// <returns></returns>
        private EspritTools.Tools getOperationTools()
        {
            EspritTools.Tools reportTools = new EspritTools.Tools();
            HashSet<string> operationToolSet = new HashSet<string>();

            foreach (Esprit.Operation operation in Connect.sEspDocument.Operations)
            {
                if (!operation.Suppress) // Только не подавленные операции
                {
                    Technology operationTech = operation.Technology;
                    Parameter toolId = operationTech["ToolId"];

                    // Пропускаем повторно используемый инструмент
                    if (operationToolSet.Contains(toolId.Value))
                        continue;
                                                                               
                    foreach (Tool docTool in Connect.sEspDocument.Tools)
                    {
                        if (string.Equals(docTool.ToolID, toolId.Value))
                        {
                            reportTools.Add(docTool);
                            operationToolSet.Add(toolId.Value);
                        }
                    }
                }
            }
            return reportTools;
        }

        // Добавить инструмент в список для отчета
        private void addReportTool(Tool newReportTool)
        {
            if (newReportTool == null)
                return;

            Connect.logger.Info(String.Format("Инициализация главного окна. Добавление инструмента : {0}", newReportTool.ToolID));

            GostTool gostReportTool = new GostTool(AdditionalToolParameters.getGostTool( (int) newReportTool.ToolStyle));
            //gostReportTool = AdditionalToolParameters.getGostTool( (int) newReportTool.ToolStyle);
            if (gostReportTool == null)
                return;

            // Сохраняем ID инструмента
            gostReportTool.toolDocumentID = newReportTool.ToolID;
            // Сохраняем Capture
            Technology toolTech = (Technology) newReportTool;
            gostReportTool.toolType = toolTech.Name;

            // Записать значения параметров из инструмента
            Connect.logger.Info("Загрузка значений параметров");
            gostReportTool.addParametersValue(newReportTool);

            // Добавить инструмент для отчета в массив
            Connect.logger.Info("Добавление инструмента в список для отчета");
            AdditionalToolParameters.gostReportToolsArray.Add(gostReportTool);                       
        }
        // Добавить параметры в форму 
        private void fillFormReportToolParameters(int index)
        { 
            if (AdditionalToolParameters.gostReportToolsArray.Count == 0)
                return;

            GostTool reportTool = AdditionalToolParameters.gostReportToolsArray[index];
            Connect.logger.Info(String.Format("Заполнение параметров инструмента: {0}", reportTool.toolDocumentID));

            for (int j = 0; j < reportTool.parameters.Count(); j++)
            {
                //DataGridViewRow reportParameter = new DataGridViewRow();
                string strCapture = reportTool.parameters.getParameter(j).Capture;
                string strValue = reportTool.parameters.getParameter(j).Value;

                if (dgvReportToolParameters != null)
                    dgvReportToolParameters.Rows.Add(strCapture, strValue);
            }
        }
        // Загружаем парметры выбранного инструмента
        private void listDocumentTools_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection selectIndex = listDocumentTools.SelectedIndices;
            
            // Сохраняем измененные параметры во внутреннюю структуру
            if (selectedToolIndex != selectIndex[0])
            {
                // Есть пустые поля в таблице 
                if (!updateParametersFromForm())
                    return;                
            }

            dgvReportToolParameters.Rows.Clear();
            fillFormReportToolParameters(selectIndex[0]);
            // сохранили текущий выделлный инструмент из списка
            selectedToolIndex = selectIndex[0];

            Trace.Write("Fill form!\n");
        }
        //TODO: Обновить структуру данными по таблице
        private bool updateParametersFromForm()
        {
            GostTool reportTool = AdditionalToolParameters.gostReportToolsArray[selectedToolIndex];

            for (int i = 0; i < dgvReportToolParameters.Rows.Count-1; i++)
            {
                // пользователь добавил новый параметр
                if (reportTool.parameters.Count() - 1 < i)
                {
                    ToolParameter reportUserToolParam = new ToolParameter();
                    reportUserToolParam.Capture = dgvReportToolParameters.Rows[i].Cells[0].Value.ToString();
                    reportUserToolParam.Value = dgvReportToolParameters.Rows[i].Cells[1].Value.ToString();
                    reportTool.parameters.AddParameter(reportUserToolParam);

                    continue;
                }

                object objCapture = dgvReportToolParameters.Rows[i].Cells[0].Value;
                object objValue = dgvReportToolParameters.Rows[i].Cells[1].Value;

                if (objValue == null || objCapture == null)
                {
                    MessageBox.Show("Некоторые параметры инструмента не заданы. Введите новое значение. ", "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                                
                ToolParameter oldToolParam = reportTool.parameters.getParameter(i);
                oldToolParam.Capture = objCapture.ToString();
                oldToolParam.Value = objValue.ToString();
            }
            return true;
        }        
        // Генерация карты наладки
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            ReportSettings settings = AdditionalToolParameters.gostReportSettings; 
            GenerateFileReport(settings.DefaultReportPath, settings.DefaultReportName);
        }
        private void openReport(string filePath)
        {
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = filePath;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }
        private void GenerateFileReport(string destFileFolder, string destFileName)
        {
            Connect.logger.Info("Генерация карты наладки инструмента");

            if (File.Exists(destFileFolder + destFileName))
            {
                DialogResult result = MessageBox.Show(
                    "Файл с таким именем уже существует. Заменить файл ?", 
                    "Предупреждение", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.No)
                    return;
                try
                {
                    File.Delete(destFileFolder + destFileName);
                }
                catch (Exception E)
                {
                    Connect.logger.Error("Ошибка удаления файла карты наладки");
                    if (E is UnauthorizedAccessException)
                    {
                        Connect.logger.Error("Не достаточно прав для доступа к папке сохранения.");
                        MessageBox.Show("Не удалось создать документ!\nНе достаточно прав для доступа к папке сохранения.\n\nПопробуйте изменить папку для сохранение.", "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }                
            }
            // Копировать рамку Excel в назначенную папку
            if (!CopyPatternFileTo(destFileFolder, destFileName))
                return;

            // Заполнение файла шаблона
            AdditionalToolParameters.gostReportFields.FillFileReport(destFileFolder + destFileName);

            openReport(destFileFolder + destFileName);
        }
        private bool CopyPatternFileTo(string destFileFolder, string destFileName)
        {
            FileInfo copyFI = new FileInfo(Connect.assemblyFolder + StringResource.excelTemplateReportFile);

            Connect.logger.Info("Копировать из " + Connect.assemblyFolder + StringResource.excelTemplateReportFile + 
                " в " + destFileFolder + destFileName);
            try
            {
                copyFI.CopyTo(destFileFolder + destFileName);
            }
            catch (Exception E)
            {
                Connect.logger.Error("Не достаточно прав для доступа к папке сохранения.");
                if (E is UnauthorizedAccessException)
                {
                    MessageBox.Show("Не удалось создать документ!\nНе достаточно прав для доступа к папке сохранения.\n\nПопробуйте изменить папку для сохранение.", "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            return true;
        }
        private void MenuItemReportSetting_Click(object sender, EventArgs e)
        {
            frmReportSettings reportSettings = new frmReportSettings();
            reportSettings.ShowDialog();
        }
        private void tbFIODev_Leave(object sender, EventArgs e)
        {
            AdditionalToolParameters.gostReportFields.FIODev = tbFIODev.Text;
        }
        private void tbFIOCheck_Leave(object sender, EventArgs e)
        {
            AdditionalToolParameters.gostReportFields.FIOChecker = tbFIOCheck.Text;
        }
        private void tbFIOAccept_Leave(object sender, EventArgs e)
        {
            AdditionalToolParameters.gostReportFields.FIOAccepter = tbFIOAccept.Text;
        }
        private void tbFIOControl_Leave(object sender, EventArgs e)
        {
            AdditionalToolParameters.gostReportFields.FIONormChecker = tbFIOControl.Text;
        }
        private void tbCompanyName_Leave(object sender, EventArgs e)
        {
            AdditionalToolParameters.gostReportFields.CompanyName = tbCompanyName.Text;
        }
        private void tbDetailName_Leave(object sender, EventArgs e)
        {
            AdditionalToolParameters.gostReportFields.DetailName = tbDetailName.Text;
        }
        private void tbDetailSign_Leave(object sender, EventArgs e)
        {
            AdditionalToolParameters.gostReportFields.DetailDesignation = tbDetailSign.Text;
        }
        private void tbCNCName_Leave(object sender, EventArgs e)
        {
            AdditionalToolParameters.gostReportFields.CNCProgName = tbCNCName.Text;
        }
        private void tbCncMachineName_Leave(object sender, EventArgs e)
        {
            AdditionalToolParameters.gostReportFields.CNCMachineName = tbCncMachineName.Text;
        }
        // Кнопка на форме - сохранить все пользовательские параметры всех инструментов отчета в БД
        private void MenuItemSaveDataBase_Click(object sender, EventArgs e)
        {
            //Сохранить параметры из формы для теккущего документа
            Connect.logger.Info("Сохранение значений параметров в БД. Сохранение значений введенных в форму");
            if (!updateParametersFromForm())
                return;

            //Сохранить в БД
            DatabaseInterface dataBase = new DatabaseInterface();
            foreach (GostTool gostTool in AdditionalToolParameters.gostReportToolsArray)
            {
                Connect.logger.Info("Сохранение значений параметров в БД. Сохранение значений параметров инструмента : " + gostTool.toolDocumentID);
                bool result = dataBase.saveUserToolParams(gostTool);

                if (!result)
                    Connect.logger.Warning(string.Format("Пользовательские параметры инструмента с ID {0} не сохранены !", gostTool.toolDocumentID));
            }
            //Информирование о завершении сохранения
            MessageBox.Show("Сохранение в Базу Знаний завершено.", "База Знаний Esprit", MessageBoxButtons.OK, MessageBoxIcon.Information);          
        }
        // Кнопка на форме - загрузить все пользовательские параметры для всех инструментов из БД
        private void MenuItemUpdataDataBase_Click(object sender, EventArgs e)
        {
            DatabaseInterface dataBase = new DatabaseInterface();
            foreach (GostTool gostTool in AdditionalToolParameters.gostReportToolsArray)
            {
                for (int i = 0; i < gostTool.parameters.Count(); i++)
                {
                    ToolParameter currentToolParameter = gostTool.parameters.getParameter(i);
                    // Загрузить значение пользовательских параметров из базы данных
                    if (String.Equals(currentToolParameter.Type, StringResource.xmlParamUserType))
                    {
                        // TODO: Чтение парметров из БД, заполнение значения
                        string strResult = dataBase.getUsersParamValue(gostTool.dataBaseToolID, currentToolParameter.CLCode);
                        if (strResult != null)
                            currentToolParameter.Value = strResult;
                    }
                }
            }
            //очистить форму от старых записей
            dgvReportToolParameters.Rows.Clear();

            //заполнить форму после загрузки параметров из БД
            fillFormReportToolParameters(selectedToolIndex);
            
            //Информирование о завершении загрузки
            MessageBox.Show("Загрузка из Базы Знаний завершена.", "База Знаний Esprit", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void MenuItemHelpAbout_Click(object sender, EventArgs e)
        {
            About dlgAbout = new About();
            dlgAbout.Show();
        }
        private void btnSaveInFile_Click(object sender, EventArgs e)
        {
            Connect.sEspDocument.Save();
        }
    }
    // end class
}
