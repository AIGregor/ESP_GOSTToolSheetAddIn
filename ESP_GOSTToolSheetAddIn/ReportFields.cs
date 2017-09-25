using System;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace ESP_GOSTToolSheetAddIn
{
    /// <summary>
    /// Класс заполнения Excel файла параметрами инструмента из внутренней структуры AdditionalToolParameters.gostReportToolsArray
    /// </summary>
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
        private int totalSheetNumber = 0;
        private int totalRowNumber = 0;
        private int currentRow = 13; // Начальная строка
        private bool mainSheet = true;

        private Excel.Application  excelApp;
        private Excel.Workbook     excelWBook;
        private Excel.Worksheet    excelWSheet;

        object misValue = System.Reflection.Missing.Value;

        public DatabaseInterface dataBase = new DatabaseInterface();

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
                saveFields();
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
                saveFields();
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
                saveFields();
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
                saveFields();
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
                saveFields();
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
                saveFields();
            }
        }

        public int TotalSheetNumber
        {
            get
            {
                if (totalSheetNumber == 0)
                    calcTotalPageNumber();

                return totalSheetNumber;
            }

            set
            {
                totalSheetNumber = value;
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
            excelWSheet.Range["M7", "R9"].Value2 = DetailDesignation;
        }

        private void fillCNCProgName()
        {
            incNumber();
            excelWSheet.Range["A" + currentRow.ToString(), "A" + currentRow.ToString()].Value2 = "У " + getFormatedNumber();
            excelWSheet.Range["B" + currentRow.ToString(), "D" + currentRow.ToString()].Value2 = "-";
            excelWSheet.Range["G" + currentRow.ToString(), "Q" + currentRow.ToString()].Value2 = "Управляющая программа: " + CNCProgName;
        }

        private void fillCNCMachineName()
        {
            incNumber();
            excelWSheet.Range["A" + currentRow.ToString(), "A" + currentRow.ToString()].Value2 = getFormatedNumber();
            excelWSheet.Range["B" + currentRow.ToString(), "D" + currentRow.ToString()].Value2 = "-";
            excelWSheet.Range["G" + currentRow.ToString(), "Q" + currentRow.ToString()].Value2 = "Станок: " + CNCMachineName;
        }

        private void fillTool(GostTool gostTool)
        {
            incNumber();
            if (!mainSheet)
            {   // форма 4а
                excelWSheet.Range["A" + currentRow.ToString(), "B" + currentRow.ToString()].Value2 = "T " + getFormatedNumber();
                excelWSheet.Range["C" + currentRow.ToString(), "F" + currentRow.ToString()].Value2 = "-";
                // Отменить объединение и сделать новую ячейку
                excelWSheet.Range["G" + currentRow.ToString(), "S" + currentRow.ToString()].UnMerge();
                excelWSheet.Range["G" + currentRow.ToString(), "S" + currentRow.ToString()].Merge();

                excelWSheet.Range["G" + currentRow.ToString(), "S" + currentRow.ToString()].Value2 = gostTool.toolLabel;
            }
            else
            {    // форма 4
                excelWSheet.Range["A" + currentRow.ToString(), "A" + currentRow.ToString()].Value2 = "T " + getFormatedNumber();
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
                excelWSheet.Range["A" + currentRow.ToString(), "B" + currentRow.ToString()].Value2 = getFormatedNumber();
                excelWSheet.Range["C" + currentRow.ToString(), "F" + currentRow.ToString()].Value2 = "-";

                excelWSheet.Range["I" + currentRow.ToString(), "S" + currentRow.ToString()].Value2 = gostToolParam.Capture;
                excelWSheet.Range["T" + currentRow.ToString(), "AA" + currentRow.ToString()].Value2 = gostToolParam.Value;
            }
            else
            {   // форма 4
                excelWSheet.Range["A" + currentRow.ToString(), "A" + currentRow.ToString()].Value2 = getFormatedNumber();
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
                addNewSheetForm4A();
            }
        }

        private string getFormatedNumber()
        {
            //TODO: посчитать заранее сколько цифр надо выводить, в зависимости от числа инструментов и параметров
            int symbolCount = totalRowNumber.ToString().Count();
            return string.Format("{0:d" + symbolCount + "}", currentNumber);
        }

        private void addNewSheetForm4A()
        {
            currentRow = 12;
            mainSheet = false;
            currentSheetNumber++;

            // TODO: Перейти на новый лист или скопировать если необходимо
            int sheetCount = excelWBook.Worksheets.Count;
            Excel.Worksheet newSheet = excelWBook.Worksheets[sheetCount];
            
            // Снять защиту с листа
            if (sheetCount == 2)
                newSheet.Unprotect("rogachev");

            // Копируем на перед один чистый лист
            newSheet.Copy(misValue, excelWBook.Worksheets[sheetCount]);
            
            excelWSheet = excelWBook.Sheets[currentSheetNumber];
            // TODO: Печатать номер текущего листа
            fillTotalPageNumber();
            fillPageNumber();
        }

        private void fillPageNumber()
        {
            if (!mainSheet)
            {
                excelWSheet.Range["AF6", "AH6"].Value2 = currentSheetNumber;
            }
            else
            {
                excelWSheet.Range["AH6", "AJ6"].Value2 = currentSheetNumber;
            }
        }

        private void fillTotalPageNumber()
        {
            if (!mainSheet)
            {
                excelWSheet.Range["AD6", "AD6"].Value2 = totalSheetNumber;
            }
            else
            {
                excelWSheet.Range["AE6", "AF6"].Value2 = totalSheetNumber;
            }
        }

        public void calcTotalPageNumber()
        {
            totalRowNumber = 2; // Начальные строки - название УП и название стонка
            for (int i = 0; i < AdditionalToolParameters.gostReportToolsArray.Count; i++)
            {
                GostTool reportTool = AdditionalToolParameters.gostReportToolsArray[i];
                totalRowNumber++;
                totalRowNumber += reportTool.parameters.Count();
            }

            totalSheetNumber = totalRowNumber / 17;

            if (totalRowNumber % 17 != 0)
                totalSheetNumber++;
        }

        public void getFIOFieldsFromDocument()
        {
            // TODO: Заполнить до конца кто где должен храниться
            fIODev = Connect.sEspDocument.DocumentProperties.Author;
            companyName = Connect.sEspDocument.DocumentProperties.Company;
            getCommonFields();
        }

        private void getCommonFields()
        {
            string commonFields = Connect.sEspDocument.DocumentProperties.Notes;
            commonFields.IndexOf("\r");

            string[] splitter = new string[1] { "\r\n" };

            string[] fields = commonFields.Split(splitter, StringSplitOptions.None);

            if (fields.Length < 7)
                return;

            fIOChecker          = fields[0];
            fIOAccepter         = fields[1];
            fIONormChecker      = fields[2];

            detailName          = fields[3];
            detailDesignation   = fields[4];
            cNCProgName         = fields[5];
            cNCMachineName      = fields[6];
        }

        private string stringFromArrey(ref string[] fields)
        {
            string result = "";

            foreach (string str in fields)
            {
                result += str + "\r\n";
            }            
            return result;
        }

        private void saveFields()
        {
            string[] fields = new string[7];
            fields[0] = fIOChecker;
            fields[1] = fIOAccepter;
            fields[2] = fIONormChecker;
            
            fields[3] = detailName;
            fields[4] = detailDesignation;
            fields[5] = cNCProgName;
            fields[6] = cNCMachineName;

            string temp = stringFromArrey(ref fields);
            Connect.sEspDocument.DocumentProperties.Notes = stringFromArrey(ref fields);
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

            excelApp.DisplayAlerts = false;
            i = 5;
            while (i > 0)
            {                
                Excel.Worksheet deletedSheet = excelWBook.Worksheets.Item[i];
                deletedSheet.Delete();
                i--;
            }
            excelApp.DisplayAlerts = true;


            excelWBook.Close(true, misValue, misValue);
            excelApp.Quit();

            releaseOdject(excelWSheet);
            releaseOdject(excelWBook);
            releaseOdject(excelApp);
        }

        public void FillFileReport(string distFileName)
        {
            Connect.logger.Info("Формирование карты наладки");
            setInnerParams();
            try
            {
                excelApp = new Excel.Application();
            }
            catch (Exception E)
            {
                Connect.logger.Error("Не удалось создать Excel приложение. Error :" + E.Message);
                return;
            }

            try
            {
                excelWBook = excelApp.Workbooks.Open(distFileName, null, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", true, false, null, true, 1, 0);
            }
            catch (Exception E)
            {
                Connect.logger.Error("Не удалось открыть файл " + E.Message);
                return;
            }
            excelWBook = excelApp.Workbooks.Open(distFileName, null, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", true, false, null, true, 1, 0);

            //Снять защиту с книги после копирования
            excelWBook.Unprotect("rogachev");

            // Заполняем главный лист
            excelWSheet = (Excel.Worksheet)excelWBook.Worksheets.Item[1];

            //Снять защиту с листа
            excelWSheet.Unprotect("rogachev");

            //excelWSheet.Name = "Лист " + currentSheetNumber;
            // Заполняем "шапку"
            fillCompanyName();
            fillDetailName();
            fillDetailDesignation();
            
            fillFIODev();
            fillFIOChecker();
            fillFIOAccepter();
            fillFIONormChecker();

            // Посчитать кол-во листов
            calcTotalPageNumber();
            // Заполнить номара страниц
            fillTotalPageNumber();
            fillPageNumber();
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

            // Удаляем последний чистый лист 
            excelApp.DisplayAlerts = false;
            Excel.Worksheet deletedSheet = excelWBook.Worksheets.Item[excelWBook.Worksheets.Count];
            deletedSheet.Delete();
            excelApp.DisplayAlerts = true;

            excelWBook.Close(true, misValue, misValue);
            excelApp.Quit();

            releaseOdject(excelWSheet);
            releaseOdject(excelWBook);
            releaseOdject(excelApp);
        }

        private void setInnerParams()
        {
            currentNumber = 0;
            currentSheetNumber = 1;
            totalSheetNumber = 0;
            totalRowNumber = 0;
            currentRow = 13;
            mainSheet = true;
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
