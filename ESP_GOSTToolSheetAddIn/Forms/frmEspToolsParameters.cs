using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using EspritTechnology;
using ESP_GOSTToolSheetAddIn.Resources;
using ESP_GOSTToolSheetAddIn.Forms;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

namespace ESP_GOSTToolSheetAddIn
{

    /// <summary>
    ///     Класс-форма редактирования параметров инструмента, которые необходимо загрузить в карту наладки
    /// </summary>
    public partial class frmEspToolsParameters : Form
    {
        GostTool[] localArreyTool = AdditionalToolParameters.gostToolsArray;
        Technology g_espTool = null;

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
            //// Загружаем из файл-шаблона названия инструмента, заполняя форму.
            //XmlDocument xDoc = new XmlDocument();
            //xDoc.Load(StringResource.xmlPathToolsParams);
            //XmlElement xRoot = xDoc.DocumentElement;
            
            // TODO - Переписать метод

            //// выбор всех инструментов
            //XmlNodeList childnodes = xRoot.SelectNodes(StringResource.xmlElementName);
            //// Создание массива инструментов
            //AdditionalToolParameters.gostToolsArray = new GostTool[childnodes.Count-1];
            //int i = 0;
            //foreach (XmlNode node in childnodes)
            //{                
            //    int iToolId = int.Parse(node.SelectSingleNode("@" + StringResource.xmlToolID).Value);
            //    if (iToolId != 0)
            //    {
            //        XmlNode singleNodeLable = node.SelectSingleNode("@" + StringResource.xmlToolLabel);
            //        string sToolLabel = singleNodeLable.Value;
            //        XmlNode singleNodeName = node.SelectSingleNode("@" + StringResource.xmlToolName);
            //        string sToolName = singleNodeName.Value;

            //        if (i == 0)
            //        {
            //            fillFrmList(sToolName);
            //        }

            //         AdditionalToolParameters.gostToolsArray[i] = new GostTool();
            //         AdditionalToolParameters.gostToolsArray[i].toolID = iToolId;
            //         AdditionalToolParameters.gostToolsArray[i].toolLabel = sToolLabel;
            //         AdditionalToolParameters.gostToolsArray[i].toolName = sToolName;                    
            //        i++;

            //        lstTools.Items.Add(sToolLabel);
            //    }
            //}

            // Заполняем список инструментов доступных в системе
            foreach (GostTool curTool in AdditionalToolParameters.gostToolsArray)
            {
                lstTools.Items.Add(curTool.toolLabel);
            }
            // Выделяем первый инструмент в списке
            lstTools.SelectedIndex = 0;
            //Заполняем список параметров инструментов для первого интсремента в списке
            //fillFrmList(AdditionalToolParameters.gostToolsArray[0].toolName);
            fillFrmParametersList(AdditionalToolParameters.gostToolsArray[0].toolName);

            // Загрузить параметры из файла
            //loadPatternParameterFile( AdditionalToolParameters.gostToolsArray);
            // Заполнить список параметров инструменты, которые надо отобразить в отчете
            fillFrmReportList( AdditionalToolParameters.gostToolsArray[0].toolName);
        }

        private void listEspStandardParameters_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void listEspStandardParameters_DragDrop(object sender, DragEventArgs e)
        {
            listEspGostParams.Items.Add(e.Data.ToString());
        }
        
        //----------------------------------------------------------------------------------------
        // Выбор инструмента из списка
        private void lstTools_Click(object sender, EventArgs e)
        {
            // Получили название инструмента
            string sItemName = lstTools.GetItemText(lstTools.SelectedItem);

            // Получили название класса инструмента
            // Загружаем из файл-шаблона названия инструмента, заполняя форму.
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Connect.assemblyFolder + StringResource.xmlPathToolsParams);
            XmlElement xRoot = xDoc.DocumentElement;

            // выбор всех инструментов "user[@name='Bill Gates']"
            XmlNode childNode = xRoot.SelectSingleNode(
                StringResource.xmlElementName + "[@" + 
                StringResource.xmlToolLabel + "='" + sItemName + "']");

            XmlAttributeCollection xmlCollection = childNode.Attributes;
            string sClassName = xmlCollection.Item(0).Value;

