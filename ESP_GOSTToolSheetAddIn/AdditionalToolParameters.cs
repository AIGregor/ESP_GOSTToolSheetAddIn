using System;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using ESP_GOSTToolSheetAddIn.Resources;

namespace ESP_GOSTToolSheetAddIn
{
    class AdditionalToolParameters : ToolParametersList
    {
        /* 
        * Конструктор 
        * Создание XML файла с пустым списком параметров
        */
        static public GostTool[] gostToolsArray; // Массив всех инструментов и параметров которые надо показать в отчете
        static public List<GostTool> gostReportToolsArray = new List<GostTool>(); // Массив инструментов из текущего документа
        static public ReportFields gostReportFields = new ReportFields();
        
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

         // Создание XML файла
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

                    //text += temp; // Пишем считанную строку в итоговую переменную.
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

        public static bool savePatternParameterFile(GostTool[] toolsArray)
        {
            // если файл не существует
            if (File.Exists(StringResource.xmlPathPattrenFileName))
            {
                File.Delete(StringResource.xmlPathPattrenFileName);    
            }
            createPatternParameterFile(toolsArray);

            return true;
        }

        // создание файла параметров
        static void createPatternParameterFile(GostTool[] toolsArray)
        {
            //создание документа
            XmlDocument XmlDoc = new XmlDocument();

            /*<?xml version="1.0" encoding="utf-8" ?> */
            //создание объявления (декларации) документа
            XmlDeclaration XmlDec = XmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            //добавляем в документ
            XmlDoc.AppendChild(XmlDec);

            XmlComment Comment0 = XmlDoc.CreateComment("Параметры для карты наладки"); //комментарий уровня root            
            XmlDoc.AppendChild(Comment0); //добавляем в документ

            /*<ToolType name="abc"></ToolType>*/
            XmlElement root = XmlDoc.CreateElement("EspritReportParameters"); //создание корневого элемента
            XmlDoc.AppendChild(root); //добавляем в документ

            // Запись инструмента и параметров в файл
            for (int i = 0; i < toolsArray.Length; i++)
            {
                // Создание инструмента
                XmlElement ElementTools = XmlDoc.CreateElement(StringResource.xmlElementName); //создание корневого элемента
                ElementTools.SetAttribute(StringResource.xmlToolName, toolsArray[i].toolName); //создание атрибута
                ElementTools.SetAttribute(StringResource.xmlToolID, toolsArray[i].toolID.ToString());              
                root.AppendChild(ElementTools);
                // Запись параметров
                for (int j = 0; j < toolsArray[i].parameters.Count(); j++)
                {
                    ToolParameter toolParam = toolsArray[i].parameters.getParameter(j);

                    XmlElement elementParameter = XmlDoc.CreateElement(StringResource.xmlParameterXMLName);
                    elementParameter.SetAttribute(StringResource.xmlParameterName, toolParam.Name);
                    elementParameter.SetAttribute(StringResource.xmlParameterClCode, toolParam.CLCode.ToString());
                    elementParameter.SetAttribute(StringResource.xmlParameterType, toolParam.Type);
                    elementParameter.SetAttribute(StringResource.xmlParameterCapture, toolParam.Capture);
                    ElementTools.AppendChild(elementParameter);
                }
            }

            XmlDoc.Save(StringResource.xmlPathPattrenFileName); //сохраняем в документ
        }

        public static void LoadToolsParameters()
        {
            // Загружаем из файл-шаблона названия инструмента, заполняя форму.
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(StringResource.xmlPathToolsParams);
            XmlElement xRoot = xDoc.DocumentElement;

            // выбор всех инструментов
            XmlNodeList childnodes = xRoot.SelectNodes(StringResource.xmlElementName);

            // Очистить массив, при повторной загрузке парметров
            if (gostToolsArray != null)
            {
                Array.Clear(gostToolsArray, 0, gostToolsArray.Length);
            }

            // Создание массива инструментов
            gostToolsArray = new GostTool[childnodes.Count - 1];
            int i = 0;
            foreach (XmlNode node in childnodes)
            {
                int iToolId = int.Parse(node.SelectSingleNode("@" + StringResource.xmlToolID).Value);
                if (iToolId != 0)
                {
                    XmlNode singleNodeLable = node.SelectSingleNode("@" + StringResource.xmlToolLabel);
                    string sToolLabel = singleNodeLable.Value;
                    XmlNode singleNodeName = node.SelectSingleNode("@" + StringResource.xmlToolName);
                    string sToolName = singleNodeName.Value;

                    gostToolsArray[i] = new GostTool();
                    gostToolsArray[i].toolID = iToolId;
                    gostToolsArray[i].toolLabel = sToolLabel;
                    gostToolsArray[i].toolName = sToolName;
                    i++;
                }
            }
            
            if (!File.Exists(StringResource.xmlPathPattrenFileName))
            {
                creatPatternFile(StringResource.xmlPathPattrenFileName);
                return;
            }

            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(StringResource.xmlPathPattrenFileName);
            // get root element
            XmlElement xmlRoot = XmlDoc.DocumentElement;
            // select all tools
            XmlNodeList allToolsList = xmlRoot.SelectNodes(StringResource.xmlElementName);
            int index = 0;
            foreach (XmlNode nodeTool in allToolsList)
            {
                XmlNode singleNodeName = nodeTool.SelectSingleNode("@" + StringResource.xmlToolName);
                string sToolName = singleNodeName.Value;
                if (String.Equals(sToolName, gostToolsArray[index].toolName))
                {
                    XmlNodeList parametersList = nodeTool.ChildNodes;
                    for (int j = 0; j < parametersList.Count; j++)
                    {
                        ToolParameter newParam = new ToolParameter();
                        newParam.Name = parametersList[j].SelectSingleNode("@" + StringResource.xmlParameterName).Value;
                        newParam.Capture = parametersList[j].SelectSingleNode("@" + StringResource.xmlParameterCapture).Value;
                        newParam.Type = parametersList[j].SelectSingleNode("@" + StringResource.xmlParameterType).Value;
                        newParam.CLCode = int.Parse(parametersList[j].SelectSingleNode("@" + StringResource.xmlParameterClCode).Value);

                        gostToolsArray[index].addParameter(newParam);
                    }
                }
                index++;
            }
        }

        public static GostTool getGostTool(int toolType)
        {
            // находим инструмент из списка
            for (int i = 0; i < gostToolsArray.Length; i++)
            {
                if (String.Equals(gostToolsArray[i].toolID, toolType))
                {
                    return gostToolsArray[i];
                }
            }
            return null;
         }
    }
}
