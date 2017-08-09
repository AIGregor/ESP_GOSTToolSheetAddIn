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
        private string fIODev;          // ФИО Разработчика
        private string fIOChecker;      // ФИО Проверяющего
        private string fIOAccepter;     // ФИО утверждающего
        private string fIONormChecker;  // ФИО норма контроль

        private string companyName;     // Компания
        private string detailName;      // Название детали
        private string detailDesignation;   // Обозначение детали
        private string cNCProgName;     // Название программы
        private string cNCMachineName;  // Название станка

        private int currentNumber = 0;
        private int currentSheetNumber = 1;
        private int currentRow = 13; // Начальная строка
        private bool mainSheet = true;

        private Excel.Application  excelApp;
        private Excel.Workbook     excelWBook;
        private Excel.Worksheet    excelWSheet;

        object misValue = System.Reflection.Missing.Value;

        public string FIODev
        {
            get
            {
                return fIODev;
            }

            set
            {
                fIODev = value;
                Connect.sEspDocument.DocumentProperties.Author = fIODev;
            }
        }

        public string FIOChecker
        {
            get
            {
                return fIOChecker;
            }

            set
            {
                fIOChecker = value;
            }
        }

        public string FIOAccepter
        {
            get
            {
                return fIOAccepter;
            }

            set
            {
                fIOAccepter = value;
            }
        }

        public string FIONormChecker
        {
            get
            {
                return fIONormChecker;
            }

            set
            {
                fIONormChecker = value;
            }
        }

        public string CompanyName
        {
            get
            {
                return companyName;
            }

            set
            {
                companyName = value;
                Connect.sEspDocument.DocumentProperties.Company = companyName;
            }
        }

        public string DetailName
        {
            get
            {
                return detailName;
            }

            set
            {
                detailName = value;
                Connect.sEspDocument.DocumentProperties.Title = detailName;
            }
        }

        public string DetailDesignation
        {
            get
            {
                return detailDesignation;
            }

            set
            {
                detailDesignation = value;
            }
        }

        public string CNCProgName
        {
            get
            {
                return cNCProgName;
            }

            set
            {
                cNCProgName = value;
            }
        }

        public string CNCMachineName
        {
            get
            {
                return cNCMachineName;
            }

            set
            {
                cNCMachineName = value;
            }
        }

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

            if (currentNumber % 17 == 0)
            {
                // TODO: Создание нового листа форма 4A и переход на него
                currentRow = 12;
                mainSheet = false;
                currentSheetNumber++;
                addNewSheetForm4A();
            }
        }

        private void addNewSheetForm4A()
        {
            // TODO: Перейти на новый лист или скопировать если необходимо
            int sheetCount = excelWBook.Worksheets.Count;
            Excel.Worksheet newSheet = excelWBook.Worksheets[2];

            if (currentSheetNumber > 2)
            {
                newSheet.Copy(misValue, excelWBook.Worksheets[sheetCount]);
            }            
            excelWSheet = excelWBook.Sheets[currentSheetNumber];
        }

        public void testAddNewSheet(string distFileName)
        {
            excelApp = new Excel.Application();
            excelWBook = excelApp.Workbooks.Open(distFileName, null, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", true, false, null, true, 1, 0);
            // Заполняем главный лист
            excelWSheet = (Excel.Worksheet)excelWBook.Worksheets.Item[1];
            excelWSheet.Name = "Лист " + currentSheetNumber;

            int i = 10;
            while (i > 0)
            {
                addNewSheetForm4A();
                i--;
            }

            excelWBook.Close(true, misValue, misValue);
            excelApp.Quit();

            releaseOdject(excelWSheet);
            releaseOdject(excelWBook);
            releaseOdject(excelApp);
        }

        public void FillFileReport(string distFileName)
        {
            excelApp = new Excel.Application();
            excelWBook = excelApp.Workbooks.Open(distFileName, null, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", true, false, null, true, 1, 0);
            // Заполняем главный лист
            excelWSheet = (Excel.Worksheet)excelWBook.Worksheets.Item[1];
            excelWSheet.Name = "Лист " + currentSheetNumber;
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
