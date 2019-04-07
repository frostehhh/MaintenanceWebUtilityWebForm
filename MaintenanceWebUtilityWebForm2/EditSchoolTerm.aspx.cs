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
    public partial class EditSchoolTerm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IQueryable<SHS_School_Term> GetSchoolTermDetails()
        {
            var schoolTermCode = Convert.ToInt32(Request.QueryString["SHSTermCode"]);
            var _db = new MaintenanceWebUtilityDbEntities();
            MaintenanceWebUtilityDbEntities _context = new MaintenanceWebUtilityDbEntities();

            var query = _context.SHS_School_Term
                            .Where(schoolTerm => schoolTerm.SHS_Term_Code == schoolTermCode);
            return query;
        }
        

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            updateSchoolTerm();
        }

        private void updateSchoolTerm()
        {
            //acquire userId from session
            var userIdNullable = Session[SessionKey.UserId];
            var userId = userIdNullable ?? default(int); // if not null

            var _context = new MaintenanceWebUtilityDbEntities();

            var fv = this.SHS_Term_Code_FormView;

            // get values from form
            int SHSTermCode = Convert.ToInt32(fv.DataKey[0]);
            TextBox schoolYearTextBox = (TextBox)fv.FindControl("School_Year");
            DropDownList schoolTermNumberDropDown = (DropDownList)fv.FindControl("School_Term_Number");
            TextBox descriptionTextBox = (TextBox)fv.FindControl("Description");
            TextBox dateStartTextBox = (TextBox)fv.FindControl("Date_Start");
            TextBox dateEndTextBox = (TextBox)fv.FindControl("Date_End");
            TextBox isActiveTextBox = (TextBox)fv.FindControl("Is_Active");
            TextBox graduationDateTextBox = (TextBox)fv.FindControl("Graduation_Date");
            TextBox enrollmentDateStartTextBox = (TextBox)fv.FindControl("Enrollment_Date_Start");
            TextBox enrollmentDateEndTextBox = (TextBox)fv.FindControl("Enrollment_Date_End");
            TextBox collegeTermCodeTextBox = (TextBox)fv.FindControl("College_Term_Code");
            TextBox updatedDateTextBox = (TextBox)fv.FindControl("Updated_Date");
            TextBox updatedByTextBox = (TextBox)fv.FindControl("Updated_By");
            TextBox updatedHostTextBox = (TextBox)fv.FindControl("Updated_Host");
            TextBox updatedAppTextBox = (TextBox)fv.FindControl("Updated_App");

            int schoolYear = Convert.ToInt32(schoolYearTextBox.Text);
            int schoolTermNumber = Convert.ToInt32(schoolTermNumberTextBox.Text);
            string description = descriptionTextBox.Text;
            DateTime dateStart = Convert.ToDateTime(dateStartTextBox.Text);
            DateTime dateEnd = Convert.ToDateTime(dateEndTextBox.Text);
            bool isActive = Convert.ToBoolean(isActiveTextBox.Text);
            DateTime graduationDate = DateTime.TryParse(graduationDateTextBox.Text, out graduationDate) ? Convert.ToDateTime(graduationDateTextBox.Text) : new DateTime(2000, 1, 1);
            DateTime enrollmentDateStart = DateTime.TryParse(enrollmentDateStartTextBox.Text, out enrollmentDateStart) ? Convert.ToDateTime(enrollmentDateStartTextBox.Text) : new DateTime(2000, 1, 1);
            DateTime enrollmentDateEnd = DateTime.TryParse(enrollmentDateEndTextBox.Text, out enrollmentDateEnd) ? Convert.ToDateTime(enrollmentDateEndTextBox.Text) : new DateTime(2000, 1, 1);
            int collegeTermCode = Convert.ToInt32(collegeTermCodeTextBox.Text);
            DateTime updatedDate = Convert.ToDateTime(updatedDateTextBox.Text);
            string updatedBy = updatedByTextBox.Text;
            string updatedHost = updatedHostTextBox.Text;
            string updatedApp = updatedAppTextBox.Text;

            string constr = ConfigurationManager.ConnectionStrings["MaintenanceWebUtilityDbEntitiesDataSource"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("uspEditSchoolTerm"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", userId);
                    cmd.Parameters.AddWithValue("@SHS_Term_Code", SHSTermCode);
                    cmd.Parameters.AddWithValue("@School_Year", schoolYear);
                    cmd.Parameters.AddWithValue("@School_Term_Number", schoolTermNumber);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Date_Start", dateStart);
                    cmd.Parameters.AddWithValue("@Date_End", dateEnd);
                    cmd.Parameters.AddWithValue("@Is_Active", isActive);
                    cmd.Parameters.AddWithValue("@Graduation_Date", graduationDate);
                    cmd.Parameters.AddWithValue("@Enrollment_Date_Start", enrollmentDateStart);
                    cmd.Parameters.AddWithValue("@Enrollment_Date_End", enrollmentDateEnd);
                    cmd.Parameters.AddWithValue("@College_Term_Code", collegeTermCode);
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