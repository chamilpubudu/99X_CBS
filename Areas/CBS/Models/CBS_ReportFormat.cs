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
    
    public partial class CBS_ReportFormat
    {
        public int ID { get; set; }
        public string Section { get; set; }
        public bool Enabled { get; set; }
        public string SectionCode { get; set; }
        public Nullable<int> PriviledgeLevel { get; set; }
        public bool Approved { get; set; }
        public string EditedBy { get; set; }
        public Nullable<int> TargetRowID  { get; set; }
    }
}
