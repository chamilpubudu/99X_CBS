﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CBS_Employees> CBS_Employees { get; set; }
        public virtual DbSet<CBS_Attendances> CBS_Attendances { get; set; }
        public virtual DbSet<CBS_Awards> CBS_Awards { get; set; }
        public virtual DbSet<CBS_Bonuses> CBS_Bonuses { get; set; }
        public virtual DbSet<CBS_CustomerFeedbackScore> CBS_CustomerFeedbackScore { get; set; }
        public virtual DbSet<CBS_EmployeeBillingUtilization> CBS_EmployeeBillingUtilization { get; set; }
        public virtual DbSet<CBS_Engagement> CBS_Engagement { get; set; }
        public virtual DbSet<CBS_FuelAllowances> CBS_FuelAllowances { get; set; }
        public virtual DbSet<CBS_Increments> CBS_Increments { get; set; }
        public virtual DbSet<CBS_MentorBuddy> CBS_MentorBuddy { get; set; }
        public virtual DbSet<CBS_Promotions> CBS_Promotions { get; set; }
        public virtual DbSet<CBS_PublicAppearences> CBS_PublicAppearences { get; set; }
        public virtual DbSet<CBS_TechnologyExposure> CBS_TechnologyExposure { get; set; }
        public virtual DbSet<CBS_Trainings> CBS_Trainings { get; set; }
        public virtual DbSet<CBS_Travels> CBS_Travels { get; set; }
        public virtual DbSet<CBS_UniversitySessions> CBS_UniversitySessions { get; set; }
        public virtual DbSet<CBS_ValueInnovations> CBS_ValueInnovations { get; set; }
    }
}
