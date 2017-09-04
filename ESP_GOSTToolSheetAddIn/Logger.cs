using System;
using System.IO;

namespace ESP_GOSTToolSheetAddIn
{    
    public class Logger
    {
        public string logFilePath = "";
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
            writeLog("INFO", message);
        }

        public void Error(string message)
        {
            writeLog("ERROR", message);
        }

        public void Trace(string message)
        {
            writeLog("TRACE", message);
        }

        public void Warning(string message)
        {
            writeLog("WARNING", message);
        }

        protected void writeLog(string logType, string message)
        {
            string resultString = "";
            DateTime toDay = DateTime.Now;
            string timeString = toDay.ToString("s");

            string fileName = DateTime.Today.ToString("yyyy-MM-dd") + extention;
            string path = Path.Combine(logFilePath, fileName);

            if (!File.Exists(path))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }                

            resultString += timeString;
            resultString += String.Concat(" ",logType, " ");
            resultString += message;
            StreamWriter file = new StreamWriter(Path.Combine(logFilePath, fileName), true);
            file.WriteLine(resultString);

            file.Close();
        }
    }
}
