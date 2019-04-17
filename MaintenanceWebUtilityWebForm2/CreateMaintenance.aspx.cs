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

        }

        public void AddRowBtn_OnClick(object sender, EventArgs e)
        {
            InsertGridViewRow();
        }

        private void InsertGridViewRow()
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
            
        


        #region webcontrols
        //string literal;
        //TextBox tb = new TextBox();
        //DropDownList ddl = new DropDownList();
        //CheckBox cb = new CheckBox();
        //TableRow tRow = new TableRow();
        //TableCell tCell = new TableCell();
        //Table t = new Table();

        //List<string> SqlDataTypes = new List<string>()
        //{
        //    "bigint",
        //    "int",
        //    "varchar(50)"
        //};

        //tCell = new TableCell();
        //tRow.Cells.Add(tCell);

        //tCell = new TableCell();
        //tb.ID = "Name_Row_1";
        //tCell.Controls.Add(tb);
        //tRow.Cells.Add(tCell);

        //tCell = new TableCell();
        //ddl.ID = "DataType_Row_1";
        //ddl.Items.AddRange(new ListItem[]{
        //                    new ListItem(SqlDataTypes[0]),
        //                    new ListItem(SqlDataTypes[1])
        //                    });
        //tCell.Controls.Add(ddl);

        //tCell = new TableCell();
        //cb.ID = "AllowNulls_Row_1";
        //tCell.Controls.Add(cb);

        //tCell = new TableCell();
        //tb.ID = "Default_Row_1";
        //tCell.Controls.Add(tb);

        //t.Rows.Add(tRow);

        //PlaceHolder1.Controls.Add(t);
        #endregion
        #region placeholder method
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    GridView gv = CreateMaintenance_GridView;
        //    DataTable dt = new DataTable();
        //    DataRow NewRow = dt.NewRow();
        //    //NewRow[0] = new Textb;
        //    dt.Rows.Add(NewRow);
        //    gv.DataSource = dt;
        //    gv.DataBind();
        //}


        //public void CreateGridView(object sender, EventArgs e)
        //{
        //    GridView gv = (GridView)sender;
        //    Label label = new Label();
        //    TextBox textbox = new TextBox();
        //    DropDownList dataTypeDropDownList = new DropDownList();
        //    CheckBox allowsNullsChkBox = new CheckBox();
        //    ListItem[] dropdownList = new ListItem[20];


        //    PlaceHolder PK_Placeholder = (PlaceHolder)gv.Rows[0].FindControl("PK_Placeholder");
        //    PlaceHolder Name_Placeholder = (PlaceHolder)gv.FindControl("Name_Placeholder");
        //    PlaceHolder DataType_Placeholder = (PlaceHolder)gv.FindControl("DataType_Placeholder");
        //    PlaceHolder AllowNulls_Placeholder = (PlaceHolder)gv.FindControl("AllowNulls_Placeholder");
        //    PlaceHolder Default_Placeholder = (PlaceHolder)gv.FindControl("Default_Placeholder");

        //    label.Text = "PK";
        //    PK_Placeholder.Controls.Add(label);
        //    Name_Placeholder.Controls.Add(textbox);

        //    int i = 0;
        //    dropdownList[i++] = new ListItem("bigint");
        //    dropdownList[i++] = new ListItem("binary(50)");
        //    dropdownList[2] = new ListItem("bit");
        //    dropdownList[3] = new ListItem("char(10)");
        //    dropdownList[4] = new ListItem("date");
        //    dropdownList[5] = new ListItem("datetimeoffset(7)");
        //    dropdownList[6] = new ListItem("decimal(18,0)");
        //    dropdownList[7] = new ListItem("float");
        //    dropdownList[8] = new ListItem("image");
        //    dropdownList[i++] = new ListItem("int");
        //    dropdownList[0] = new ListItem("money");
        //    dropdownList[0] = new ListItem("nchar(10)");
        //    dataTypeDropDownList.Items.AddRange(dropdownList);
        //    DataType_Placeholder.Controls.Add(dataTypeDropDownList);

        //}

        //private void InsertGridViewRow()
        //{
        //    GridView gv = CreateMaintenance_GridView;
        //    DataTable dt = new DataTable();


        //    dt.Columns.Add(new DataColumn("PK"));
        //    dt.Columns.Add(new DataColumn("Name"));
        //    dt.Columns.Add(new DataColumn("Data Type"));
        //    dt.Columns.Add(new DataColumn("Allow Nulls"));
        //    dt.Columns.Add(new DataColumn("Default"));

        //    foreach (GridViewRow row in gv.Rows)
        //    {
        //        DataRow currentRows = dt.NewRow();
        //        for (int j = 0; j < gv.Columns.Count; j++)
        //        {
        //            currentRows[dt.Columns[j].ColumnName] = row.Cells[j].Text;
        //        }
        //        dt.Rows.Add(currentRows);
        //    }

        //    DataRow NewRow = dt.NewRow();
        //    dt.Rows.Add(NewRow);
        //    gv.DataSource = dt;
        //    gv.DataBind();
        //}

        //public void AddRowBtn_OnClick(object sender, EventArgs e)
        //{

        //    //InsertGridViewRow();
        //}
        #endregion
        #region datatables method
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //    //DataTable dt = new DataTable();

        //    //DataRow NewRow = dt.NewRow();
        //    ////NewRow[0] = new Textb;
        //    //dt.Rows.Add(NewRow);
        //    //CreateMaintenance_GridView.DataSource = dt;
        //    //CreateMaintenance_GridView.DataBind();
        //}

        //public void AddRowBtn_OnClick(object sender, EventArgs e)
        //{
        //    GridView gv = CreateMaintenance_GridView;
        //    DataTable dt = new DataTable();
        //    //for (int i = 0; i < gv.Columns.Count; i++)
        //    //{
        //    //    dt.Columns.Add("column" + i.ToString());
        //    //}
        //    dt.Columns.Add("PK");
        //    dt.Columns.Add("Name");
        //    dt.Columns.Add("Data Type");
        //    dt.Columns.Add("Allow Nulls");
        //    dt.Columns.Add("Default");
        //    dt.Columns[0].DataType = 

        //    foreach (GridViewRow row in gv.Rows)
        //    {
        //        DataRow currentRows = dt.NewRow();
        //        for (int j = 0; j < gv.Columns.Count; j++)
        //        {
        //            currentRows[dt.Columns[j].ColumnName] = row.Cells[j].Text;
        //        }
        //        dt.Rows.Add(currentRows);
        //    }

        //    DataRow NewRow = dt.NewRow();
        //    //NewRow[0] = new Textb;
        //    dt.Rows.Add(NewRow);
        //    gv.DataSource = dt;
        //    gv.DataBind();
        //}
        #endregion

    }
}