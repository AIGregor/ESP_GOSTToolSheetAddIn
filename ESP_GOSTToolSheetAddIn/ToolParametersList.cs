using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EspritTechnology;

namespace ESP_GOSTToolSheetAddIn
{
    class ToolParametersList
    {
        List<ToolParameter> parameters = new List<ToolParameter>();

        ToolParametersList(Technology tToolType)
        {
        }

        public ToolParametersList()
        {
        }

        public void AddParameter(ToolParameter newParameter)
        {
            parameters.Add(newParameter);
        }

        bool getXMLParametersList(string path) {
            return false;
        }

        void setXMLParameterList(ToolParametersList newParameters) {

        }

        bool fillParametersList(EspritTechnology.Tool workTool) {
            return false;
        }

    }
}
