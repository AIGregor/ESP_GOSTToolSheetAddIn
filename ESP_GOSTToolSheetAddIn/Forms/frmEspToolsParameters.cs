﻿using System;
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

                    if (i == 0)
                    {
                        fillFrmList(sToolName);
                    }

                    gostToolsArray[i] = new GostTool();
                    gostToolsArray[i].toolID = iToolId;
                    gostToolsArray[i].toolLabel = sToolLabel;
                    gostToolsArray[i].toolName = sToolName;                    
                    i++;
                                        
                    lstTools.Items.Add(sToolLabel);
                }
            }

            // Устанавливаем список сортировки "Все инструменты"
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
//----------------------------------------------------------------------------------------
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
        }

        private Technology getTechnologyByName(String strTechName)
        {
            g_espTool = (Technology)new ToolMillEndMill();
            return g_espTool;
        }


        //----------------------------------------------------------------------------------------
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
            // Очистить форму
            listEspStandardParameters.Items.Clear();

            IEnumerator enumerator = espTool.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Parameter item = (Parameter)enumerator.Current;

                string[] arrParams = new string[3];
                arrParams[0] = item.Caption;
                arrParams[1] = item.Name;
                arrParams[2] = item.ClCode.ToString();

                ListViewItem newItem = new ListViewItem(arrParams);
                listEspStandardParameters.Items.Add(newItem);
            }

            listEspStandardParameters.Sort();                                   
            MessageBox.Show(listEspStandardParameters.Items.Count.ToString());
        }

//----------------------------------------------------------------------------------------
        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            // Получили название инструмента
            string sToolTypeName = lstTools.GetItemText(lstTools.SelectedItem);

            for (int i = 0; i < gostToolsArray.Count(); i++)
            {
                if (String.Equals(gostToolsArray[i].toolLabel, sToolTypeName))
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

                    newParameter.Name = arrParams[1];
                    newParameter.CLCode = int.Parse(arrParams[3]);

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
            newParameter.Name = sUserParamName;

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

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            string sToolTypeName = lstTools.GetItemText(lstTools.SelectedItem);
            int iCurrentTool = 0;

            for (int i = 0; i < gostToolsArray.Count(); i++)
            {
                if (String.Equals(gostToolsArray[i].toolLabel, sToolTypeName))
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
                 gostToolsArray[iCurrentTool].removeParameter(int.Parse(arrParams[2]));
                // Удаление строки
                listEspGostParams.SelectedItems[j].Remove();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OK");
            // TODO: Из массива gostToolsArray[iCurrentTool] записать все параметры в XML файл
            // который потом будет использоваться для заполнения карты наладки и
            // закрыть форму 

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Apply");
            //TODO: Только записать параметры в файл для текущего инструмента
        }
    }
}
