using System;
using System.Windows.Forms;
using System.Diagnostics;
using EspritTechnology;

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
            frmSettingsToolsParams.Show();
        }

        // Перед тем как показать форму считываем инструмент из файла и заполняем поля
        private void MainFrame_Shown(object sender, EventArgs e)
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

                Technology toolTech = (Technology) Tool;
                string[] reportTool = new string[2];
                reportTool[0] = toolTech.Caption;
                reportTool[1] = toolTech.Name;

                ListViewItem newReportTool = new ListViewItem(reportTool);
                listDocumentTools.Items.Add(newReportTool);
            }
        }

        // Добавить инструмент в список для отчета
        private void addReportTool(Tool newReportTool)
        {
            Trace.WriteLine("Tool style - " + newReportTool.ToolStyle);
            GostTool gostReportTool = AdditionalToolParameters.getGostTool( (int) newReportTool.ToolStyle);
            // Сохраняем ID инструмента
            gostReportTool.toolDocumentID = newReportTool.ToolID;
            // Сохраняем Capture
            Technology toolTech = (Technology) newReportTool;
            gostReportTool.toolType = toolTech.Name;

            addValue(newReportTool, gostReportTool);
            AdditionalToolParameters.gostReportToolsArray.Add(gostReportTool);
        }

        // Записываем значение параметра из документа в структуру
        private void addValue(Tool newRepotTool, GostTool toolParams)
        {
            for (int i = 0; i < toolParams.parameters.Count(); i++)
            {
                Technology reportTechTool = (Technology) newRepotTool;
                Parameter curParam = reportTechTool[toolParams.parameters.getParameter(i).Name];
                toolParams.parameters.getParameter(0).Value = Convert.ToString(curParam.Value);
            }
        }

        // Добавить параметры в форму 
        private void fillFormReportToolParameters(int index)
        {
            GostTool reportTool = AdditionalToolParameters.gostReportToolsArray[index];

            for (int j = 0; j < reportTool.parameters.Count(); j++)
            {
                DataGridViewRow reportParameter = new DataGridViewRow();
                reportParameter.Cells[0].Value = reportTool.parameters.getParameter(j).Capture;
                reportParameter.Cells[1].Value = reportTool.parameters.getParameter(j).Value;
                dgvReportToolParameters.Rows.Add(reportParameter);
            }   
        }



    }
}
