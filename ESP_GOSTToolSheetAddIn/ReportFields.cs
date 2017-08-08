using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESP_GOSTToolSheetAddIn.Resources;
using Excel = Microsoft.Office.Interop.Excel;

namespace ESP_GOSTToolSheetAddIn
{
    class ReportFields
    {
        public String FIODev;
        public String FIOChecker;
        public String FIOAccepter;
        public String FIONormChecker;

        public String CompanyName;
        public String DetailName;
        public String DetailDesignation;
        public String CNCProgName;
        public String CNCMachineName;

        private int currentNumber = 0;
        private int currentRow = 15; // Начальная строка
        private bool mainSheet = true;

        private Excel.Application  excelApp;
        private Excel.Workbook     excelWBook;
        private Excel.Worksheet    excelWSheet;

        public ReportFields()
        {
        }

        private void fillFIODev()
        {
            excelWSheet.Range["D7", "G7"].Value2 = FIODev;
        }
        private void fillFIOChecker()
        {
            excelWSheet.Range["D8", "G8"].Value2 = FIOChecker;
        }
        private void fillFIOAccepter()
        {
            excelWSheet.Range["D10", "G10"].Value2 = FIOAccepter;
        }
        private void fillFIONormChecker()
        {
            excelWSheet.Range["D11", "G11"].Value2 = FIONormChecker;
        }

        private void fillCompanyName()
        {
            // Заполнить файл данными параметров интсрументов
            excelWSheet.Range["K7", "M9"].Value2 = CompanyName;
        }

        private void fillDetailName()
        {
            excelWSheet.Range["K10", "Z11"].Value2 = DetailName;
        }

        private void fillDetailDesignation()
        {
            excelWSheet.Range["R7", "R9"].Value2 = DetailDesignation;
        }

        private void fillCNCProgName()
        {
            incNumber();
            excelWSheet.Range["A14", "A14"].Value2 = "У " + String.Format("d", currentNumber);
            excelWSheet.Range["B14", "D14"].Value2 = "-";
            excelWSheet.Range["G14", "Q14"].Value2 = CNCProgName;
        }

        private void fillCNCMachineName()
        {
            incNumber();
            excelWSheet.Range["A15", "A15"].Value2 = String.Format("d", currentNumber);
            excelWSheet.Range["B15", "D15"].Value2 = "-";
            excelWSheet.Range["G15", "Q15"].Value2 = CNCMachineName;
        }

        private void fillTool(GostTool gostTool)
        {
            incNumber();
            if (!mainSheet)
            {   // форма 4а
                excelWSheet.Range["A" + currentRow.ToString(), "B" + currentRow.ToString()].Value2 = "T " + String.Format("d", currentNumber);
                excelWSheet.Range["C" + currentRow.ToString(), "F" + currentRow.ToString()].Value2 = "-";
                // Отменить объединение и сделать новую ячейку
                excelWSheet.Range["G" + currentRow.ToString(), "S" + currentRow.ToString()].UnMerge();
                excelWSheet.Range["G" + currentRow.ToString(), "S" + currentRow.ToString()].Merge();

                excelWSheet.Range["G" + currentRow.ToString(), "S" + currentRow.ToString()].Value2 = gostTool.toolLabel;
            }
            else
            {    // форма 4
                excelWSheet.Range["A" + currentRow.ToString(), "A" + currentRow.ToString()].Value2 = "T " + String.Format("d", currentNumber);
                excelWSheet.Range["B" + currentRow.ToString(), "D" + currentRow.ToString()].Value2 = "-";
                // Отменить объединение и сделать новую ячейку
                excelWSheet.Range["E" + currentRow.ToString(), "Q" + currentRow.ToString()].UnMerge();
                excelWSheet.Range["E" + currentRow.ToString(), "Q" + currentRow.ToString()].Merge();

                excelWSheet.Range["E" + currentRow.ToString(), "Q" + currentRow.ToString()].Value2 = gostTool.toolLabel;
            }
        }

        private void fillToolParameter(ToolParameter gostToolParam)
        {
            incNumber();
            if (!mainSheet)
            {    // форма 4а           
                excelWSheet.Range["A" + currentRow.ToString(), "B" + currentRow.ToString()].Value2 = String.Format("d", currentNumber);
                excelWSheet.Range["C" + currentRow.ToString(), "F" + currentRow.ToString()].Value2 = "-";

                excelWSheet.Range["I" + currentRow.ToString(), "S" + currentRow.ToString()].Value2 = gostToolParam.Capture;
                excelWSheet.Range["T" + currentRow.ToString(), "AA" + currentRow.ToString()].Value2 = gostToolParam.Value;
            }
            else
            {   // форма 4
                excelWSheet.Range["A" + currentRow.ToString(), "A" + currentRow.ToString()].Value2 = String.Format("d", currentNumber);
                excelWSheet.Range["B" + currentRow.ToString(), "D" + currentRow.ToString()].Value2 = "-";

                excelWSheet.Range["G" + currentRow.ToString(), "Q" + currentRow.ToString()].Value2 = gostToolParam.Capture;
                excelWSheet.Range["R" + currentRow.ToString(), "AA" + currentRow.ToString()].Value2 = gostToolParam.Value;
            }
        }

        private void incNumber()
        {
            currentNumber++;
            currentRow++;

            if (currentNumber > 16 || currentNumber % 17 == 0)
            {
                // TODO: Создание нового листа форма 4A и переход на него
                currentRow = 12;
                addNewSheetForm4A();
            }
        }

        private void addNewSheetForm4A()
        {
            // TODO: Перейти на новый лист или скопировать если необходимо
        }

        private void FillFileReport(String distFileName)
        {

            object misValue = System.Reflection.Missing.Value;

            excelApp = new Excel.Application();
            excelWBook = excelApp.Workbooks.Open(distFileName, null, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", true, false, null, true, 1, 0);
            // Заполняем главный лист
            excelWSheet = (Excel.Worksheet)excelWBook.Worksheets.Item[1];
            // Заполняем "шапку"
            fillCompanyName();
            fillDetailName();
            fillDetailDesignation();
            
            fillFIODev();
            fillFIOChecker();
            fillFIOAccepter();
            fillFIONormChecker();
            // Заполнение таблицы 
            fillCNCProgName();
            fillCNCMachineName();
            // Цикл по всему инструменту для отчета
            for (int i = 0; i < AdditionalToolParameters.gostReportToolsArray.Count; i++)
            {
                GostTool reportTool = AdditionalToolParameters.gostReportToolsArray[i];
                fillTool(reportTool);

                // Цикл по параметрам инструента
                for (int j = 0; j < reportTool.parameters.Count(); j++)
                {
                    ToolParameter repotToolParameter = reportTool.parameters.getParameter(j);
                    fillToolParameter(repotToolParameter);
                }
            }

            excelWBook.Close(true, misValue, misValue);
            excelApp.Quit();

            releaseOdject(excelWSheet);
            releaseOdject(excelWBook);
            releaseOdject(excelApp);
        }

        private void releaseOdject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }



    }
}
