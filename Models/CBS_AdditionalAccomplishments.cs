using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _99X_CBS.Models
{


    public partial class CBS_AdditionalAccomplishments
    {
        public string Employee_Name { get; set; }
        public Nullable<System.DateTime> Accomplishment_Date { get; set; }
        public string AccomplishmentName { get; set; }
        public string EmpID { get; set; }
        public bool Approved { get; set; }
        public string EditedBy { get; set; }
        public Nullable<int> TargetRowID { get; set; }
        public int ID { get; set; }
    }
}
