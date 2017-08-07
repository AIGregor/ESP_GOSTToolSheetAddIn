using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EspritTechnology;

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
                Technology reportTechTool = (Technology)newRepotTool;
                Parameter curParam = reportTechTool[parameters.getParameter(i).Name];
                parameters.getParameter(i).Value = Convert.ToString(curParam.Value);
            }
        }

    }
}
