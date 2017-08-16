using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

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



    }


}
