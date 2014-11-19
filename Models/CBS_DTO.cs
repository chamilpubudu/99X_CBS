using System.Collections.Generic;
namespace _99X_CBS.Models
{
    public class CBS_DTO
    {
        public CBS_Employees cbs_employee { get; set; }
        public List<CBS_Promotions> cbs_PromotionsList { get; set; }
        public List<CBS_Increments> cbs_IncrementsList { get; set; }
        public List<CBS_Bonuses> cbs_BonusesList { get; set; }
        public List<CBS_Awards> cbs_AwardsList { get; set; }
        public List<CBS_EmployeeBillingUtilization> cbs_EmployeeBillingUtilizationList { get; set; }
        public List<CBS_CustomerFeedbackScore> cbs_CustomerFeedbackScoreList { get; set; }
        public List<CBS_Trainings> cbs_TrainingsList { get; set; }
        public List<CBS_Travels> cbs_TravelsList { get; set; }
        
        public List<CBS_TechnologyExposure> cbs_TechnologyExposureList { get; set; }
        public List<CBS_MentorBuddy> cbs_MentorBuddyList { get; set; }
        public List<CBS_PublicAppearences> cbs_PublicAppearencesList { get; set; }
        public List<CBS_UniversitySessions> cbs_UniversitySessionsList { get; set; }
        public List<CBS_Engagement> cbs_EngagementList { get; set; }
        public List<CBS_ValueInnovations> cbs_ValueInnovationsList { get; set; }
        public List<CBS_Attendances> cbs_AttendancesList { get; set; }
        public List<CBS_FuelAllowances> cbs_FuelAllowancesList { get; set; }
        public List<CBS_ReportFormat> cbs_ReportFormatList { get; set; }
        public List<CBS_SalaryInformation> cbs_SalaryInformationList { get; set; }
        public List<CBS_AdditionalAccomplishments> cbs_AdditionalAccomplishmentsList { get; set; }
        public List<CBS_Benefits> cbs_BenefitsList { get; set; }

    }
}