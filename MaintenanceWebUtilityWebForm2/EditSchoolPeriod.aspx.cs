using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaintenanceWebUtilityWebForm2
{
    public partial class EditSchoolPeriod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<SHS_School_Period> GetSchoolPeriodDetails()
        {
            var schoolPeriodId = Convert.ToInt32(Request.QueryString["PeriodId"]);
            var _db = new MaintenanceWebUtilityDbEntities();
            MaintenanceWebUtilityDbEntities _context = new MaintenanceWebUtilityDbEntities();

            var query = _context.SHS_School_Period
                            .Where(schoolPeriod => schoolPeriod.Period_ID == schoolPeriodId);
            return query;
        }

        public void FormView_OnDataBound(object sender, EventArgs e)
        {
            //acquire userId from session
            var userIdNullable = Session[SessionKey.UserId];
            var userId = userIdNullable ?? default(int); // if not null

            string constr = ConfigurationManager.ConnectionStrings["MaintenanceWebUtilityDbEntitiesDataSource"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("uspGetEmployeeTypeId"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", userId);
                    cmd.Connection = con;
                    con.Open();
                    var userEmployeeType = cmd.ExecuteScalar();
                    con.Close();

                    // hide unnecessary fields
                    // if user is admin
                    if (!(userEmployeeType.ToString().Equals("1")))
                    {

                        FormView fv = (FormView)sender;
                        fv.FindControl("Period_ID").Visible = false;
                        fv.FindControl("SHS_Term_Code").Visible = false;
                        fv.FindControl("Updated_Date").Visible = false;
                        fv.FindControl("Updated_By").Visible = false;
                        fv.FindControl("Updated_Host").Visible = false;
                        fv.FindControl("Updated_App").Visible = false;

                        fv.FindControl("Period_ID_Lbl").Visible = false;
                        fv.FindControl("SHS_Term_Code_Lbl").Visible = false;
                        fv.FindControl("Updated_Date_Lbl").Visible = false;
                        fv.FindControl("Updated_By_Lbl").Visible = false;
                        fv.FindControl("Updated_Host_Lbl").Visible = false;
                        fv.FindControl("Updated_App_Lbl").Visible = false;
                    }

                }
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            updateSchoolPeriod();
        }

        private void updateSchoolPeriod()
        {
            //acquire userId from session
            var userIdNullable = Session[SessionKey.UserId];
            var userId = userIdNullable ?? default(int); // if not null

            var _context = new MaintenanceWebUtilityDbEntities();

            var fv = this.SHS_School_Period_FormView;

            //get values from form
            int periodId = Convert.ToInt32(fv.DataKey[0]);
            int SHSTermCode = Convert.ToInt32(fv.DataKey[1]);
            TextBox periodNumberTextBox = (TextBox)fv.FindControl("Period_Number");
            TextBox periodDescriptionTextBox = (TextBox)fv.FindControl("Period_Description");
            TextBox schoolDaysTextBox = (TextBox)fv.FindControl("School_Days");
            RadioButtonList isActiveRbList = (RadioButtonList)fv.FindControl("Is_ActiveRadioBtn");
            TextBox encodingStartTextBox = (TextBox)fv.FindControl("Encoding_Start");
            TextBox encodingEndTextBox = (TextBox)fv.FindControl("Encoding_End");
            TextBox updatedDateTextBox = (TextBox)fv.FindControl("Updated_Date");
            TextBox updatedByTextBox = (TextBox)fv.FindControl("Updated_By");
            TextBox updatedHostTextBox = (TextBox)fv.FindControl("Updated_Host");
            TextBox updatedAppTextBox = (TextBox)fv.FindControl("Updated_App");

            int periodNumber = Convert.ToInt32(periodNumberTextBox.Text);
            string periodDescription = periodDescriptionTextBox.Text;
            float schoolDays = float.Parse(schoolDaysTextBox.Text);
            bool isActive = Convert.ToBoolean(isActiveRbList.SelectedValue);
            DateTime encodingStart = Convert.ToDateTime(encodingStartTextBox.Text);
            DateTime encodingEnd = Convert.ToDateTime(encodingEndTextBox.Text);
            DateTime updatedDate;
            if (updatedAppTextBox.Visible == true)
            {
                updatedDate = Convert.ToDateTime(updatedDateTextBox.Text);
            }
            else
            {
                updatedDate = default(DateTime);
            }
            string updatedBy = updatedByTextBox.Text;
            string updatedHost = updatedHostTextBox.Text;
            string updatedApp = updatedAppTextBox.Text;

            string constr = ConfigurationManager.ConnectionStrings["MaintenanceWebUtilityDbEntitiesDataSource"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("uspEditSchoolPeriod"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", userId);
                    cmd.Parameters.AddWithValue("@Period_ID", periodId);
                    cmd.Parameters.AddWithValue("@SHS_Term_Code", SHSTermCode);
                    cmd.Parameters.AddWithValue("@Period_Number", periodNumber);
                    cmd.Parameters.AddWithValue("@Period_Description", periodDescription);
                    cmd.Parameters.AddWithValue("@School_Days", schoolDays);
                    cmd.Parameters.AddWithValue("@Is_Active", isActive);
                    cmd.Parameters.AddWithValue("@Encoding_Start", encodingStart);
                    cmd.Parameters.AddWithValue("@Encoding_End", encodingEnd);
                    if (updatedDate == default(DateTime))
                    {
                        cmd.Parameters.AddWithValue("@Updated_Date", updatedDate).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Updated_Date", updatedDate);
                    }
                    if (updatedBy.Equals(""))
                    {
                        cmd.Parameters.AddWithValue("Updated_By", updatedBy).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Updated_By", updatedBy);
                    }
                    if (updatedHost.Equals(""))
                    {
                        cmd.Parameters.AddWithValue("Updated_Host", updatedHost).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Updated_Host", updatedHost);
                    }
                    if (updatedApp.Equals(""))
                    {
                        cmd.Parameters.AddWithValue("Updated_App", updatedApp).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("Updated_App", updatedApp);
                    }

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
            //return to default
            Response.Redirect("~/default.aspx");
        }
    }
}