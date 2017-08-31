using System;
using System.IO;

namespace ESP_GOSTToolSheetAddIn
{    
    public class Logger
    {
        public string logFilePath = "";
        private string fileName = "";
        private string extention = ".log";

        public Logger()
        {
        }

        public string getFileName()
        {
            string fileName = "";
            return fileName;
        }

        public string getTimeString()
        {
            string timeString = "";
            return timeString;
        }

        public void Info(string message)
        {
            string resultString = "";
            DateTime toDay = DateTime.Now;
            string timeString = toDay.ToString("s");

            fileName = DateTime.Today.ToString("yyyy-mm-dd") + extention;

            resultString += timeString;
            resultString += " ";
            resultString += message;
            StreamWriter file = new StreamWriter(Path.Combine(logFilePath, fileName), true);
            file.WriteLine(resultString);

            file.Close();
        }

        public void Error(string message)
        {

        }

    }
}
