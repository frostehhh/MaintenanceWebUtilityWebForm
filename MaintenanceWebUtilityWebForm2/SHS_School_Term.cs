//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaintenanceWebUtilityWebForm2
{
    using System;
    using System.Collections.Generic;
    
    public partial class SHS_School_Term
    {
        public SHS_School_Term()
        {
            this.SHS_School_Period = new HashSet<SHS_School_Period>();
        }
    
        public int SHS_Term_Code { get; set; }
        public short School_Year { get; set; }
        public byte School_Term_Number { get; set; }
        public string Description { get; set; }
        public System.DateTime Date_Start { get; set; }
        public System.DateTime Date_End { get; set; }
        public bool Is_Active { get; set; }
        public Nullable<System.DateTime> Graduation_Date { get; set; }
        public Nullable<System.DateTime> Enrollment_Date_Start { get; set; }
        public Nullable<System.DateTime> Enrollment_Date_End { get; set; }
        public int College_Term_Code { get; set; }
        public System.DateTime Updated_Date { get; set; }
        public string Updated_By { get; set; }
        public string Updated_Host { get; set; }
        public string Updated_App { get; set; }
    
        public virtual ICollection<SHS_School_Period> SHS_School_Period { get; set; }
    }
}
