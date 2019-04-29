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
using System.Diagnostics;

namespace MaintenanceWebUtilityWebForm2.DynamicMaintenance
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ViewState["MaintenanceTableName"] = Session["MaintenanceTableName"].ToString();
            CreatePlaceHolderContents();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }
        protected void CreatePlaceHolderContents()
        {
            ArrayList tableColumnsSchema = GetTableColumnsSchema();
            PlaceHolder pl = EditRow_PlaceHolder;

            //PK or first column will not be rendered.
            pl.Controls.Add(new LiteralControl("<table>"));
            for (int i = 1; i < tableColumnsSchema.Count; i++)
            {
                ArrayList col = (ArrayList)tableColumnsSchema[i];
                string colName = col[0].ToString();
                string datatype = col[1].ToString();

                pl.Controls.Add(new LiteralControl("<tr><td>"));
                Label label = new Label() { Text = colName };
                pl.Controls.Add(label);
                pl.Controls.Add(new LiteralControl("</td><td>"));

                //if textbox, date, or checkbox
                string idText = (i < 10) ? "0" + i.ToString() : i.ToString();
                if (datatype == "date")
                {
                    TextBox tb = new TextBox()
                    {
                        ID = "columnName_Input_" + idText,
                        CssClass = "form-control valid"
                    };
                    tb.Attributes.Add("Type", "date");
                    pl.Controls.Add(tb);
                }
                else if (datatype == "datetime")
                {
                    TextBox tb = new TextBox()
                    {
                        ID = "columnName_Input_" + idText,
                        CssClass = "form-control valid"
                    };
                    tb.Attributes.Add("Type", "datetime-local");
                    pl.Controls.Add(tb);
                }
                else if (datatype == "bit")
                {
                    CheckBox cb = new CheckBox()
                    {
                        ID = "columnName_Input_" + idText
                    };
                    pl.Controls.Add(cb);
                }
                else
                {
                    TextBox tb = new TextBox()
                    {
                        ID = "columnName_Input_" + idText,
                        CssClass = "form-control valid"
                    };
                    pl.Controls.Add(tb);
                }

                pl.Controls.Add(new LiteralControl("</td></tr>"));
            }
            pl.Controls.Add(new LiteralControl("</table>"));
        }
        private ArrayList GetTableColumnsSchema()
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

        protected void InsertRow_LinkBtn_OnClick(object sender, EventArgs e)
        {
            CreateNewSqlRow();
            Session["MaintenanceTableName"] = ViewState["MaintenanceTableName"];
            Response.Redirect("ViewTable");
        }
        private bool CheckIfSqlNumType(string s)
        {
            s = s.ToLower();
            if (s.Equals("bigint") || s.Equals("int") || s.Equals("tinyint") || s.Equals("smallint"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void CreateNewSqlRow()
        {

            string constr = ConfigurationManager.ConnectionStrings["MaintenanceWebUtilityDbEntitiesDataSource"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                ArrayList tableColumnsSchema = GetTableColumnsSchema();
                string sql;
                int id;

                con.Open();

                #region get MAX(ID)
                //get MAX(id)
                sql = $"SELECT MAX({((ArrayList)tableColumnsSchema[0])[0]}) FROM {ViewState["MaintenanceTableName"]}";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    try
                    {
                        id = Convert.ToInt32(cmd.ExecuteScalar());
                        id++;
                    }
                    catch(Exception e)
                    {//run if no records yet
                        id = 1;
                    }
                    
                }
                #endregion

                #region specify columns to insert to
                //specify columns to insert to
                sql = $"INSERT INTO {ViewState["MaintenanceTableName"]} (";
                for (int i = 0; i < tableColumnsSchema.Count; i++)
                {
                    sql += (tableColumnsSchema[i] as ArrayList)[0] + ", ";
                }
                sql = sql.Substring(0, sql.Length - 2);
                sql += $") VALUES({id},";
                #endregion

                //concatenate values ()
                for (int i = 1; i < tableColumnsSchema.Count; i++)
                {
                    #region get controlName
                    string controlName = "columnName_Input_";
                    string value = "";
                    bool isNumType;

                    if (i < 10)
                    {
                        controlName += "0" + i.ToString();
                    }
                    else
                    {
                        controlName += i.ToString();
                    }
                    Control control = EditRow_PlaceHolder.FindControl(controlName);
                    #endregion

                    Debug.WriteLine(control.GetType().Name);
                    if (control.GetType().Name == "TextBox")
                    {
                        value = ((TextBox)control).Text;
                        //if input datatype = 'datetime', replace 'T' with ' '
                        if(((ArrayList)tableColumnsSchema[i])[1].ToString() == "datetime")
                        {
                            value = value.Replace('T', ' ');
                        }
                    }
                    else if (control.GetType().Name == "CheckBox")
                    {
                        value = ((CheckBox)control).Checked ? "True" : "False";
                    }

                    isNumType = CheckIfSqlNumType( ((ArrayList)tableColumnsSchema[i])[1].ToString());
                    if (isNumType)
                    {
                        sql += value + ", ";
                    }
                    else
                    {
                        sql += "'" + value + "', ";
                    }
                }
                sql = sql.Substring(0, sql.Length - 2);
                sql += ")";


                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }  
        }
    }
}

