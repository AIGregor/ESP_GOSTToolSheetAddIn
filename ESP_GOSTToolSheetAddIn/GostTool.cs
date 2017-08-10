using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EspritTechnology;
using ESP_GOSTToolSheetAddIn.Resources;

namespace ESP_GOSTToolSheetAddIn
{
    class GostTool
    {
        public ToolParametersList parameters; // Список всех параметров
        public Technology techTool = null;
        public String toolType = ""; // тип Mill/Turn
        public String toolName = "";
        public String toolLabel = "";
        public String toolDocumentID = "";
        public int toolID = 0;

        private Guid toolDataBaseID = new Guid();

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
        public void addParametersValue(Tool newRepotTool)
        {
            for (int i = 0; i < parameters.Count(); i++)
            {
                // Загрузить значения стандартных параметров
                if (String.Equals(parameters.getParameter(i).Type, StringResource.xmlParamStandartType))
                {
                    Technology reportTechTool = (Technology)newRepotTool;
                    Parameter curParam = reportTechTool[parameters.getParameter(i).Name];
                    parameters.getParameter(i).Value = Convert.ToString(curParam.Value);
                }
                // Загрузить значение пользовательских параметров из базы данных
                if (String.Equals(parameters.getParameter(i).Type, StringResource.xmlParamUserType))
                {
                    // TODO: Чтение парметров из БД, заполнение структуры
                }
            }
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
