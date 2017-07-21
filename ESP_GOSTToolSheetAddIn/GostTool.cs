using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ESP_GOSTToolSheetAddIn
{
    class GostTool
    {
        ToolParametersList parameters = new ToolParametersList(); // Список всех параметров
        public String toolType = ""; // тип Mill/Turn
        public String toolName = "";
        public String toolLabel = "";
        public int toolID = 0;

        public GostTool()
        {            
        }

        public void addParameter(ToolParameter newParameter)
        {
            parameters.AddParameter(newParameter);
        }
    }
}
