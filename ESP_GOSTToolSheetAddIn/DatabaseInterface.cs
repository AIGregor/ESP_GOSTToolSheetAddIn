using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ESP_GOSTToolSheetAddIn.Resources;

//TODO: загрузить все параметры инструмента из БД по найденному ID которые больше 80 000
//TODO: добавить найденные параметры в структуру параметров отчета
//TODO: сохранить пользовательсике парметры в БД из структуры отчета

namespace ESP_GOSTToolSheetAddIn
{
    class DatabaseInterface
    {
        private string currentMashineName;
        private string connectionString = "";
           
        // Получить ID инструмента по назаванию
        public string getCuttingToolID(string toolDocumentID)
        {
            string CuttingToolID = "";
            try
            {
                string query = "select fldfkCuttingToolId_tblCuttingToolParameter from tblCuttingToolParameter" +
                    " where fldValue_tblCuttingToolParameter = 'DR 02.5'"; // + toolDocumentID;
                            
                if (connectionString == "")
                    loadConnectionString();

                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                // create data adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtToolID = new DataTable();
                // this will query your database and return the result to your datatable
                da.Fill(dtToolID);

                CuttingToolID = dtToolID.Rows[0][0].ToString();

                conn.Close();
                da.Dispose();
            }
            catch (Exception E)
            {

            }

            return CuttingToolID;
        }

        private void loadConnectionString()
        {
            ReportSettings settings = new ReportSettings();
            settings.loadHostSettings();

            if (settings.useLocalHost)
            {
                currentMashineName = System.Environment.MachineName;
                connectionString = string.Format("Data Source={0}\\KBMSS;Initial Catalog=KBM;Persist Security Info=True;User ID=sa;Password=KBMsa64125#", currentMashineName);
            }
            else
            {
                currentMashineName = settings.hostName;
                connectionString = string.Format("Data Source={0}\\KBMSS;Initial Catalog=KBM;Persist Security Info=True;User ID=sa;Password=KBMsa64125#", currentMashineName);
            }
        }

        //TODO - метод получения таблицы с параметрами инструмента по найденному ID
        public DataTable getUserParamsByID(string docToolID)
        {
            string sqlQuery = "same SQL string where CLCode > 80 000 and toolID = " + docToolID;
            DataTable dataTable = new DataTable();

            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return dataTable;
        }

        //TODO - мотод заполнение значения пользовательских параметров для всех инструментов
        public bool fillUserParamsGostToolArray(GostTool[] GostToolArray)
        {
            bool result = false;
            // перед этим все стандартные параметры уже загружены в структуру
            // цикл по все инструментам получаем их ID и по ниму загружаем список параметров
            for (var i = 0; i < GostToolArray.Length; i++)
            {
                // Получаем ID из БД по ID инструмента из документа
                GostTool curGostTool = GostToolArray[i];
                if (curGostTool.dataBaseToolID == "")
                {
                    string cuttingToolID = getCuttingToolID(curGostTool.toolDocumentID);
                    curGostTool.dataBaseToolID = cuttingToolID;
                }
               // Получаем список пользовательских параметров из БД
                DataTable dbUsersParams = getUserParamsByID(curGostTool.dataBaseToolID);

                // проходим по всем пользовательским параметрам и заполняем значениями 
                for (int j = 0; j < curGostTool.parameters.Count(); j++)
                {
                    DataRow[] userParameterRows;
                    ToolParameter curToolParameter = curGostTool.parameters.getParameter(j);
                    // Сохраняем значение в структуре
                    userParameterRows = dbUsersParams.Select("fldUserCLCode Like " + curToolParameter.CLCode.ToString()); // поиска параметра
                    curToolParameter.Value = userParameterRows[0][0].ToString();
                }
            }
            result = true;
            return result;
        }

        // Заполнение значений пользовательских параметров только для одного инструмента
        public bool fillUserParamsGostTool(GostTool GostTool)
        {
            bool result = true;
            // Получаем ID из БД по ID инструмента из документа
            if (GostTool.dataBaseToolID == "")
            {
                string cuttingToolID = getCuttingToolID(GostTool.toolDocumentID);
                GostTool.dataBaseToolID = cuttingToolID;
            }
            // Получаем список пользовательских параметров из БД
            DataTable dbUsersParams = getUserParamsByID(GostTool.dataBaseToolID);

            // проходим по всем пользовательским параметрам и заполняем значениями 
            for (int j = 0; j < GostTool.parameters.Count(); j++)
            {
                DataRow[] userParameterRows;
                ToolParameter curToolParameter = GostTool.parameters.getParameter(j);
                // поиска параметра
                userParameterRows = dbUsersParams.Select("fldCLFileCode_tblCuttingToolParameter Like " + curToolParameter.CLCode.ToString());
                // Сохраняем значение в структуре
                curToolParameter.Value = userParameterRows[0][0].ToString();
            }
            return result;
        }

        //TODO - сохранение параметров инструмента из структуры в БД
        public bool saveUserToolParams(GostTool GostTool)
        {
            // Цикл по всем параметрам - выбираем с типом пользовательский
            for (int j = 0; j < GostTool.parameters.Count(); j++)
            {
                ToolParameter curToolParameter = GostTool.parameters.getParameter(j);
                if (curToolParameter.Type == StringResource.xmlParamUserType)
                {
                    string sql = "INSERT INTO tblCuttingToolParameter" + 
                                    " (fldCLFileCode_tblCuttingToolParameter, " +
                                    " fldfkCuttingToolId_tblCuttingToolParameter," + 
                                    " fldValue_tblCuttingToolParameter) " +
                                    " VALUES (@CLCode, @ToolID, @Value)";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@CLCode", curToolParameter.CLCode);
                        cmd.Parameters.AddWithValue("@ToolID", GostTool.dataBaseToolID);
                        cmd.Parameters.AddWithValue("@Value", curToolParameter.Capture);
                        cmd.ExecuteNonQuery();                        
                    }
                }
            }
            return true;
        }

        private bool isToolParamExist(ToolParameter toolParam)
        {
            bool result = false;
            return result;
        }

    }


}
