//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _99X_CBS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CBS_EmployeeBillingUtilization
    {
        public string Employee_Name { get; set; }
        public Nullable<System.DateTime> From_Date { get; set; }
        public Nullable<System.DateTime> To_Date { get; set; }
        public string Project { get; set; }
        public string Billing_Utilization { get; set; }
        public string EmpID { get; set; }
        public bool Approved { get; set; }
        public string EditedBy { get; set; }
        public int TargetRowID { get; set; }
        public int ID { get; set; }
    }
}