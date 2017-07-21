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
using ESP_GOSTToolSheetAddIn.Forms;
using System.Collections;

namespace ESP_GOSTToolSheetAddIn
{
    
    /// <summary>
    ///     Класс-форма редактирования параметров инструмента, которые необходимо загрузить в карту наладки
    /// </summary>
    public partial class frmEspToolsParameters : Form
    {
        GostTool[] gostToolsArray;       

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
            // Создание массива инструментов
            gostToolsArray = new GostTool[childnodes.Count-1];
            int i = 0;
            foreach (XmlNode node in childnodes)
            {                
                int iToolId = int.Parse(node.SelectSingleNode("@" + StringResource.xmlToolID).Value);
                if (iToolId != 0)
                {
                    XmlNode singleNodeLable = node.SelectSingleNode("@" + StringResource.xmlToolLabel);
                    string sToolLabel = singleNodeLable.Value;
                    XmlNode singleNodeName = node.SelectSingleNode("@" + StringResource.xmlToolName);
                    string sToolName = singleNodeName.Value;

                    gostToolsArray[i] = new GostTool();
                    gostToolsArray[i].toolID = iToolId;
                    gostToolsArray[i].toolLabel = sToolLabel;
                    gostToolsArray[i].toolName = sToolName;
                    i++;
                                        
                    lstTools.Items.Add(sToolLabel);
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
            listEspGostParams.Items.Add(e.Data.ToString());
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

            fillFrmList(sClassName);
            Console.WriteLine("test");
            
            //Type tType = typeof(ToolMillEndMill);
            //string assemblyName = tType.AssemblyQualifiedName.ToString();
            // Хитрая штука - вытаскиваем имя класса инструмента и потом получаем тип класса
            // из текстового имени класса
            //string sGetType = "EspritTechnology." + sClassName + ", ESP_GOSTToolSheetAddIn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            //Type elementType = Type.GetType(sGetType);
            
            //Type tType = typeof(ToolMillEndMill);
            //string assemblyName = tType.AssemblyQualifiedName.ToString();

            //string sGetType = "EspritTechnology.ToolLatheMiniBoring, ESP_GOSTToolSheetAddIn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            //Type elementType = Type.GetType(sGetType);

            //if (elementType != null)
            //{
            //    object list = Activator.CreateInstance(elementType);
            //    Technology tSelectedTool = (Technology) list;
            //}
            
            //Type listType = typeof(List<>).MakeGenericType(new Type[] { elementType });
            //object list = Activator.CreateInstance<"EspritTechnology.ToolLatheGroove">();

            //object list = Activator.CreateInstance("ToolMillUndercutMill"); Activator.CreateInstance<Person>();
            //object list = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("EspritTechnology.ToolLatheGroove");
            //echnology tSelectedTool = (Technology) list;
            
        }

        void fillFrmList(string sClassName)
        {
            Technology espTool = null;

            switch (sClassName)
            {
                case "ToolMillEndMill":
                    ToolMillEndMill espToolMillEndMill = new ToolMillEndMill();
                    espTool = (Technology) espToolMillEndMill;
                    break;
                case "ToolMillDrill":
                    ToolMillDrill espToolMillDrill = new ToolMillDrill();
                    espTool = (Technology) espToolMillDrill;
                    break;
                case "ToolMillCenterDrill":
                    ToolMillCenterDrill espToolMillCenterDrill = new ToolMillCenterDrill();
                    espTool = (Technology)espToolMillCenterDrill;
                    break;
                case "ToolMillTap":
                    ToolMillTap espToolMillTap = new ToolMillTap();
                    espTool = (Technology)espToolMillTap;
                    break;
                case "ToolMillReamer":
                    ToolMillReamer ToolMillReamer = new ToolMillReamer();
                    espTool = (Technology)ToolMillReamer;
                    break;
                case "ToolMillBoringBar":
                    ToolMillBoringBar ToolMillBoringBar = new ToolMillBoringBar();
                    espTool = (Technology)ToolMillBoringBar;
                    break;
                case "ToolMillBullNose":
                    ToolMillBullNose ToolMillBullNose = new ToolMillBullNose();
                    espTool = (Technology)ToolMillBullNose;
                    break;
                case "ToolMillFaceMill":
                    ToolMillFaceMill ToolMillFaceMill = new ToolMillFaceMill();
                    espTool = (Technology)ToolMillFaceMill;
                    break;
                case "ToolMillBallMill":
                    ToolMillBallMill ToolMillBallMill = new ToolMillBallMill();
                    espTool = (Technology)ToolMillBallMill;
                    break;
                case "ToolMillTaperRadiusEndMill":
                    ToolMillTaperRadiusEndMill ToolMillTaperRadiusEndMill = new ToolMillTaperRadiusEndMill();
                    espTool = (Technology)ToolMillTaperRadiusEndMill;
                    break;
                case "ToolMillChamferMill":
                    ToolMillChamferMill ToolMillChamferMill = new ToolMillChamferMill();
                    espTool = (Technology)ToolMillChamferMill;
                    break;
                case "ToolMillCornerRoundMill":
                    ToolMillCornerRoundMill ToolMillCornerRoundMill = new ToolMillCornerRoundMill();
                    espTool = (Technology)ToolMillCornerRoundMill;
                    break;
                case "ToolMillDoveTail":
                    ToolMillDoveTail ToolMillDoveTail = new ToolMillDoveTail();
                    espTool = (Technology)ToolMillDoveTail;
                    break;
                case "ToolMillCustom":
                    ToolMillCustom ToolMillCustom = new ToolMillCustom();
                    espTool = (Technology)ToolMillCustom;
                    break;
                case "ToolLatheCustom":
                    ToolLatheCustom ToolLatheCustom = new ToolLatheCustom();
                    espTool = (Technology)ToolLatheCustom;
                    break;
                case "ToolLatheTurning":
                    ToolLatheTurning ToolLatheTurning = new ToolLatheTurning();
                    espTool = (Technology)ToolLatheTurning;
                    break;
                case "ToolLatheTopNotch":
                    ToolLatheTopNotch ToolLatheTopNotch = new ToolLatheTopNotch();
                    espTool = (Technology)ToolLatheTopNotch;
                    break;
                case "ToolLatheLayDown":
                    ToolLatheLayDown ToolLatheLayDown = new ToolLatheLayDown();
                    espTool = (Technology)ToolLatheLayDown;
                    break;
                case "ToolMillThreadMill":
                    ToolMillThreadMill ToolMillThreadMill = new ToolMillThreadMill();
                    espTool = (Technology)ToolMillThreadMill;
                    break;
                case "ToolLatheMiniTurning":
                    ToolLatheMiniTurning ToolLatheMiniTurning = new ToolLatheMiniTurning();
                    espTool = (Technology)ToolLatheMiniTurning;
                    break;
                case "ToolLatheMiniGrooving":
                    ToolLatheMiniGrooving ToolLatheMiniGrooving = new ToolLatheMiniGrooving();
                    espTool = (Technology)ToolLatheMiniGrooving;
                    break;
                case "ToolLatheMiniBoring":
                    ToolLatheMiniBoring ToolLatheMiniBoring = new ToolLatheMiniBoring();
                    espTool = (Technology)ToolLatheMiniBoring;
                    break;
                case "ToolMillSlotMill":
                    ToolMillSlotMill ToolMillSlotMill = new ToolMillSlotMill();
                    espTool = (Technology)ToolMillSlotMill;
                    break;
                case "ToolMillUndercutMill":
                    ToolMillUndercutMill ToolMillUndercutMill = new ToolMillUndercutMill();
                    espTool = (Technology)ToolMillUndercutMill;
                    break;
            }

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
            MessageBox.Show(lstParameters.Count().ToString());

            listEspStandardParameters.Items.Clear();

            foreach (string sValue in lstParameters)
                listEspStandardParameters.Items.Add(sValue);
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            // Получили название инструмента
            string sToolTypeName = lstTools.GetItemText(lstTools.SelectedItem);

            for (int i = 0; i < gostToolsArray.Count(); i++)
            {
                if (String.Equals(gostToolsArray[i].toolName, sToolTypeName))
                {
                    replaceSelectedElements(i);
                    break;
                }
            }                       
        }
//----------------------------------------------------------------------------------------
        private void replaceSelectedElements(int gostToolNumber)
        {
            int count = listEspStandardParameters.SelectedItems.Count;
            for (int j = 0; j < count; j++)
            {
                // Надо записать имя выбранного паремтра
                ToolParameter newParameter = new ToolParameter();

                string sItemName = listEspStandardParameters.SelectedItems[0].Text;
                if (!String.Equals(sItemName, ""))
                {
                    // Добавить в список для карты наладки
                    listEspGostParams.Items.Add(sItemName);
                    // Удалить из списка стандартный парметров
                    listEspStandardParameters.SelectedItems[0].Remove();
                    // Загрузить в структуру
                    newParameter.ParameterName = sItemName;
                    gostToolsArray[gostToolNumber].addParameter(newParameter);                  
                }
            }
        }

//----------------------------------------------------------------------------------------
        private void toolStripCreate_Click(object sender, EventArgs e)
        {
            CreateUserParameters frmNewUserParameter = new CreateUserParameters(this);
            frmNewUserParameter.ShowDialog();
        }
        //----------------------------------------------------------------------------------------
        public void addNewUserParameter(string sUserParamName)
        {
            // Надо записать имя выбранного паремтра
            ToolParameter newParameter = new ToolParameter();
            newParameter.ParameterName = sUserParamName;

            // Получили название инструмента
            string sToolTypeName = lstTools.GetItemText(lstTools.SelectedItem);

            for (int i = 0; i < gostToolsArray.Count(); i++)
            {
                if (String.Equals(gostToolsArray[i].toolName, sToolTypeName))
                {
                    // Добавить в список для карты наладки
                    listEspGostParams.Items.Add(sUserParamName);
                    gostToolsArray[i].addParameter(newParameter);
                    break;
                }
            }
        }

    }
}
