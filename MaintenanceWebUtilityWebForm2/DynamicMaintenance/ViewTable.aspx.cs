using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaintenanceWebUtilityWebForm2.DynamicMaintenance
{
    public partial class ViewTable : System.Web.UI.Page
    {
        string tableName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            tableName = Session["MaintenanceTableName"].ToString();
            tableNameLiteral.Text = tableName;
            ViewState["MaintenanceTableName"] = tableName;
            GetData();
        }
        private void GetData()
        {
            DataTable table = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["MaintenanceWebUtilityDbEntitiesDataSource"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                // write the sql statement to execute   
                string sql = $"SELECT * FROM {tableName}";
                // instantiate the command object to fire    
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // get the adapter object and attach the command object to it    
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        // fire Fill method to fetch the data and fill into DataTable    
                        ad.Fill(table);
                    }
                }
            }
            // specify the data source for the GridView    
            ViewTable_GridView.DataSource = table;
            // bind the data now    
            ViewTable_GridView.DataBind();
        }
        protected void AssignCssPerRow(object sender, EventArgs e)
        {

        }

        protected void ViewTable_GridView_OnRowEditing(object sender, EventArgs e)
        {

        }

        protected void ViewTable_GridView_OnRowCancelingEdit(object sender, EventArgs e)
        {

        }
    }
}