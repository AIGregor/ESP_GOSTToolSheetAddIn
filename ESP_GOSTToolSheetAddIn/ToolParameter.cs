using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESP_GOSTToolSheetAddIn
{
    class ToolParameter
    {
        public String Name = "";
        public String Capture = "";
        public String Value = "";
        public int CLCode = 0;
        public String Type = "";
        int ID = 0;

        String getName() {
            return Name;
        }

        void setName(String newName) {
            Name = newName;
        }

        string getValue() {
            return Value;
        }

        void setValue(string newValue) {
            Value = newValue;
        }

        void setValue(int newValue) {
            Value = newValue.ToString();
        }
    }
}
