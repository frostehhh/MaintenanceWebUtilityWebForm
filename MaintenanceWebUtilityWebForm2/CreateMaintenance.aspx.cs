using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

        private void RecreateTableRows()
        {
            string literal;
            TextBox tb;
            DropDownList ddl;
            CheckBox cb;
            ArrayList existingControlIDArrayList = new ArrayList();
            bool controlsArrayExists = false;

            List<string> SqlDataTypes = new List<string>()
                {
                "bigint",
                "int",
                "varchar(50)"
                };

            /* get number of rows from table
             * get current number of controls on page
             * redisplay 
             */
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
                        controlId = Convert.ToInt16(str.Substring(str.Length - 1));
                        literal = "<tr><td></td><td>";
                        PlaceHolder1.Controls.Add(new LiteralControl(literal));

                        tb = new TextBox() { ID = "Name_Row_" + controlId };
                        PlaceHolder1.Controls.Add(tb);
                        controlIDArrayList.Add(tb.ID.ToString());

                        literal = "</td><td>";
                        PlaceHolder1.Controls.Add(new LiteralControl(literal));
                    }
                    else if (str.StartsWith("DataType_Row_"))
                    {
                        controlId = Convert.ToInt16(str.Substring(str.Length - 1));

                        ddl = new DropDownList() { ID = "DataType_Row_" + controlId };
                        ddl.Items.Add(new ListItem(SqlDataTypes[0], SqlDataTypes[0]));
                        ddl.Items.Add(new ListItem(SqlDataTypes[1], SqlDataTypes[1]));
                        PlaceHolder1.Controls.Add(ddl);
                        controlIDArrayList.Add(ddl.ID.ToString());

                        literal = "</td><td>";
                        PlaceHolder1.Controls.Add(new LiteralControl(literal));
                    }
                    else if (str.StartsWith("AllowNulls_Row_"))
                    {
                        controlId = Convert.ToInt16(str.Substring(str.Length - 1));

                        cb = new CheckBox() { ID = "AllowNulls_Row_" + controlId };
                        PlaceHolder1.Controls.Add(cb);
                        controlIDArrayList.Add(cb.ID.ToString());

                        literal = "</td><td>";
                        PlaceHolder1.Controls.Add(new LiteralControl(literal));
                    }
                    else if (str.StartsWith("Default_Row_"))
                    {
                        controlId = Convert.ToInt16(str.Substring(str.Length - 1));

                        tb = new TextBox() { ID = "Default_Row_" + controlId };
                        PlaceHolder1.Controls.Add(tb);
                        controlIDArrayList.Add(tb.ID.ToString());

                        literal = "</td></tr>";
                        PlaceHolder1.Controls.Add(new LiteralControl(literal));
                    }
                }
            }
        }
           

        private void InsertTableRow()
        {

            #region temp
            string literal;
            TextBox tb;
            DropDownList ddl;
            CheckBox cb;
            PlaceHolder ph;
            ArrayList existingControlIDArrayList = new ArrayList();

            List<string> SqlDataTypes = new List<string>()
            {
                "bigint",
                "int",
                "varchar(50)"
            };

            
            //run if no rows have been dynamically added
            //get last control id +1
            controlId++;
            literal = "<tr><td></td><td>";
            PlaceHolder1.Controls.Add(new LiteralControl(literal));

            tb = new TextBox() { ID = "Name_Row_" + controlId };
            PlaceHolder1.Controls.Add(tb);
            controlIDArrayList.Add(tb.ID.ToString());

            literal = "</td><td>";
            PlaceHolder1.Controls.Add(new LiteralControl(literal));

            ddl = new DropDownList() { ID = "DataType_Row_" + controlId };
            ddl.Items.Add(new ListItem(SqlDataTypes[0], SqlDataTypes[0]));
            ddl.Items.Add(new ListItem(SqlDataTypes[1], SqlDataTypes[1]));
            PlaceHolder1.Controls.Add(ddl);
            controlIDArrayList.Add(ddl.ID.ToString());

            literal = "</td><td>";
            PlaceHolder1.Controls.Add(new LiteralControl(literal));

            cb = new CheckBox() { ID = "AllowNulls_Row_" + controlId };
            PlaceHolder1.Controls.Add(cb);
            controlIDArrayList.Add(cb.ID.ToString());

            literal = "</td><td>";
            PlaceHolder1.Controls.Add(new LiteralControl(literal));

            tb = new TextBox() { ID = "Default_Row_" + controlId };
            PlaceHolder1.Controls.Add(tb);
            controlIDArrayList.Add(tb.ID.ToString());

            literal = "</td></tr>";
            PlaceHolder1.Controls.Add(new LiteralControl(literal));

            ViewState["controlIDArrayList"] = controlIDArrayList;
        }
            
            
            #endregion



    }
}