using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _99X_CBS.Models
{
    public partial class CBS_SalaryInformation
    {
        public string Employee_Name { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public int CurrentSalaryAmount { get; set; }
        public int EPF { get; set; }
        public int ETF { get; set; }
        public string EmpID { get; set; }
        public int ID { get; set; }
        public bool Approved { get; set; }
        public string EditedBy { get; set; }
        public Nullable<int> TargetRowID { get; set; }
    }
}
