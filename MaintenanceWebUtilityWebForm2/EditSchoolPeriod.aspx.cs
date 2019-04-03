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
            TextBox SHSTermCodeTextBox = (TextBox)fv.FindControl("SHS_Term_Code");
            TextBox periodNumberTextBox = (TextBox)fv.FindControl("Period_Number");
            TextBox periodDescriptionTextBox = (TextBox)fv.FindControl("Period_Description");
            TextBox schoolDaysTextBox = (TextBox)fv.FindControl("School_Days");
            TextBox isActiveTextBox = (TextBox)fv.FindControl("Is_Active");
            TextBox encodingStartTextBox = (TextBox)fv.FindControl("Encoding_Start");
            TextBox encodingEndTextBox = (TextBox)fv.FindControl("Encoding_End");
            TextBox updatedDateTextBox = (TextBox)fv.FindControl("Updated_Date");
            TextBox updatedByTextBox = (TextBox)fv.FindControl("Updated_By");
            TextBox updatedHostTextBox = (TextBox)fv.FindControl("Updated_Host");
            TextBox updatedAppTextBox = (TextBox)fv.FindControl("Updated_App");

            int SHSTermCode = Convert.ToInt32(SHSTermCodeTextBox.Text);
            int periodNumber = Convert.ToInt32(periodNumberTextBox.Text);
            string periodDescription = periodDescriptionTextBox.Text;
            float schoolDays = float.Parse(schoolDaysTextBox.Text);
            bool isActive = Convert.ToBoolean(isActiveTextBox.Text);
            DateTime encodingStart = Convert.ToDateTime(encodingStartTextBox.Text);
            DateTime encodingEnd = Convert.ToDateTime(encodingEndTextBox.Text);
            DateTime updatedDate = Convert.ToDateTime(updatedDateTextBox.Text);
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
                    cmd.Parameters.AddWithValue("@Updated_Date", updatedDate);
                    cmd.Parameters.AddWithValue("@Updated_By", updatedBy);
                    cmd.Parameters.AddWithValue("@Updated_Host", updatedHost);
                    cmd.Parameters.AddWithValue("@Updated_App", updatedApp);

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