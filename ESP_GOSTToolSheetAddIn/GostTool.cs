using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EspritTechnology;
using ESP_GOSTToolSheetAddIn.Resources;
//TODO: Что писать в БД для пользовательских параметров - capture или name ?

namespace ESP_GOSTToolSheetAddIn
{
    class GostTool
    {
        public ToolParametersList parameters; // Список всех параметров
        public Technology techTool = null;  
        public string toolType = "";        // тип Mill/Turn
        public string toolName = "";        // Название инструмента в esprit
        public string toolLabel = "";       // Название типа инструмента на русском языке
        public string toolDocumentID = "";  // ID - Название инструмента из формы инструмента
        public int toolID = 0;              // ID инструмента из API exprit по порядку для каждого типа, хранится в XML
        public string dataBaseToolID = "";  // ID инструмента в БД - базе знаний

        public GostTool()
        {
            parameters = new ToolParametersList();
        }

        // Конструктор копирования
        public GostTool(GostTool previousGostTool)
        {
            parameters = new ToolParametersList(previousGostTool.parameters);
            techTool = previousGostTool.techTool;
            toolType = previousGostTool.toolType;
            toolName = previousGostTool.toolName;
            toolLabel = previousGostTool.toolLabel;
            toolDocumentID = previousGostTool.toolDocumentID;
            toolID = previousGostTool.toolID;

            Connect.logger.Info(String.Format("Создан инструмент : {0}", toolID));
        }

        public void addParameter(ToolParameter newParameter)
        {
            parameters.AddParameter(newParameter);
        }

        public void removeParameter(ToolParameter oldParameter)
        {
            parameters.RemoveParameter(oldParameter);
        }

        public void removeParameter(string DeleteParameterName)
        {            
            ToolParameter deletedParam = parameters.getParameter(DeleteParameterName);
            removeParameter(deletedParam);
        }

        // Записываем значение параметра из документа в структуру
        public bool addParametersValue(Tool newRepotTool, bool loadUserParams)
        {
            bool result = true;
            DatabaseInterface knowledgeBase = new DatabaseInterface();
            if (dataBaseToolID == "" && loadUserParams)
            {
                Connect.logger.Info("Получение ID инструмента в БД");
                string cuttingToolID = knowledgeBase.getCuttingToolID(toolDocumentID);
                dataBaseToolID = cuttingToolID;

                if (dataBaseToolID == null)
                    result = false;
            }

            for (int i = 0; i < parameters.Count(); i++)
            {
                ToolParameter currentToolParameter = parameters.getParameter(i);
                // Загрузить значения стандартных параметров
                if (String.Equals(parameters.getParameter(i).Type, StringResource.xmlParamStandartType))
                {
                    Technology reportTechTool = (Technology)newRepotTool;
                    Parameter curParam = reportTechTool[parameters.getParameter(i).Name];
                    currentToolParameter.Value = Convert.ToString(curParam.Value);
                }
                // Загрузить значение пользовательских параметров из базы данных
                if (String.Equals(currentToolParameter.Type, StringResource.xmlParamUserType))
                {
                    // TODO: Чтение парметров из БД, заполнение значения
                    if (dataBaseToolID != null && loadUserParams)
                        currentToolParameter.Value = knowledgeBase.getUsersParamValue(dataBaseToolID, currentToolParameter.CLCode);
                }
            }

            return result;
        }

        public int getMaxClCodeValue()
        {
            int maxClCode = 0;
            for (int i = 0; i < parameters.Count(); i++)
            {
                if (maxClCode < parameters.getParameter(i).CLCode)
                {
                    maxClCode = parameters.getParameter(i).CLCode;
                }
            }

            return maxClCode;
        }

    }
}
