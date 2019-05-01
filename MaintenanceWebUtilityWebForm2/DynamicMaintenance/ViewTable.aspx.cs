using System;
using System.Collections;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tableNameLiteral.Text = Session["MaintenanceTableName"].ToString();
                ViewState["MaintenanceTableName"] = Session["MaintenanceTableName"].ToString();
            }
            GetData();
            ViewTable_GridView.DataKeyNames = new string[] { ViewTable_GridView.HeaderRow.Cells[1].Text};
        }
        
        protected void InsertRow_LinkBtn_OnClick(object sender, EventArgs e)
        {
            Session["MaintenanceTableName"] = ViewState["MaintenanceTableName"];
            Response.Redirect("Create");
        }
        protected void ViewTable_GridView_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            ViewTable_GridView.EditIndex = e.NewEditIndex;
            GetData();
            
            TableRow row = ViewTable_GridView.Rows[e.NewEditIndex];
            //set pk to read only
            //(row.Cells[1].Controls[0] as TextBox).Enabled = false;

            SetEditRowCssClass(row);
            SetEditRowDateInputType(row);
        }
        protected void ViewTable_GridView_OnRowCancelingEdit(object sender, EventArgs e)
        {
            ViewTable_GridView.EditIndex = -1;
            GetData();
        }
        protected void ViewTable_GridView_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = ViewTable_GridView.Rows[e.RowIndex];
            ArrayList dataHeader = new ArrayList();
            ArrayList dataValues = new ArrayList();
            ArrayList dataTypes = new ArrayList();
            Control control = new Control();
            var controlType = typeof(Type);

            //populate dataValues, dataTypes, and dataHeaders
            dataTypes = GetDataTypes();
            dataHeader = GetHeaderRowValues(ViewTable_GridView);
            for (int i = 1; i < row.Cells.Count; i++)
            {
                control = row.Cells[i].Controls[0];
                controlType = control.GetType();
                if (controlType.Name == "TextBox")
                {
                    dataValues.Add(((TextBox)control).Text);
                }
                else if (controlType.Name == "CheckBox")
                {
                    dataValues.Add(((CheckBox)control).Checked);
                }
            }

            ViewTable_GridView.EditIndex = -1;

            string constr = ConfigurationManager.ConnectionStrings["MaintenanceWebUtilityDbEntitiesDataSource"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                string sql = $"UPDATE {ViewState["MaintenanceTableName"]} SET ";
                bool isNumType;
                //loop through dataheader, datavalues and datatypes per iteration
                for (int i = 1; i < dataHeader.Count; i++)
                {
                    sql += dataHeader[i] + "=";
                    isNumType = CheckIfSqlNumType(dataTypes[i].ToString());
                    if (isNumType)
                    {
                        sql += dataValues[i] + ", ";
                    }
                    else
                    {
                        sql += "'" + dataValues[i] + "', ";
                    }
                }
                sql = sql.Substring(0, sql.Length - 2);

                sql += " WHERE " + dataHeader[0] + "=";
                isNumType = CheckIfSqlNumType(dataTypes[0].ToString());
                if (isNumType)
                {
                    sql += dataValues[0];
                }
                else
                {
                    sql += "'" + dataValues[0] + "'";
                }

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            //conn.Open();
            //SqlCommand cmd = new SqlCommand("update detail set name='" + textName.Text + "',address='" + textadd.Text + "',country='" + textc.Text + "'where id='" + userid + "'", conn);
            //cmd.ExecuteNonQuery();
            //conn.Close();
            GetData();
        }
        protected void ViewTable_GridView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int pkId = Convert.ToInt32(ViewTable_GridView.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["MaintenanceWebUtilityDbEntitiesDataSource"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            { 
                using (SqlCommand cmd = new SqlCommand($"DELETE FROM {ViewState["MaintenanceTableName"]} WHERE {ViewTable_GridView.DataKeyNames[0]} = {pkId}"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GetData();
        }
        private ArrayList GetHeaderRowValues(GridView gv)
        {
            GridViewRow row = gv.HeaderRow;
            ArrayList values = new ArrayList();

            for (int i = 1; i < row.Cells.Count; i++)
            {
                values.Add(row.Cells[i].Text);
            }
            return values;
        }
        private ArrayList GetDataTypes()
        {
            ArrayList values = new ArrayList();
            string constr = ConfigurationManager.ConnectionStrings["MaintenanceWebUtilityDbEntitiesDataSource"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = $"SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH FROM information_schema.columns WHERE TABLE_NAME = @TableName";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = ViewState["MaintenanceTableName"];
                    con.Open();
                    var data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        values.Add(new ArrayList() { data["COLUMN_NAME"].ToString(), data["DATA_TYPE"].ToString(), data["CHARACTER_MAXIMUM_LENGTH"].ToString() });
                    }
                }
            }
            return values;
        }
        private bool CheckIfSqlNumType(string s)
        {
            s = s.ToLower();
            if(s.Equals("bigint") || s.Equals("int") || s.Equals("tinyint") || s.Equals("smallint"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void GetData()
        {
            DataTable table = new DataTable();
            string constr = ConfigurationManager.ConnectionStrings["MaintenanceWebUtilityDbEntitiesDataSource"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                // write the sql statement to execute   
                string sql = $"SELECT * FROM {ViewState["MaintenanceTableName"]}";
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
        private void SetEditRowCssClass(TableRow row)
        {
            for (int i = 2; i < row.Cells.Count; i++)
            {
                var controlType = row.Cells[i].Controls[0].GetType();
                if (controlType.Name == "TextBox")
                {
                    (row.Cells[i].Controls[0] as TextBox).CssClass = "form-control";
                }
                else if (controlType.Name == "CheckBox")
                {
                    
                }
                
            }
        }
        private void SetEditRowDateInputType(TableRow row)
        {
            ArrayList dataTypes = GetDataTypes();
            
            for (int i = 0; i < dataTypes.Count; i++)
            {
                if((dataTypes[i] as ArrayList)[1].ToString() == "date")
                {
                    //Item.EncodingEndDate.Value.ToString("yyyy-MM-ddTHH:mm:ss")
                    //DateTime encodingStartDate = DateTime.TryParse(encodingStartDateTextBox.Text, out encodingStartDate) ? Convert.ToDateTime(encodingStartDateTextBox.Text) : default(DateTime);
                    DateTime date;
                    (row.Cells[i + 1].Controls[0] as TextBox).Text = DateTime.TryParse((row.Cells[i + 1].Controls[0] as TextBox).Text, out date) ? date.ToString("yyyy-MM-dd") : default(DateTime).ToString();
                    (row.Cells[i + 1].Controls[0] as TextBox).Attributes.Add("Type", "date");
                }
                else if((dataTypes[i] as ArrayList)[1].ToString() == "datetime")
                {
                    DateTime date;
                    (row.Cells[i + 1].Controls[0] as TextBox).Text = DateTime.TryParse((row.Cells[i + 1].Controls[0] as TextBox).Text, out date) ? date.ToString("yyyy-MM-ddTHH:mm:ss") : default(DateTime).ToString();
                    (row.Cells[i + 1].Controls[0] as TextBox).Attributes.Add("Type", "datetime-local");
                }


            }
            
        }

        
    }
}