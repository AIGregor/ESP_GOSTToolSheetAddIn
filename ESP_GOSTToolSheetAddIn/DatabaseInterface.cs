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
                string sqlQuery = "select fldfkCuttingToolId_tblCuttingToolParameter from tblCuttingToolParameter" +
                    " where fldValue_tblCuttingToolParameter = @ToolDocID;";

                if (connectionString == "")
                    loadConnectionString();

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand cmd = sqlConnection.CreateCommand();
                sqlConnection.Open();

                cmd.CommandText = sqlQuery;
                cmd.Parameters.AddWithValue("@ToolDocID", toolDocumentID);

                // Получаем значение пользовательского параметра                
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    Guid CuttingToolGuid = new Guid();
                    CuttingToolGuid = (Guid) result;
                    CuttingToolID = CuttingToolGuid.ToString();
                }               
                             
                sqlConnection.Close();
            }
            catch (Exception E)
            {
                Console.WriteLine(E);
                throw;
            }

            return CuttingToolID;
        }

        // Определить соединение локально или к серверу
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
        public DataTable getUsersParamsByID(string docToolID)
        {
            string sqlQuery = "SELECT * FROM tblCuttingToolParameter WHERE" + 
                              " fldCLFileCode_tblCuttingToolParameter > @MaxCLCodeUsersParams AND" +
                              " fldfkCuttingToolId_tblCuttingToolParameter = @TooID;";
            DataTable dataTable = new DataTable();

            if (connectionString == "")
                loadConnectionString();

            try
            {   //TODO: Check is Empty connection string 
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                //SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandText = sqlQuery;
                cmd.Parameters.AddWithValue("@MaxCLCodeUsersParams", int.Parse(StringResource.startUserCLCodeNumber));
                cmd.Parameters.AddWithValue("@TooID", docToolID);

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

        // Получить значение ОДНОГО параметра по ID  инструменту и CL коду
        public string getUsersParamValue(string docToolID, int clCode)
        {
            string userParamValue = "";

            if (docToolID == "" || clCode == 0)
            {
                return userParamValue;
            }

            string sqlQuery = "SELECT fldValue_tblCuttingToolParameter FROM tblCuttingToolParameter WHERE" +
                  " fldCLFileCode_tblCuttingToolParameter = @CLCodeUsersParams AND" +
                  " fldfkCuttingToolId_tblCuttingToolParameter = @TooID;";

            if (connectionString == "")
                loadConnectionString();

            try
            {   //TODO: Check is Empty connection string 
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                //SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection);
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandText = sqlQuery;
                cmd.Parameters.AddWithValue("@CLCodeUsersParams", clCode);
                cmd.Parameters.AddWithValue("@TooID", docToolID);

                // Получаем значение пользовательского параметра                
                userParamValue = (string) cmd.ExecuteScalar();

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (userParamValue == null)
                return "";

            return userParamValue;
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
                DataTable dbUsersParams = getUsersParamsByID(curGostTool.dataBaseToolID);

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

        // Заполнение значений ВСЕХ пользовательских параметров только для одного инструмента
        public bool fillUsersParamsGostTool(GostTool GostTool)
        {
            bool result = true;
            // Получаем ID из БД по ID инструмента из документа
            if (GostTool.dataBaseToolID == "")
            {
                string cuttingToolID = getCuttingToolID(GostTool.toolDocumentID);
                GostTool.dataBaseToolID = cuttingToolID;
            }
            // Получаем список пользовательских параметров из БД
            DataTable dbUsersParams = getUsersParamsByID(GostTool.dataBaseToolID);
            if (dbUsersParams.Rows.Count == 0)
                return false;

            // проходим по всем пользовательским параметрам и заполняем значениями 
            for (int j = 0; j < GostTool.parameters.Count(); j++)
            {
                DataRow[] userParameterRows;
                ToolParameter curToolParameter = GostTool.parameters.getParameter(j);

                if (String.Equals(curToolParameter.Type, StringResource.xmlParamUserType))
                {
                    // поиска параметра
                    userParameterRows = dbUsersParams.Select("fldCLFileCode_tblCuttingToolParameter = " + curToolParameter.CLCode.ToString());
                    
                    // Сохраняем значение в структуре
                    curToolParameter.Value = userParameterRows[0][0].ToString();
                }
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
                                        
                    string newSQLQuery =" IF EXISTS (SELECT * FROM tblCuttingToolParameter WHERE fldCLFileCode_tblCuttingToolParameter = @CLCode" + 
                                        "    AND fldfkCuttingToolId_tblCuttingToolParameter = @ToolID)" +
                                        " BEGIN"  +
                                        "    UPDATE tblCuttingToolParameter" +
                                        "    SET fldValue_tblCuttingToolParameter = @Value" +
                                        "    WHERE fldCLFileCode_tblCuttingToolParameter = @CLCode" + 
                                        "       AND fldfkCuttingToolId_tblCuttingToolParameter = @ToolID" +
                                        " END" +
                                        " ELSE" +
                                        " BEGIN" +
                                        "   INSERT INTO tblCuttingToolParameter" +
                                        "   (fldCLFileCode_tblCuttingToolParameter, " +
                                        "   fldfkCuttingToolId_tblCuttingToolParameter," +
                                        "   fldValue_tblCuttingToolParameter) " +
                                        "   VALUES (@CLCode, @ToolID, @Value)" +
                                        " END;";

                    //string sql = "INSERT INTO tblCuttingToolParameter" + 
                    //                " (fldCLFileCode_tblCuttingToolParameter, " +
                    //                " fldfkCuttingToolId_tblCuttingToolParameter," + 
                    //                " fldValue_tblCuttingToolParameter) " +
                    //                " VALUES (@CLCode, @ToolID, @Value)";

                    // Обязательно должен быть ID и CL код параметра инструмента
                    if (curToolParameter.CLCode == 0 || GostTool.dataBaseToolID == "")
                    {
                        return false;
                    }

                    if (connectionString == "")
                        loadConnectionString();

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = newSQLQuery;
                        cmd.Parameters.AddWithValue("@CLCode", curToolParameter.CLCode);
                        cmd.Parameters.AddWithValue("@ToolID", GostTool.dataBaseToolID);
                        cmd.Parameters.AddWithValue("@Value", curToolParameter.Value);
                        cmd.ExecuteNonQuery();

                        conn.Close();
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
