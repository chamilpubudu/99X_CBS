using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _99X_CBS.Models
{
    public class Entities : DbContext
    {
        public DbSet<CBS_Attendances> CBS_Attendances { get; set; }
        public DbSet<CBS_Awards> CBS_Awards { get; set; }
        public DbSet<CBS_Bonuses> CBS_Bonuses { get; set; }
        public DbSet<CBS_CustomerFeedbackScore> CBS_CustomerFeedbackScore { get; set; }
        public DbSet<CBS_EmployeeBillingUtilization> CBS_EmployeeBillingUtilization { get; set; }

        public DbSet<CBS_Employees> CBS_Employees { get; set; }
        public DbSet<CBS_Engagement> CBS_Engagement { get; set; }
        public DbSet<CBS_FuelAllowances> CBS_FuelAllowances { get; set; }
        public DbSet<CBS_Increments> CBS_Increments { get; set; }
        public DbSet<CBS_MentorBuddy> CBS_MentorBuddy { get; set; }

        public DbSet<CBS_Promotions> CBS_Promotions { get; set; }
        public DbSet<CBS_PublicAppearences> CBS_PublicAppearences { get; set; }
        public DbSet<CBS_ReportFormat> CBS_ReportFormat { get; set; }
        public DbSet<CBS_TechnologyExposure> CBS_TechnologyExposure { get; set; }
        public DbSet<CBS_Trainings> CBS_Trainings { get; set; }

        public DbSet<CBS_Travels> CBS_Travels { get; set; }
        public DbSet<CBS_UniversitySessions> CBS_UniversitySessions { get; set; }
        public DbSet<CBS_ValueInnovations> CBS_ValueInnovations { get; set; }
        public DbSet<CBS_SystemSettings> CBS_SystemSettings { get; set; }
        public DbSet<CBS_NotificationInfo> CBS_NotificationInfo { get; set; }
        public DbSet<CBS_SalaryInformation> CBS_SalaryInformation { get; set; }
    }
}