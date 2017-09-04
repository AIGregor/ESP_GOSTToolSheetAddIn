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
        static public ReportSettings gostReportSettings = new ReportSettings();
        
        public AdditionalToolParameters() : base()
        {
        }

         // Создание XML файла
        public static bool creatPatternFile(string FileName)
        {
            Connect.logger.Info("Создание файла-шаблона");
            
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
            // .net читает только UTF8 - надо преобразовывать для отображения русского текста
            Encoding enc = Encoding.GetEncoding(1251);
            try
            {
                using (StreamReader fs = new StreamReader(Connect.assemblyFolder + StringResource.txtPathToolType, enc))
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
                    }
                }
            }
            catch (Exception E)
            {                
                Connect.logger.Error("Ошибка при создании файл-шаблона \n" + E.Message);
            }

            Connect.logger.Info("Сохранение файла-шаблона");
            XmlDoc.Save(FileName); //сохраняем в документ

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

        public static bool savePatternParameterFile(GostTool[] toolsArray, string path)
        {
            // если файл не существует
            if (File.Exists(path + StringResource.xmlPathPattrenFileName))
            {
                File.Delete(path + StringResource.xmlPathPattrenFileName);    
            }
            createPatternParameterFile(toolsArray, path);

            return true;
        }

        // создание файла параметров
        static void createPatternParameterFile(GostTool[] toolsArray, string path)
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
            Connect.logger.Info("Создание файла параметров в папку " + path + StringResource.xmlPathPattrenFileName);
            XmlDoc.Save(path + StringResource.xmlPathPattrenFileName); //сохраняем в документ
        }

        public static void LoadToolsParameters()
        {
            // Загружаем из файл-шаблона названия инструмента, заполняя форму.
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(Connect.assemblyFolder + StringResource.xmlPathToolsParams);
            }
            catch (Exception E)
            {
                Connect.logger.Error("Ошибка при загрузке файла-шаблона параметров инструмента \n" + E.Message);
            }

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

            try
            {
                if (!File.Exists(Connect.assemblyFolder + StringResource.xmlPathPattrenFileName))
                {
                    creatPatternFile(Connect.assemblyFolder + StringResource.xmlPathPattrenFileName);
                    return;
                }
            }
            catch (Exception E)
            {
                Connect.logger.Error("Файл-шаблон инструментов отсутствует. Ошибка при создании файла\n" + E.Message);
            }

            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(Connect.assemblyFolder + StringResource.xmlPathPattrenFileName);
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
