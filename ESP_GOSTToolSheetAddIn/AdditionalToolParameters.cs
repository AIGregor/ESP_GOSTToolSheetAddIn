using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESP_GOSTToolSheetAddIn
{
    class AdditionalToolParameters : ToolParametersList
    {
        /* 
 * Конструктор 
 * Создание XML файла с пустым списком параметров
 */
        public AdditionalToolParameters()
        {

        }

        bool loadFile(string pathFile)
        {
            return false;
        }

        Array getToolParameters()
        {
            Array std1 = new Array[1, 3, 1];
            return std1;
        }

        void setToolParameter(int index, string name)
        {
        }

        bool saveFile(string pathFile)
        {
            return false;
        }

        /*
         * Создание XML файла
         */
        public bool creatPatternFile(string FileName)
        {
            return false;
        }

    }
}
