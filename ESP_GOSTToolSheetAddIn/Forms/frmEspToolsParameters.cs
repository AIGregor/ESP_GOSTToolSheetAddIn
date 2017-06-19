using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using EspritTechnology;
using EspritTools;
using ESP_GOSTToolSheetAddIn.Resources;
using System.Collections;

namespace ESP_GOSTToolSheetAddIn
{
    /// <summary>
    ///     Класс-форма редактирования параметров инструмента, которые необходимо загрузить в карту наладки
    /// </summary>
    public partial class frmEspToolsParameters : Form
    {       

        public frmEspToolsParameters()
        {
            InitializeComponent();
        }
                
        private void EspToolsParameters_Load(object sender, EventArgs e)
        {
            listEspStandardParameters.AllowDrop = true;
            listEspStandardParameters.DragDrop += new DragEventHandler(listEspStandardParameters_DragDrop);
            listEspStandardParameters.DragEnter += new DragEventHandler(listEspStandardParameters_DragEnter);
        }
        
        // загрузка параметров формы
        private void frmEspToolsParameters_Shown(object sender, EventArgs e)
        {
            // Загружаем из файл-шаблона названия инструмента, заполняя форму.
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(StringResource.xmlPathToolsParams);
            XmlElement xRoot = xDoc.DocumentElement;

            // выбор всех инструментов
            XmlNodeList childnodes = xRoot.SelectNodes(StringResource.xmlElementName);
            foreach (XmlNode node in childnodes)
            {
                int iToolId = int.Parse(node.SelectSingleNode("@" + StringResource.xmlToolID).Value);
                if (iToolId != 0)
                {
                    XmlNode singleNode = node.SelectSingleNode("@" + StringResource.xmlToolLabel);
                    string sToolName = singleNode.Value;
                    lstTools.Items.Add(sToolName);
                }
            }

            //Tools m_espToolsList = new Tools();

            // По инструменту загружаем список параметров, заполняя форму.
            ToolMillEndMill tlBallMill = new ToolMillEndMill();

            Technology espTool = (Technology)tlBallMill;

            List<string> lstParameters = new List<string>();

            IEnumerator enumerator = espTool.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Parameter item = (Parameter)enumerator.Current;
                string sValue = item.Name;
                lstParameters.Add(sValue);
                //listEspStandardParameters.Items.Add(dValue);
            }

            lstParameters.Sort();
            foreach (string sValue in lstParameters)
                listEspStandardParameters.Items.Add(sValue);

            // Устанавливаем списокк сортировки "Все инструменты"
            cbSortToolList.SelectedItem = 1;
            lstTools.SelectedIndex = 0;
        }

        private void listEspStandardParameters_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void listEspStandardParameters_DragDrop(object sender, DragEventArgs e)
        {
            listView1.Items.Add(e.Data.ToString());
        }

        // Выбор инструмента из списка
        private void lstTools_Click(object sender, EventArgs e)
        {
            // Получили название инструмента
            string sItemName = lstTools.GetItemText(lstTools.SelectedItem);

            // Получили название класса инструмента
            // Загружаем из файл-шаблона названия инструмента, заполняя форму.
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(StringResource.xmlPathToolsParams);
            XmlElement xRoot = xDoc.DocumentElement;

            // выбор всех инструментов "user[@name='Bill Gates']"
            XmlNode childNode = xRoot.SelectSingleNode(
                StringResource.xmlElementName + "[@" + 
                StringResource.xmlToolLabel + "='" + sItemName + "']");

            XmlAttributeCollection xmlCollection = childNode.Attributes;
            string sClassName = xmlCollection.Item(0).Value;

            //Type tType = typeof(ToolMillEndMill);
            //string assemblyName = tType.AssemblyQualifiedName.ToString();
            // Хитрая штука - вытаскиваем имя класса инструмента и потом получаем тип класса
            // из текстового имени класса
            //string sGetType = "EspritTechnology." + sClassName + ", ESP_GOSTToolSheetAddIn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            //Type elementType = Type.GetType(sGetType);
            
            Type tType = typeof(ToolMillChamferMill);
            string assemblyName = tType.AssemblyQualifiedName.ToString();

            string sGetType = "EspritTechnology.ToolLatheMiniBoring, ESP_GOSTToolSheetAddIn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            Type elementType = Type.GetType(sGetType);

            if (elementType != null)
            {
                object list = Activator.CreateInstance(elementType);
                Technology tSelectedTool = (Technology) list;
            }
            
            //Type listType = typeof(List<>).MakeGenericType(new Type[] { elementType });
            //object list = Activator.CreateInstance<"EspritTechnology.ToolLatheGroove">();

            //object list = Activator.CreateInstance("ToolMillUndercutMill"); Activator.CreateInstance<Person>();
            //object list = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("EspritTechnology.ToolLatheGroove");
            //echnology tSelectedTool = (Technology) list;
            Console.WriteLine("test");
        }
    }
}
