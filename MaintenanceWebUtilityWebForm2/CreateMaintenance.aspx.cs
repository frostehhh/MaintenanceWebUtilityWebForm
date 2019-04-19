﻿using System;
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

        public void DataType_Row_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            string ID = ddl.ID.Substring(ddl.ID.Length - 2);
            TextBox tb = (TextBox)PlaceHolder1.FindControl("DataTypeNum_Row_" + ID);

            //values wherein () is required 
            if (ddl.SelectedValue.Contains("binary") || //50, 10, 7, 7, (18,0), 10, (18,0), 50, 7, 50 ,50
                ddl.SelectedValue.Contains("char") ||
                ddl.SelectedValue.Contains("datetime2") ||
                ddl.SelectedValue.Contains("datetimeoffset") ||
                ddl.SelectedValue.Contains("char") ||
                ddl.SelectedValue.Contains("decimal") ||
                ddl.SelectedValue.Contains("numeric") ||
                ddl.SelectedValue.Contains("varbinary") ||
                ddl.SelectedValue.Contains("time") &&
                ddl.SelectedValue != "datetime"
                )
            {
                tb.Enabled=true;
                if (ddl.SelectedValue.Contains("binary")) { tb.Attributes.Add("placeholder", "(50)"); }
                else if (ddl.SelectedValue.Contains("char")) { tb.Attributes.Add("placeholder", "(10)"); }
                else if (ddl.SelectedValue.Contains("datetime2")) { tb.Attributes.Add("placeholder", "(7)"); }
                else if (ddl.SelectedValue.Contains("datetimeoffset")) { tb.Attributes.Add("placeholder", "(7)"); }
                else if (ddl.SelectedValue.Contains("decimal")) { tb.Attributes.Add("placeholder", "(18, 0)"); }
                else if (ddl.SelectedValue.Contains("numeric")) { tb.Attributes.Add("placeholder", "(18,0)"); }
                else if (ddl.SelectedValue.Contains("time")) { tb.Attributes.Add("placeholder", "(7)"); }
                else if (ddl.SelectedValue.Contains("varbinary")) { tb.Attributes.Add("placeholder", "(50)"); }
                //set default () for each datatype
            }
            else
            {
                tb.Enabled = false;
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
                    defaultVal = "DEFAULT " + defaultVal;
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
                            columnEntry = name + " " + datatype + " " + allowNull + " " + defaultVal;
                            sqlCreateQueryEntryList.Add(columnEntry);
                        }
                        else
                        {
                            defaultVal = "DEFAULT " + defaultVal;
                            columnEntry = name + " " + datatype + " " + allowNull + " " + defaultVal;
                            sqlCreateQueryEntryList.Add(columnEntry);
                        }
                        //if not empty, add default
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
                "binary(50)",
                "bit",
                "char(10)",
                "date",
                "datetime",
                "datetime2(7)",
                "datetimeoffset(7)",
                "decimal(18,0)",
                "float",
                "image",
                "int",
                "money",
                "nchar(10)",
                "ntext",
                "numeric(18,0)",
                "nvarchar(50)",
                "nvarchar(MAX)",
                "real",
                "rowversion",
                "smalldatetime",
                "smallint",
                "smallmoney",
                "sql_variant",
                "text",
                "time(7)",
                "timestamp",
                "tinyint",
                "uniqueidentifier",
                "varbinary(50)",
                "varbinary(MAX)",
                "varchar(50)",
                "xml"
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
 