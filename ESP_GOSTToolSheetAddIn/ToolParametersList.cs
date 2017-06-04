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
        ToolParameter[] parameters;
        String toolType;
        String toolID;

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
