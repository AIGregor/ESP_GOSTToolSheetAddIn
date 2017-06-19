using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public AdditionalToolParameters()
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
        public bool creatPatternFile(string FileName)
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
            using (StreamReader fs = new StreamReader(StringResource.pathToolType))
            {
                while (true)
                {
                    // Читаем строку из файла во временную переменную.
                    string temp = fs.ReadLine();
                    if (temp == null) break; // Если достигнут конец файла, прерываем считывание.

                    string sToolName = getToolName(temp);
                    string sToolID = getToolID(temp);

                    /*<ToolType name="abc"></ToolType>*/

                    XmlElement ElementTools = XmlDoc.CreateElement(StringResource.xmlElementName); //создание корневого элемента
                    ElementTools.SetAttribute("ToolName", sToolName); //создание атрибута
                    ElementTools.SetAttribute("ToolID", sToolID);
                    root.AppendChild(ElementTools);

                    text += temp; // Пишем считанную строку в итоговую переменную.
                }
            }

            XmlDoc.Save(StringResource.xmlPathToolsParams); //сохраняем в документ
            return true;
        }

        string getToolName(string sSourceString)
        {
            int startName = sSourceString.LastIndexOf("=") + 2;
            string result = sSourceString.Substring(startName);
            return result;
        }

        string getToolID(string sSourceString)
        {
            int endID = sSourceString.IndexOf(" ");
            string result = sSourceString.Substring(0, endID);
            return result;
        }

    }
}
