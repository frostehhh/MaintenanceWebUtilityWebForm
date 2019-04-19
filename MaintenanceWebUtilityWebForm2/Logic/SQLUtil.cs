using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MaintenanceWebUtilityWebForm2.Logic
{
    public class SQLUtil
    {
        private string constr = ConfigurationManager.ConnectionStrings["MaintenanceWebUtilityDbEntitiesDataSource"].ConnectionString;

        public bool CheckIfTableExists(string tableName)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("uspCheckIfTableExists"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tableName", tableName);
                    cmd.Connection = con;
                    con.Open();
                    object i = cmd.ExecuteScalar();
                    return (cmd.ExecuteScalar().ToString() == "1") ? true : false;
                }
                
            }
            return false;
        }
    }
}