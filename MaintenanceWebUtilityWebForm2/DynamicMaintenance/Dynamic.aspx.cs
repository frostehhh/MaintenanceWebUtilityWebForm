using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace MaintenanceWebUtilityWebForm2
{
    public partial class Dynamic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetPlaceHolderData();
        }

        private void GetPlaceHolderData()
        {
            string constr = ConfigurationManager.ConnectionStrings["MaintenanceWebUtilityDbEntitiesDataSource"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlDataReader queryResults;
                List<string> maintenanceTables = new List<string>();

                using (SqlCommand cmd = new SqlCommand("uspGetMaintenanceTables"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    queryResults = cmd.ExecuteReader();
                    if (queryResults.HasRows)
                    {
                        while (queryResults.Read())
                        {
                            maintenanceTables.Add(queryResults.GetString(0));
                        }
                    }
                }



                string literal, stringIdx;
                int i = 0;
                foreach (string table in maintenanceTables)
                {
                    literal = @"<div class=""col-xl-4 col-sm-6 mb-4"">
                                                        <div class=""card text-white bg-primary o-hidden h-100"">
                                                            <div class=""card-body"">
                                                                <div class=""mr-5"">IT</div>
                                                            </div>
                                                        </div>
                                                    </div>";
                    literal = @"<div class=""col-xl-4 col-sm-6 mb-4"">
                                                        <div class=""card text-white bg-primary o-hidden h-100"">
                                                            <div class=""card-body"">
                                                                <div class=""mr-5"">";
                    MaintenanceNavPlaceHolder.Controls.Add(new LiteralControl(literal));

                    LinkButton tableLinkBtn = new LinkButton();
                    stringIdx = i.ToString();
                    if (i < 10)
                    {
                        stringIdx = "0" + stringIdx;
                    }
                    tableLinkBtn.ID = "tableLinkBtn_" + stringIdx;
                    tableLinkBtn.Text = table;
                    tableLinkBtn.CssClass = "text-white";
                    tableLinkBtn.CommandName = table;
                    tableLinkBtn.Click += new EventHandler(tableLinkBtn_OnClick);
                    MaintenanceNavPlaceHolder.Controls.Add(tableLinkBtn);

                    literal = "</div></div></div></div>";
                    MaintenanceNavPlaceHolder.Controls.Add(new LiteralControl(literal));
                    i++;
                }
            }
        }

        public void tableLinkBtn_OnClick(object sender, EventArgs e)
        {//https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.button.commandname?view=netframework-4.8
            Session["MaintenanceTableName"] = ((LinkButton)sender).CommandName;
            Response.Redirect("ViewTable");
        }
    }
}