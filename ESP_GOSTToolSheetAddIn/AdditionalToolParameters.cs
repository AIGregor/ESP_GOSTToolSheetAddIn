using System;
using System.Text;
using System.Xml;
using System.IO;
using ESP_GOSTToolSheetAddIn.Resources;

namespace ESP_GOSTToolSheetAddIn
{
    class AdditionalToolParameters : ToolParametersList
    {
        /* 
 * Конструктор 
 * Создание XML файла с пустым списком параметров
 */
        public AdditionalToolParameters() : base()
        {

        }

        bool loadFile(string pathFile)
        {
            return false;
        }

        Array getToolParameters()
        {
            Array std1 = new Array[1, 3, 1];
            return std1;
        }

        void setToolParameter(int index, string name)
        {
        }

        bool saveFile(string pathFile)
        {
            return false;
        }

        /*
         * Создание XML файла
         */
        public static bool creatPatternFile(string FileName)
        {
            //создание документа
            XmlDocument XmlDoc = new XmlDocument();

            /*<?xml version="1.0" encoding="utf-8" ?> */
            //создание объявления (декларации) документа
            XmlDeclaration XmlDec = XmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            //добавляем в документ
            XmlDoc.AppendChild(XmlDec);

            XmlComment Comment0 = XmlDoc.CreateComment("Типы интсрумента"); //комментарий уровня root            
            XmlDoc.AppendChild(Comment0); //добавляем в документ

            /*<ToolType name="abc"></ToolType>*/
            XmlElement root = XmlDoc.CreateElement("EspritToolsAdditionalParams"); //создание корневого элемента
            XmlDoc.AppendChild(root); //добавляем в документ

            // Файла имен и создание корневых элементов
            string text = "";
            // .net читает только UTF8 - надо преобразовывать для отображения русского текста
            Encoding enc = Encoding.GetEncoding(1251);
            using (StreamReader fs = new StreamReader(StringResource.txtPathToolType, enc))
            {
                while (true)
                {
                    // Читаем строку из файла во временную переменную.
                    string temp = fs.ReadLine();

                    if (temp == null)
                        break; // Если достигнут конец файла, прерываем считывание.

                    string sToolName = getToolName(temp);
                    string sToolID = getToolID(temp);
                    string sToolLabel = getToolLable(temp);

                    XmlElement ElementTools = XmlDoc.CreateElement(StringResource.xmlElementName); //создание корневого элемента
                    ElementTools.SetAttribute(StringResource.xmlToolName, sToolName); //создание атрибута
                    ElementTools.SetAttribute(StringResource.xmlToolID, sToolID);
                    ElementTools.SetAttribute(StringResource.xmlToolLabel, sToolLabel);
                    root.AppendChild(ElementTools);

                    text += temp; // Пишем считанную строку в итоговую переменную.
                }
            }

            XmlDoc.Save(StringResource.xmlPathToolsParams); //сохраняем в документ
            return true;
        }

        static string getToolName(string sSourceString)
        {
            int startName = sSourceString.LastIndexOf("=") + 2;

            string result = "";
            int i = startName;
            while (sSourceString[i] != '\t' && sSourceString[i] != ' ' && i < sSourceString.Length)
            {
                result += sSourceString[i];
                i++;
            }

            //int tabIndx = sSourceString.IndexOf("\t");
            //int spaceIndx = sSourceString.IndexOf(" ");
            //int dashIndx = sSourceString.IndexOf("-");

            //if (spaceIndx > 0)
            //    tabIndx = Math.Min(tabIndx, spaceIndx);

            //if (tabIndx < 0)
            //    tabIndx = dashIndx;            

            //if (tabIndx >= startName || dashIndx >= startName)
            //    result = sSourceString.Substring(startName, Math.Min(tabIndx, dashIndx) - startName);

            return result;
        }

        static string getToolID(string sSourceString)
        {
            int endID = sSourceString.IndexOf(" ");
            string result = sSourceString.Substring(0, endID);
            return result;
        }

        static string getToolLable(string sSourceString)
        {
            int startCapture = sSourceString.IndexOf("-") + 2;
            string result = sSourceString.Substring(startCapture);
            return result;
        }

    }
}
