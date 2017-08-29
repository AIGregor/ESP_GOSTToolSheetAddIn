using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using EspritTechnology;
using ESP_GOSTToolSheetAddIn.Resources;
using NLog;

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
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Info("Show Main frame");

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
            Connect.sEspDocument = curDocument;
            currentTool = curDocument.Tools;
            // Идем по списку инструментов в документе
            foreach (Tool Tool in currentTool)
            {
                // Добавляем инструмент в массив отчета
                addReportTool(Tool);

                Technology toolTech = (Technology)Tool;
                string[] reportTool = new string[2];
                reportTool[0] = toolTech.Caption;
                reportTool[1] = toolTech.Name;

                ListViewItem newReportTool = new ListViewItem(reportTool);
                listDocumentTools.Items.Add(newReportTool);
            }
            // Заполнить таблицу параметров первого инструмента
            fillFormReportToolParameters(0);
        }

        // Добавить инструмент в список для отчета
        private void addReportTool(Tool newReportTool)
        {
            if (newReportTool == null)
                return;

            Trace.WriteLine("Tool style - " + newReportTool.ToolStyle);
            GostTool gostReportTool = new GostTool(AdditionalToolParameters.getGostTool( (int) newReportTool.ToolStyle));
            //gostReportTool = AdditionalToolParameters.getGostTool( (int) newReportTool.ToolStyle);
            
            // Сохраняем ID инструмента
            gostReportTool.toolDocumentID = newReportTool.ToolID;
            // Сохраняем Capture
            Technology toolTech = (Technology) newReportTool;
            gostReportTool.toolType = toolTech.Name;
            // Записать значения параметров из инструмента
            gostReportTool.addParametersValue(newReportTool);
            // Добавить инструмент для отчета в массив
            AdditionalToolParameters.gostReportToolsArray.Add(gostReportTool);                       
        }

        // Добавить параметры в форму 
        private void fillFormReportToolParameters(int index)
        { 
            if (AdditionalToolParameters.gostReportToolsArray.Count == 0)
                return;

            GostTool reportTool = AdditionalToolParameters.gostReportToolsArray[index];

            for (int j = 0; j < reportTool.parameters.Count(); j++)
            {
                //DataGridViewRow reportParameter = new DataGridViewRow();
                string strCapture = reportTool.parameters.getParameter(j).Capture;
                string strValue = reportTool.parameters.getParameter(j).Value;
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
                updateParametersFromForm();
            }

            dgvReportToolParameters.Rows.Clear();
            fillFormReportToolParameters(selectIndex[0]);
            // сохранили текущий выделлный инструмент из списка
            selectedToolIndex = selectIndex[0];

            Trace.Write("Fill form!\n");
        }

        //TODO: Обновить структуру данными по таблице
        private void updateParametersFromForm()
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

                ToolParameter oldToolParam = reportTool.parameters.getParameter(i);
                oldToolParam.Capture = dgvReportToolParameters.Rows[i].Cells[0].Value.ToString();
                oldToolParam.Value = dgvReportToolParameters.Rows[i].Cells[1].Value.ToString();
            }
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

            if (File.Exists(destFileName + destFileName))
            {
                destFileName = Connect.sEspDocument.Name + " " + destFileName;
                if (File.Exists(destFileFolder + destFileName))
                {
                    File.Delete(destFileFolder + destFileName);
                }
            }
            // Копировать рамку Excel в назначенную папку
            if (!CopyPatternFileTo(destFileFolder, destFileName))
                return;

            // Заполнение файла шаблона
            AdditionalToolParameters.gostReportFields.FillFileReport(destFileFolder + destFileName);
            //AdditionalToolParameters.gostReportFields.testAddNewSheet(distFileName);

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
                Connect.logger.Error("Ошибка при копировании " + E.Message);
                MessageBox.Show("Не удалось создать документ! Попробуйте изменить папку для сохранение. Текст ошибки:" + E.ToString(), "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DatabaseInterface dataBase = new DatabaseInterface();
            foreach (GostTool gostTool in AdditionalToolParameters.gostReportToolsArray)
            {
                dataBase.saveUserToolParams(gostTool);
            }            
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
                        currentToolParameter.Value = dataBase.getUsersParamValue(gostTool.dataBaseToolID, currentToolParameter.CLCode);
                    }
                }
            }
        }

        private void MenuItemHelpAbout_Click(object sender, EventArgs e)
        {
            About dlgAbout = new About();
            dlgAbout.Show();
        }
    }
    // end class
}
