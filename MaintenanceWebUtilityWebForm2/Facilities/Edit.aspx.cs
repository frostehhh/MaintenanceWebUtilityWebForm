using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaintenanceWebUtilityWebForm2.Facilities
{
    public partial class Edit : System.Web.UI.Page
    {
        DateTime tempDateTime;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<FacilityPeriod> GetFacilityPeriodDetails()
        {
            var fpId = Convert.ToInt32(Request.QueryString["fpId"]);
            var _db = new MaintenanceWebUtilityDbEntities();
            MaintenanceWebUtilityDbEntities _context = new MaintenanceWebUtilityDbEntities();

            var query = _context.FacilityPeriods
                            .Where(fp => fp.Id == fpId);
            return query;

            /*
                string constr = ConfigurationManager.ConnectionStrings["MaintenanceWebUtilityDbEntitiesDataSource"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("uspGetActiveFacilityPeriod"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", facilityId);
                        cmd.Connection = con;
                        con.Open();

                        var facilityPeriod = cmd.ExecuteReader();

                        if (facilityPeriod.HasRows)
                        {
                            while(facilityPeriod.Read())
                            {
                                var periodId = facilityPeriod.GetInt32(0);
                                var encodingStartDate = facilityPeriod.GetDateTime(1);
                                var encodingEndDate = facilityPeriod.GetDateTime(2);
                            }
                        }
                        con.Close();

                        //output to literal
                    }
                }
                return null;
                */


        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {

            UpdateFacilityPeriod();
        }

        private void UpdateFacilityPeriod()
        {

            //acquire userId from session
            var userIdNullable = Session[SessionKey.UserId];
            var userId = userIdNullable ?? default(int); // if not null

            var _context = new MaintenanceWebUtilityDbEntities();

            // get values from form
            var row = FacilityPeriodDetailsGridView.Rows[0];
            TextBox encodingStartDateTextBox = (TextBox)row.FindControl("EncodingStartDate");
            TextBox encodingEndDateTextBox = (TextBox)row.FindControl("EncodingEndDate");
            HiddenField initialEncodingEndDateHiddenField = (HiddenField)row.FindControl("InitialEncodingEndDate");
            HiddenField changedEncodingEndDateHiddenField = (HiddenField)row.FindControl("ChangedEncodingDate");
            HiddenField isEncodingEndDateChangedHiddenField = (HiddenField)row.FindControl("IsEncodingEndDateChanged");

            int facilityPeriodId = Convert.ToInt32(FacilityPeriodDetailsGridView.DataKeys[0]["Id"].ToString());
            int facilityId = Convert.ToInt32(FacilityPeriodDetailsGridView.DataKeys[0]["FacilityId"].ToString());
            DateTime encodingStartDate = DateTime.TryParse(encodingStartDateTextBox.Text, out encodingStartDate) ? Convert.ToDateTime(encodingStartDateTextBox.Text) : default(DateTime);
            DateTime encodingEndDate = Convert.ToDateTime(encodingEndDateTextBox.Text);
            DateTime initialEncodingEndDate = Convert.ToDateTime(initialEncodingEndDateHiddenField.Value);
            DateTime changedEncodingEndDate = (DateTime.TryParse(changedEncodingEndDateHiddenField.Value, out changedEncodingEndDate)) ? changedEncodingEndDate : default(DateTime);
            bool isEncodingEndDateChanged = (isEncodingEndDateChangedHiddenField.Value == "true") ? true : false;


            if (isEncodingEndDateChanged == true)
            {
                var changeString = "";
                var dateTimedef = default(DateTime);
                if (initialEncodingEndDate.Equals(dateTimedef))
                {
                    changeString = "Updated encoding end date to " + changedEncodingEndDate;
                }
                else
                {
                    changeString = "Edited encoding end date from " + initialEncodingEndDate + " to " + changedEncodingEndDate;
                }

                string constr = ConfigurationManager.ConnectionStrings["MaintenanceWebUtilityDbEntitiesDataSource"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("uspEditFacilityPeriod"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", facilityPeriodId);

                        if(encodingStartDate == default(DateTime))
                        {
                            cmd.Parameters.AddWithValue("@EncodingStartDate", encodingStartDate).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@EncodingStartDate", encodingStartDate);
                        }
                        if (encodingEndDate == default(DateTime))
                        {
                            cmd.Parameters.AddWithValue("@EncodingEndDate", encodingEndDate).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@EncodingEndDate", encodingEndDate);
                        }

                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    using (SqlCommand cmd = new SqlCommand("uspInsertChangeLog"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeId", Session[SessionKey.UserId]);
                        cmd.Parameters.AddWithValue("@FacilityId", facilityId);
                        cmd.Parameters.AddWithValue("@ChangePerformed", changeString);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                //return to facilityperiods index
                Response.Redirect("~/Facilities/Index.aspx?facilityId=2");
            }
            //if nothing is changed, current view is returned
        }



        protected void EncodingEndDate_TextChanged(object sender, EventArgs e)
        {
            // get values from form
            var row = FacilityPeriodDetailsGridView.Rows[0];
            TextBox encodingEndDateTextBox = (TextBox)row.FindControl("EncodingEndDate");
            HiddenField initialEncodingEndDateHiddenField = (HiddenField)row.FindControl("InitialEncodingEndDate");

            DateTime encodingEndDate = DateTime.Parse(encodingEndDateTextBox.Text);
            String initialEncodingEndDate = initialEncodingEndDateHiddenField.Value;
            String changedEncodingEndDate = DateTime.Parse(encodingEndDateTextBox.Text).ToString("yyyy-MM-ddTHH:mm:ss");

            //update values in form
            ((HiddenField)row.FindControl("initialEncodingEndDate")).Value = initialEncodingEndDate;
            ((HiddenField)row.FindControl("ChangedEncodingDate")).Value = changedEncodingEndDate;
            ((HiddenField)row.FindControl("IsEncodingEndDateChanged")).Value = (changedEncodingEndDate.Equals(initialEncodingEndDate)) ? "false" : "true";

        }
        //return to current view
    }
}
