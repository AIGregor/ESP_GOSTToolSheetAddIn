using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESP_GOSTToolSheetAddIn
{
    class ToolParameter
    {
        String name;
        String value;

        String getName() {
            return name;
        }

        void setName(String newName) {
            name = newName;
        }

        string getValue() {
            return value;
        }

        void setValue(string newValue) {
            value = newValue;
        }

        void setValue(int newValue) {
            value = newValue.ToString();
        }
    }
}
