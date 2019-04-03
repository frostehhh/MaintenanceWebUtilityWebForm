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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            var facilityId = Convert.ToInt32(Request.QueryString["facilityId"]);

            string constr = ConfigurationManager.ConnectionStrings["MaintenanceWebUtilityDbEntitiesDataSource"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                //EDIT THIS AREA
                using (SqlCommand cmd = new SqlCommand(""))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", facilityId);
                    cmd.Connection = con;
                    con.Open();

                    var facilityPeriod = cmd.ExecuteReader();

                    if (facilityPeriod.HasRows)
                    {
                        while (facilityPeriod.Read())
                        {
                            var periodId = facilityPeriod.GetInt32(0);
                            var encodingStartDate = facilityPeriod.GetDateTime(1);
                            var encodingEndDate = facilityPeriod.GetDateTime(2);
                        }
                    }
                    con.Close();

                    //output to literal
                    /*
                     * retrieve 
                     
                    string indexLiteralTemp = "";
                    indexLiteral.Text = String.Concat(indexLiteral.Text, indexLiteralTemp);
                    
                }
            }*/
        }

        public IQueryable<FacilityPeriod> GetFacilityPeriods()
        {
            var facilityId = Convert.ToInt32(Request.QueryString["facilityId"]);
            
            var _db = new MaintenanceWebUtilityDbEntities();
            MaintenanceWebUtilityDbEntities _context = new MaintenanceWebUtilityDbEntities();

            var query = _context.FacilityPeriods
                            .Where(f => f.FacilityId == facilityId && f.SchoolPeriod.IsPeriodActive == true);
            return query;

        }
    }
}