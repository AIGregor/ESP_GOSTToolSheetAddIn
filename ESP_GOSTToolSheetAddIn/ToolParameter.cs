using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESP_GOSTToolSheetAddIn
{
    class ToolParameter
    {
        public String ParameterName = "";
        public String ParameterValue = "";
        int ID = 0;

        String getName() {
            return ParameterName;
        }

        void setName(String newName) {
            ParameterName = newName;
        }

        string getValue() {
            return ParameterValue;
        }

        void setValue(string newValue) {
            ParameterValue = newValue;
        }

        void setValue(int newValue) {
            ParameterValue = newValue.ToString();
        }
    }
}
