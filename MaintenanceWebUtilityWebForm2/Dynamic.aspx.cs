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
                    if(i < 10)
                    {
                        stringIdx = "0" + stringIdx;
                    }
                    tableLinkBtn.ID = "tableLinkBtn_" + stringIdx;
                    tableLinkBtn.Text = table;
                    tableLinkBtn.CommandName = table;
                    tableLinkBtn.Click += new EventHandler(tableLinkBtn_OnClick);
                    MaintenanceNavPlaceHolder.Controls.Add(tableLinkBtn);

                    literal = "</div></div></div></div>";
                    MaintenanceNavPlaceHolder.Controls.Add(new LiteralControl(literal));
                    i++;
                }
                //LinkButton maintenanceNavLinkBtn = new LinkButton();
                //maintenanceNavLinkBtn += new EventHandler(btnTest_Click);

                #region template for maintenance nav
                //if (empAccessiblesDict[1] == true)
                //{
                //    facilityLiteral = @" < div class=""col-xl-3 col-sm-6 mb-3"">
                //                                    <div class=""card text-white bg-primary o-hidden h-100"">
                //                                        <div class=""card-body"">
                //                                            <div class=""card-body-icon"">
                //                                                <i class=""fas fa-fw fa-comments""></i>
                //                                            </div>
                //                                            <div class=""mr -5"">IT</div>
                //                                        </div>
                //                                        <a class=""card-footer text-white clearfix small z-1"" href=""#"">
                //                                            <span class=""float-left"">View Details</span>
                //                                            <span class=""float-right"">
                //                                                <i class=""fas fa-angle-right""></i>
                //                                            </span>
                //                                        </a>
                //                                    </div>
                //                                </div>";
                //    empAccessibleLiteral.Text = String.Concat(empAccessibleLiteral.Text, facilityLiteral);
                //}
                //if (empAccessiblesDict[2] == true)
                //{
                //    facilityLiteral = @"<div class=""col-xl-3 col-sm-6 mb-3"">
                //                                    <div class=""card text-white bg-warning o-hidden h-100"">
                //                                        <div class=""card-body"">
                //                                            <div class=""card-body-icon"">
                //                                                <i class=""fas fa-fw fa-comments""></i>
                //                                            </div>
                //                                            <div class=""mr -5"">SHS</div>
                //                                        </div>
                //                                        <a class=""card-footer text-white clearfix small z-1"" runat=""server"" href=""./Facilities/Index.aspx?facilityId=2"">
                //                                            <span class=""float-left"">View Details</span>
                //                                            <span class=""float-right"">
                //                                                <i class=""fas fa-angle-right""></i>
                //                                            </span>
                //                                        </a>
                //                                    </div>
                //                                </div>";
                //    empAccessibleLiteral.Text = String.Concat(empAccessibleLiteral.Text, facilityLiteral);
                //}
                //if (empAccessiblesDict[3] == true)
                //{
                //    facilityLiteral = @"<div class=""col-xl-3 col-sm-6 mb-3"">
                //                                    <div class=""card text-white bg-success o-hidden h-100"">
                //                                        <div class=""card-body"">
                //                                            <div class=""card-body-icon"">
                //                                                <i class=""fas fa-fw fa-comments""></i>
                //                                            </div>
                //                                            <div class=""mr -5"">CS</div>
                //                                        </div>
                //                                        <a class=""card-footer text-white clearfix small z-1"" href =""#"">
                //                                            <span class=""float-left"">View Details</span>
                //                                            <span class=""float-right"">
                //                                                <i class=""fas fa-angle-right""></i>
                //                                            </span>
                //                                        </a>
                //                                    </div>
                //                                </div>";
                //    empAccessibleLiteral.Text = String.Concat(empAccessibleLiteral.Text, facilityLiteral);
                //}
                //if (empAccessiblesDict[4] == true)
                //{
                //    facilityLiteral = @"<div class=""col-xl-3 col-sm-6 mb-3"">
                //                                    <div class=""card text-white bg-danger o-hidden h-100"">
                //                                        <div class=""card-body"">
                //                                            <div class=""card-body-icon"">
                //                                                <i class=""fas fa-fw fa-comments""></i>
                //                                            </div>
                //                                            <div class=""mr -5"">PSY</div>
                //                                        </div>
                //                                        <a class=""card-footer text-white clearfix small z-1"" href =""#"">
                //                                            <span class=""float-left"">View Details</span>
                //                                            <span class=""float-right"">
                //                                                <i class=""fas fa-angle-right""></i>
                //                                            </span>
                //                                        </a>
                //                                    </div>
                //                                </div>";
                //    empAccessibleLiteral.Text = String.Concat(empAccessibleLiteral.Text, facilityLiteral);
                #endregion
            }
        }

        public void tableLinkBtn_OnClick(object sender, EventArgs e)
        {//https://docs.microsoft.com/en-us/dotnet/api/system.web.ui.webcontrols.button.commandname?view=netframework-4.8
        }
    }
}