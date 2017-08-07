using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using EspritTechnology;
using ESP_GOSTToolSheetAddIn.Resources;

namespace ESP_GOSTToolSheetAddIn.Forms
{
    public partial class MainFrame : Form
    {
        EspritTools.Tools currentTool;

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
            InitMainForm();
        }

        // Заполнение главного окна
        private void InitMainForm()
        {
            // Загружаем параметры инструменты из файла
            AdditionalToolParameters.LoadToolsParameters();
            // Собираем инструмент из текущего документа
            Esprit.Document curDocument = Connect.sEspApp.Document;
            currentTool = curDocument.Tools;
            // Идум по списку инструментов в документе
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
            // Заполнить 
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
                String strCapture = reportTool.parameters.getParameter(j).Capture;
                String strValue = reportTool.parameters.getParameter(j).Value;
                dgvReportToolParameters.Rows.Add(strCapture, strValue);
            }   
        }

        // Загружаем парметры выбранного инструмента
        private void listDocumentTools_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection selectIndex = listDocumentTools.SelectedIndices;
            dgvReportToolParameters.Rows.Clear();
            fillFormReportToolParameters(selectIndex[0]);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Копировать рамку Excel в назначенную папку

            // Заполнить файл данными параметров интсрументов

            // Если записываем название инструмента, объединяем несколько областей

            // Сохранить файл

        }

        private void CopyPatternFile(String destinationFileName)
        {
            FileInfo copyFI = new FileInfo(StringResource.excelReportFile);
        }

    }
}
