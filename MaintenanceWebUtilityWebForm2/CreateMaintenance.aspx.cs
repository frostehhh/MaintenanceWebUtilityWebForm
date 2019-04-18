using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MaintenanceWebUtilityWebForm2
{
    public partial class CreateMaintenance : System.Web.UI.Page
    {
        private int controlId = 0;
        private ArrayList controlIDArrayList = new ArrayList();

        protected void Page_Init(object sender, EventArgs e)
        {
            List<string> sqlDataTypes = GetSqlDataTypes();
            foreach(string str in sqlDataTypes)
            {
                DataType_Row_PK.Items.Add(new ListItem(str, str));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                RecreateTableRows();
            }

        }

        public void AddRowBtn_OnClick(object sender, EventArgs e)
        {
            InsertTableRow();
        }

        
        public void CreateBtn_OnClick(object sender, EventArgs e)
        {
           CreateSqlMaintenance();
        }

        private void CreateSqlMaintenance()
        {
            ArrayList existingControlIDArrayList = new ArrayList();
            bool controlsArrayExists = false;

            //run if there are dynamically added rows
            //if ViewState.Keys contains controlIDArrayList
            foreach (string str in ViewState.Keys)
            {
                if (str == "controlIDArrayList")
                {
                    controlsArrayExists = true;
                    break;
                }
            }

            //construct create string
            if (controlsArrayExists)
            {
                string sqlCreateQueryStart = "CREATE TABLE [dbo].[" + MaintenanceName.Text + "](";
                string sqlCreateQueryContent = "";
                string sqlCreateQueryEnd = ")";
                string sqlCreateQueryFinal = "";
                List<string> sqlCreateQueryEntryList = new List<string>();
                existingControlIDArrayList = ViewState["controlIDArrayList"] as ArrayList;
                string name = "", datatype = "", allowNull = "", defaultVal = "", columnEntry = "";

                //get pk row
                //read PK row,
                name = Name_Row_PK.Text;
                datatype = DataType_Row_PK.SelectedValue;
                allowNull = AllowNulls_Row_PK.Checked ? "NULL" : "NOT NULL";
                defaultVal = Default_Row_PK.Text;
                if (string.IsNullOrWhiteSpace(defaultVal))
                {
                    defaultVal = "";
                }
                else
                {
                    if (datatype.Contains("nonemuna"))
                    {

                    }
                    else
                    {
                        defaultVal = "DEFAULT " + defaultVal;
                    }
                }
                columnEntry = name + " " + datatype + " " + allowNull + " PRIMARY KEY " + defaultVal;
                sqlCreateQueryEntryList.Add(columnEntry);

                //get dynamically created rows
                //construct each columnEntryString
                int i = 0;
                foreach (string str in existingControlIDArrayList)
                {
                    if (str.StartsWith("Name_Row_"))
                    {
                        name = ((TextBox)PlaceHolder1.FindControl(str)).Text;
                    }
                    else if (str.StartsWith("DataType_Row_"))
                    {
                        datatype = ((DropDownList)PlaceHolder1.FindControl(str)).SelectedValue;
                    }
                    else if (str.StartsWith("AllowNulls_Row_"))
                    {
                        allowNull = ((CheckBox)PlaceHolder1.FindControl(str)).Checked ? "NULL" : "NOT NULL";
                    }
                    else if (str.StartsWith("Default_Row_"))
                    {
                        defaultVal = ((TextBox)PlaceHolder1.FindControl(str)).Text;
                        if (string.IsNullOrWhiteSpace(defaultVal))
                        {
                            defaultVal = "";
                        }
                        else
                        {
                            if (datatype.Contains("nonemuna"))
                            {

                            }
                            else
                            {
                                defaultVal = "DEFAULT " + defaultVal;
                            }
                        }
                        //if not empty, add default
                    }
                    i++;
                    if(i%3 == 0)
                    {
                        columnEntry = name + " " + datatype + " " + allowNull + " " + defaultVal;
                        sqlCreateQueryEntryList.Add(columnEntry);
                        i = 0;
                    }
                    
                }

                //append to sqlCreateQueryContent
                foreach (string str in sqlCreateQueryEntryList)
                {
                    sqlCreateQueryContent = string.Concat(sqlCreateQueryContent, str, ", ");
                }
                //remove comma at end
                sqlCreateQueryContent = sqlCreateQueryContent.Substring(0, sqlCreateQueryContent.Length - 2);
                sqlCreateQueryFinal = sqlCreateQueryStart + sqlCreateQueryContent + sqlCreateQueryEnd;

                //send createquery to sql server
                string constr = ConfigurationManager.ConnectionStrings["MaintenanceWebUtilityDbEntitiesDataSource"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    
                    using (SqlCommand cmd = new SqlCommand(sqlCreateQueryFinal))
                    {
                        cmd.Connection = con;
                        con.Open();
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("e: " + e);
                        }
                        
                    }
                    
                    
                }
            }
        }
                    
        private void RecreateTableRows()
        {
            string literal;
            TextBox tb;
            DropDownList ddl;
            CheckBox cb;
            ArrayList existingControlIDArrayList = new ArrayList();
            bool controlsArrayExists = false;
            List<string> SqlDataTypes = GetSqlDataTypes();
            string controlIdStr = "";

            //run if there are dynamically added rows
            //if ViewState.Keys contains controlIDArrayList
            foreach (string str in ViewState.Keys)
            {
                if (str == "controlIDArrayList")
                {
                    controlsArrayExists = true;
                    break;
                }
            }

            if (controlsArrayExists)
            {
                existingControlIDArrayList = ViewState["controlIDArrayList"] as ArrayList;
                //read arraylist
                //dynamically recreate rows
                foreach (string str in existingControlIDArrayList)
                {
                    if (str.StartsWith("Name_Row_"))
                    {
                        controlId = Convert.ToInt16(str.Substring(str.Length - 2));
                        if (controlId <= 9)
                        {
                            controlIdStr = "0" + controlId;
                        }
                        else
                        {
                            controlIdStr = controlId.ToString();
                        }
                        literal = "<tr><td></td><td>";
                        PlaceHolder1.Controls.Add(new LiteralControl(literal));

                        tb = new TextBox() { ID = "Name_Row_" + controlIdStr };
                        tb.CssClass = "form-control";
                        PlaceHolder1.Controls.Add(tb);
                        controlIDArrayList.Add(tb.ID.ToString());

                        literal = "</td><td>";
                        PlaceHolder1.Controls.Add(new LiteralControl(literal));
                    }
                    else if (str.StartsWith("DataType_Row_"))
                    {
                        controlId = Convert.ToInt16(str.Substring(str.Length - 2));
                        if (controlId <= 9)
                        {
                            controlIdStr = "0" + controlId;
                        }
                        else
                        {
                            controlIdStr = controlId.ToString();
                        }

                        ddl = new DropDownList();
                        ddl = AddSqlDataTypesToDropDownList(ddl);
                        ddl.ID = "DataType_Row_" + controlIdStr;
                        PlaceHolder1.Controls.Add(ddl);
                        controlIDArrayList.Add(ddl.ID.ToString());

                        literal = "</td><td>";
                        PlaceHolder1.Controls.Add(new LiteralControl(literal));
                    }
                    else if (str.StartsWith("AllowNulls_Row_"))
                    {
                        controlId = Convert.ToInt16(str.Substring(str.Length - 2));
                        if (controlId <= 9)
                        {
                            controlIdStr = "0" + controlId;
                        }
                        else
                        {
                            controlIdStr = controlId.ToString();
                        }
                        cb = new CheckBox() { ID = "AllowNulls_Row_" + controlIdStr };
                        PlaceHolder1.Controls.Add(cb);
                        controlIDArrayList.Add(cb.ID.ToString());

                        literal = "</td><td>";
                        PlaceHolder1.Controls.Add(new LiteralControl(literal));
                    }
                    else if (str.StartsWith("Default_Row_"))
                    {
                        controlId = Convert.ToInt16(str.Substring(str.Length - 2));
                        if (controlId <= 9)
                        {
                            controlIdStr = "0" + controlId;
                        }
                        else
                        {
                            controlIdStr = controlId.ToString();
                        }
                        tb = new TextBox() { ID = "Default_Row_" + controlIdStr };
                        tb.CssClass = "form-control";
                        PlaceHolder1.Controls.Add(tb);
                        controlIDArrayList.Add(tb.ID.ToString());

                        literal = "</td></tr>";
                        PlaceHolder1.Controls.Add(new LiteralControl(literal));
                    }
                }
            }
        }
        private List<string> GetSqlDataTypes()
        {
            return new List<string>()
            {
                "bigint",
                "int",
                "varchar(50)",
                "bit"
            };
        }
        public DropDownList AddSqlDataTypesToDropDownList(DropDownList ddl)
        {
            List<string> sqlDataTypes = GetSqlDataTypes();
            foreach(string str in sqlDataTypes)
            {
                ddl.Items.Add(new ListItem(str, str));
            }

            return ddl;
        }
        private void InsertTableRow()
        {

            string literal;
            TextBox tb;
            DropDownList ddl;
            CheckBox cb;
            ArrayList existingControlIDArrayList = new ArrayList();
            string controlIdStr;

            
            //run if no rows have been dynamically added
            //get last control id +1
            controlId++;
            if(controlId <= 9)
            {
                controlIdStr = "0" + controlId;
            }
            else
            {
                controlIdStr = controlId.ToString();
            }
            literal = "<tr><td></td><td>";
            PlaceHolder1.Controls.Add(new LiteralControl(literal));

            tb = new TextBox() { ID = "Name_Row_" + controlIdStr };
            tb.CssClass = "form-control";
            PlaceHolder1.Controls.Add(tb);
            controlIDArrayList.Add(tb.ID.ToString());

            literal = "</td><td>";
            PlaceHolder1.Controls.Add(new LiteralControl(literal));

            ddl = new DropDownList();
            ddl = AddSqlDataTypesToDropDownList(ddl);
            ddl.ID = "DataType_Row_" + controlIdStr;
            PlaceHolder1.Controls.Add(ddl);
            controlIDArrayList.Add(ddl.ID.ToString());

            literal = "</td><td>";
            PlaceHolder1.Controls.Add(new LiteralControl(literal));

            cb = new CheckBox() { ID = "AllowNulls_Row_" + controlIdStr };
            PlaceHolder1.Controls.Add(cb);
            controlIDArrayList.Add(cb.ID.ToString());

            literal = "</td><td>";
            PlaceHolder1.Controls.Add(new LiteralControl(literal));

            tb = new TextBox() { ID = "Default_Row_" + controlIdStr };
            tb.CssClass = "form-control";
            PlaceHolder1.Controls.Add(tb);
            controlIDArrayList.Add(tb.ID.ToString());

            literal = "</td></tr>";
            PlaceHolder1.Controls.Add(new LiteralControl(literal));

            ViewState["controlIDArrayList"] = controlIDArrayList;
        }




    }
}
 