            //fillFrmList(sClassName);
            fillFrmParametersList(sClassName);

            listEspGostParams.Items.Clear();
            fillFrmReportList(sClassName);

            Console.WriteLine("test");                       
        }

        //----------------------------------------------------------------------------------------
        private void fillFrmReportList(String toolName)
        {
            // находим инструмент из списка
            for (int i = 0; i <  AdditionalToolParameters.gostToolsArray.Count(); i++)
            {
                if (String.Equals( AdditionalToolParameters.gostToolsArray[i].toolName, toolName))
                {
                    for (int j = 0; j <  AdditionalToolParameters.gostToolsArray[i].parameters.Count(); j++)
                    {
                        ToolParameter reportParameter =  AdditionalToolParameters.gostToolsArray[i].parameters.getParameter(j);
                        string[] arrParams = new string[4];
                        arrParams[0] = reportParameter.Capture;
                        arrParams[1] = reportParameter.Name;
                        arrParams[2] = reportParameter.Type;
                        arrParams[3] = reportParameter.CLCode.ToString();

                        // Добавить в список на форме для карты наладки
                        ListViewItem newItem = new ListViewItem(arrParams);
                        listEspGostParams.Items.Add(newItem);                        
                    }
                    break;
                }
            }

        }

        void fillFrmParametersList(string technologyName)
        {
            TechnologyUtility techUtil = Connect.sEspDocument.TechnologyUtility;
            EspritTechnology.ITechnology espTech = null;

            listEspStandardParameters.Items.Clear();

            try
            {
                espTech = techUtil.CreateTechnology(getTechnologyType(technologyName), Connect.sEspDocument.SystemUnit);
            }
            catch (Exception E)
            {
                MessageBox.Show("Ошмбка при создании технологии \n" + E.Message);
            }

            if (espTech == null)
                MessageBox.Show("espTool is NULL !!!");

            for (int iParam = 1; iParam < espTech.Count; iParam++)
            {
                string[] arrParams = new string[3];
                arrParams[0] = espTech[iParam].Caption;
                arrParams[1] = espTech[iParam].Name;
                arrParams[2] = espTech[iParam].ClCode.ToString();

                ListViewItem newItem = new ListViewItem(arrParams);
                listEspStandardParameters.Items.Add(newItem);
            }
        }

        //----------------------------------------------------------------------------------------
        // Заполнение списка на форме стандартных параметров инструмента
        private EspritConstants.espTechnologyType getTechnologyType(string sClassName)
        {
            switch (sClassName)
            {
                case "ToolMillEndMill":
                    return EspritConstants.espTechnologyType.espToolMillEndMill;
                case "ToolMillDrill":
                    return EspritConstants.espTechnologyType.espToolMillDrill;
                case "ToolMillCenterDrill":
                    return EspritConstants.espTechnologyType.espToolMillCenterDrill;
                case "ToolMillTap":
                    return EspritConstants.espTechnologyType.espToolMillTap;
                case "ToolMillReamer":
                    return EspritConstants.espTechnologyType.espToolMillReamer;
                case "ToolMillBoringBar":
                    return EspritConstants.espTechnologyType.espToolMillBoringBar;
                case "ToolMillBullNose":
                    return EspritConstants.espTechnologyType.espToolMillBullNose;
                case "ToolMillFaceMill":
                    return EspritConstants.espTechnologyType.espToolMillFaceMill;
                case "ToolMillBallMill":
                    return EspritConstants.espTechnologyType.espToolMillBallMill;
                case "ToolMillTaperRadiusEndMill":
                    return EspritConstants.espTechnologyType.espToolMillTaperRadiusEndMill;
                case "ToolMillChamferMill":
                    return EspritConstants.espTechnologyType.espToolMillChamferMill;
                case "ToolMillCornerRoundMill":
                    return EspritConstants.espTechnologyType.espToolMillCornerRoundMill;
                case "ToolMillDoveTail":
                    return EspritConstants.espTechnologyType.espToolMillDoveTail;
                case "ToolMillCustom":
                    return EspritConstants.espTechnologyType.espToolMillCustom;
                case "ToolLatheCustom":
                    return EspritConstants.espTechnologyType.espToolLatheCustom;
                case "ToolLatheTurning":
                    return EspritConstants.espTechnologyType.espToolLatheTurning;
                case "ToolLatheGroove":
                    return EspritConstants.espTechnologyType.espToolLatheGroove;
                case "ToolLatheTopNotch":
                    return EspritConstants.espTechnologyType.espToolLatheTopNotch;
                case "ToolLatheLayDown":
                    return EspritConstants.espTechnologyType.espToolLatheLayDown;
                case "ToolMillThreadMill":
                    return EspritConstants.espTechnologyType.espToolMillThreadMill;
                case "ToolLatheMiniTurning":
                    return EspritConstants.espTechnologyType.espToolLatheMiniTurning;
                case "ToolLatheMiniGrooving":
                    return EspritConstants.espTechnologyType.espToolLatheMiniGrooving;
                case "ToolLatheMiniBoring":
                    return EspritConstants.espTechnologyType.espToolLatheMiniBoring;
                case "ToolMillSlotMill":
                    return EspritConstants.espTechnologyType.espToolMillSlotMill;
                case "ToolMillUndercutMill":
                    return EspritConstants.espTechnologyType.espToolMillUndercutMill;
                default :
                    return EspritConstants.espTechnologyType.espToolMillCustom;
            }
        }

        //----------------------------------------------------------------------------------------
        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            // Получили название инструмента
            string sToolTypeName = lstTools.GetItemText(lstTools.SelectedItem);

            for (int i = 0; i <  AdditionalToolParameters.gostToolsArray.Count(); i++)
            {
                if (String.Equals( AdditionalToolParameters.gostToolsArray[i].toolLabel, sToolTypeName))
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
                string[] arrParams = new string[4];
                arrParams[0] =  listEspStandardParameters.SelectedItems[0].SubItems[0].Text;
                arrParams[1] =  listEspStandardParameters.SelectedItems[0].SubItems[1].Text;
                arrParams[2] = StringResource.xmlParamStandartType;
                arrParams[3] =  listEspStandardParameters.SelectedItems[0].SubItems[2].Text;

                if (!String.Equals(arrParams[0], ""))
                {
                    // Добавить в список на форме для карты наладки
                    ListViewItem newItem = new ListViewItem(arrParams);
                    listEspGostParams.Items.Add(newItem);

                    // Удалить из списка стандартный парметров
                    listEspStandardParameters.SelectedItems[0].Remove();

                    newParameter.Capture = arrParams[0];
                    newParameter.Name = arrParams[1];
                    newParameter.Type = arrParams[2];
                    newParameter.CLCode = int.Parse(arrParams[3]);
                    
                     AdditionalToolParameters.gostToolsArray[gostToolNumber].addParameter(newParameter);
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
            // Получили название инструмента
            string sToolTypeName = lstTools.GetItemText(lstTools.SelectedItem);
            // Ищем нужный инструмент
            for (int i = 0; i <  AdditionalToolParameters.gostToolsArray.Count(); i++)
            {
                if (String.Equals( AdditionalToolParameters.gostToolsArray[i].toolLabel, sToolTypeName))
                {
                    int newUserClCode = AdditionalToolParameters.gostToolsArray[i].getMaxClCodeValue();
                    if (newUserClCode < int.Parse(StringResource.startUserCLCodeNumber))
                    {
                        newUserClCode = int.Parse(StringResource.startUserCLCodeNumber);
                    }
                    else
                    {
                        newUserClCode++;
                    }

                    // Надо записать имя выбранного паремтра
                    ToolParameter newParameter = new ToolParameter();
                    newParameter.Capture = sUserParamName;
                    newParameter.Type = StringResource.xmlParamUserType;
                    newParameter.CLCode = newUserClCode;

                    string[] arrParams = new string[4];
                    arrParams[0] = newParameter.Capture;
                    arrParams[1] = "---";
                    arrParams[2] = StringResource.xmlParamUserType;
                    arrParams[3] = newUserClCode.ToString();

                    // Добавить в список для карты наладки
                    ListViewItem newItem = new ListViewItem(arrParams);                    
                    listEspGostParams.Items.Add(newItem);
                     AdditionalToolParameters.gostToolsArray[i].addParameter(newParameter);
                    break;
                }
            }
        }

        //----------------------------------------------------------------------------------------
        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            string sToolTypeName = lstTools.GetItemText(lstTools.SelectedItem);
            int iCurrentTool = 0;

            for (int i = 0; i <  AdditionalToolParameters.gostToolsArray.Count(); i++)
            {
                if (String.Equals( AdditionalToolParameters.gostToolsArray[i].toolLabel, sToolTypeName))
                {
                    iCurrentTool = i;
                }
            }

            int count = listEspGostParams.SelectedItems.Count;
            for (int j = 0; j < count; j++)
            {
                string[] arrParams = new string[3];
                arrParams[0] = listEspGostParams.SelectedItems[0].SubItems[0].Text;
                arrParams[1] = listEspGostParams.SelectedItems[0].SubItems[1].Text;
                arrParams[2] = listEspGostParams.SelectedItems[0].SubItems[3].Text;

                // Если тип стандартный
                if (String.Equals(listEspGostParams.SelectedItems[0].SubItems[2].Text, StringResource.xmlParamStandartType))
                {
                    // Возвращаем в список стандартный параметров
                    ListViewItem newItem = new ListViewItem(arrParams);
                    listEspStandardParameters.Items.Add(newItem);
                }
                 // Удаление через Cl Code          
                 AdditionalToolParameters.gostToolsArray[iCurrentTool].removeParameter(arrParams[1]);
                // Удаление строки, удаляем с начала
                listEspGostParams.SelectedItems[0].Remove();
            }
        }
        //----------------------------------------------------------------------------------------
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //----------------------------------------------------------------------------------------
        private void btnOK_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("OK");
            // TODO: Из массива  AdditionalToolParameters.gostToolsArray[iCurrentTool] записать все параметры в XML файл
            // который потом будет использоваться для заполнения карты наладки и
            // закрыть форму             
            AdditionalToolParameters.savePatternParameterFile( AdditionalToolParameters.gostToolsArray, Connect.assemblyFolder);
            this.Close();
        }

        //----------------------------------------------------------------------------------------
        private void btnApply_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Apply");
            //TODO: Только записать параметры в файл для текущего инструмента
            AdditionalToolParameters.savePatternParameterFile( AdditionalToolParameters.gostToolsArray, Connect.assemblyFolder);
        }

        //----------------------------------------------------------------------------------------
        private void loadPatternParameterFile(GostTool[] toolsArray)
        {
            if (!File.Exists(Connect.assemblyFolder + StringResource.xmlPathPattrenFileName))
            {
                AdditionalToolParameters.creatPatternFile(Connect.assemblyFolder + StringResource.xmlPathPattrenFileName);
                return;
            }

            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(Connect.assemblyFolder + StringResource.xmlPathPattrenFileName);
            // get root element
            XmlElement xmlRoot = XmlDoc.DocumentElement;
            // select all tools
            XmlNodeList allToolsList = xmlRoot.SelectNodes(StringResource.xmlElementName);
            int index = 0;
            foreach (XmlNode nodeTool in allToolsList)
            {
                XmlNode singleNodeName = nodeTool.SelectSingleNode("@" + StringResource.xmlToolName);
                string sToolName = singleNodeName.Value;
                if (String.Equals(sToolName, toolsArray[index].toolName))
                {
                    XmlNodeList parametersList = nodeTool.ChildNodes;
                    for (int i = 0; i < parametersList.Count; i++)
                    {
                        ToolParameter newParam = new ToolParameter();
                        newParam.Name = parametersList[i].SelectSingleNode("@" + StringResource.xmlParameterName).Value;
                        newParam.Capture = parametersList[i].SelectSingleNode("@" + StringResource.xmlParameterCapture).Value;
                        newParam.Type = parametersList[i].SelectSingleNode("@" + StringResource.xmlParameterType).Value;
                        newParam.CLCode = int.Parse( parametersList[i].SelectSingleNode("@" + StringResource.xmlParameterClCode).Value );

                         AdditionalToolParameters.gostToolsArray[index].addParameter(newParam);
                    }
                }
                index++;
            }
        }



    }
}
