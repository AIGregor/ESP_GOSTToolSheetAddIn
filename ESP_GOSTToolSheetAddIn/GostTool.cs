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
        public ToolParametersList parameters = new ToolParametersList(); // Список всех параметров
        public Technology techTool = null;
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

        public void removeParameter(ToolParameter oldParameter)
        {
            parameters.RemoveParameter(oldParameter);
        }

        public void removeParameter(int ClCode)
        {

        }

    }
}
