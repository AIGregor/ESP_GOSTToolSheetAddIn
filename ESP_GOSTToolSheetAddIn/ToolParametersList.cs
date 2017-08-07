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

        public ToolParametersList(ToolParametersList priveousParameters)
        {
            for (int i = 0; i < priveousParameters.parameters.Count; i++)
            {
                ToolParameter newToolParameter = new ToolParameter(priveousParameters.parameters[i]);
                parameters.Add(newToolParameter);
            }
        }

        public int Count()
        {
            return parameters.Count();
        }

        public void AddParameter(ToolParameter newParameter)
        {
            parameters.Add(newParameter);
        }

        public void RemoveParameter(ToolParameter oldParameter)
        {
            parameters.Remove(oldParameter);
        }

        public ToolParameter getParameter(int index)
        {     
            ToolParameter result = parameters[index];
            return result;
        }

        public ToolParameter getParameter(string ParameterName)
        {
            ToolParameter result;
            result = parameters.Find(x => x.Name == ParameterName);
            return result;
        }

        public void removeParameter(int ClCode)
        {
            foreach (ToolParameter item in parameters)
            {
                if (item.CLCode == ClCode)
                {
                    parameters.Remove(item);
                }
            }
        }

        bool getXMLParametersList(string path) {
            return false;
        }

        void setXMLParameterList(ToolParametersList newParameters)
        {
        }

        bool fillParametersList(EspritTechnology.Tool workTool) {
            return false;
        }

    }
}
