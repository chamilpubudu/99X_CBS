using System.Data;
using System.Data.Entity;
using _99X_CBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _99X_CBS.Areas.Admin.Controllers
{
    [Authorize]
    public class DataApproveController : Controller
    {
        private Entities db = new Entities();
        //
        // GET: /Admin/DataApprove/
        public ActionResult Index()
        {
            return View();
        }


        // GET :/Admin/DataApprove/GetInitialData/
        public ActionResult GetInitialData()
        {
            List<CBS_Promotions> cbs_PromotionsList = db.CBS_Promotions.Where(x => x.Approved == false ).ToList();
            List<CBS_Increments> cbs_IncrementsList = db.CBS_Increments.Where(x => x.Approved == false ).ToList();
            List<CBS_Bonuses> cbs_BonusesList = db.CBS_Bonuses.Where(x => x.Approved == false ).ToList();
            List<CBS_Awards> cbs_AwardsList = db.CBS_Awards.Where(x => x.Approved == false ).ToList();
            List<CBS_EmployeeBillingUtilization> cbs_EmployeeBillingUtilizationList = db.CBS_EmployeeBillingUtilization.Where(x => x.Approved == false ).ToList();

            List<CBS_CustomerFeedbackScore> cbs_CustomerFeedbackScoreList = db.CBS_CustomerFeedbackScore.Where(x => x.Approved == false ).ToList();
            List<CBS_Trainings> cbs_TrainingsList = db.CBS_Trainings.Where(x => x.Approved == false ).ToList();
            List<CBS_Travels> cbs_TravelsList = db.CBS_Travels.Where(x => x.Approved == false ).ToList();
            List<CBS_TechnologyExposure> cbs_TechnologyExposureList = db.CBS_TechnologyExposure.Where(x => x.Approved == false ).ToList();
            List<CBS_MentorBuddy> cbs_MentorBuddyList = db.CBS_MentorBuddy.Where(x => x.Approved == false ).ToList();

            List<CBS_PublicAppearences> cbs_PublicAppearencesList = db.CBS_PublicAppearences.Where(x => x.Approved == false ).ToList();
            List<CBS_UniversitySessions> cbs_UniversitySessionsList = db.CBS_UniversitySessions.Where(x => x.Approved == false ).ToList();
            List<CBS_Engagement> cbs_EngagementList = db.CBS_Engagement.Where(x => x.Approved == false ).ToList();
            List<CBS_ValueInnovations> cbs_ValueInnovationsList = db.CBS_ValueInnovations.Where(x => x.Approved == false ).ToList();
            List<CBS_Attendances> cbs_AttendancesList = db.CBS_Attendances.Where(x => x.Approved == false ).ToList();

            List<CBS_FuelAllowances> cbs_FuelAllowancesList = db.CBS_FuelAllowances.Where(x => x.Approved == false ).ToList();
            List<CBS_ReportFormat> cbs_ReportFormatList = db.CBS_ReportFormat.Where(x => x.Approved == false ).ToList();
            List<CBS_SalaryInformation> cbs_SalaryInformationList = db.CBS_SalaryInformation.Where(x => x.Approved == false).ToList();
            List<CBS_AdditionalAccomplishments> cbs_AdditionalAccomplishmentsList = db.CBS_AdditionalAccomplishments.Where(x => x.Approved == false).ToList();
            List<CBS_Benefits> cbs_BenifitsList = db.CBS_Benefits.Where(x => x.Approved == false).ToList();


            CBS_DTO cbs_dto = new CBS_DTO();
            //cbs_dto.cbs_employee = cbs_employees;
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Promotions_Manage"))
            {
                cbs_dto.cbs_PromotionsList = cbs_PromotionsList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Increments_Manage"))
            {
                cbs_dto.cbs_IncrementsList = cbs_IncrementsList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Bonuses_Manage"))
            {
                cbs_dto.cbs_BonusesList = cbs_BonusesList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Awards_Manage"))
            {
                cbs_dto.cbs_AwardsList = cbs_AwardsList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_EmployeeBillingUtilization_Manage"))
            {
                cbs_dto.cbs_EmployeeBillingUtilizationList = cbs_EmployeeBillingUtilizationList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_CustomerFeedbackScore_Manage"))
            {
                cbs_dto.cbs_CustomerFeedbackScoreList = cbs_CustomerFeedbackScoreList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Trainings_Manage"))
            {
                cbs_dto.cbs_TrainingsList = cbs_TrainingsList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Travels_Manage"))
            {
                cbs_dto.cbs_TravelsList = cbs_TravelsList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_TechnologyExposure_Manage"))
            {
                cbs_dto.cbs_TechnologyExposureList = cbs_TechnologyExposureList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_MentorBuddy_Manage"))
            {
                cbs_dto.cbs_MentorBuddyList = cbs_MentorBuddyList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_PublicAppearences_Manage"))
            {
                cbs_dto.cbs_PublicAppearencesList = cbs_PublicAppearencesList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_UniversitySessions_Manage"))
            {
                cbs_dto.cbs_UniversitySessionsList = cbs_UniversitySessionsList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Engagement_Manage"))
            {
                cbs_dto.cbs_EngagementList = cbs_EngagementList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_ValueInnovations_Manage"))
            {
                cbs_dto.cbs_ValueInnovationsList = cbs_ValueInnovationsList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Attendances_Manage"))
            {
                cbs_dto.cbs_AttendancesList = cbs_AttendancesList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_FuelAllowances_Manage"))
            {
                cbs_dto.cbs_FuelAllowancesList = cbs_FuelAllowancesList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_ReportFormat_Manage"))
            {
                cbs_dto.cbs_ReportFormatList = cbs_ReportFormatList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_SalaryInformation_Manage"))
            {
                cbs_dto.cbs_SalaryInformationList = cbs_SalaryInformationList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_AdditionalAccomplishments_Manage"))
            {
                cbs_dto.cbs_AdditionalAccomplishmentsList = cbs_AdditionalAccomplishmentsList;
            }
            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Benefits_Manage"))
            {
                cbs_dto.cbs_BenefitsList = cbs_BenifitsList;
            }

            return Json(cbs_dto, JsonRequestBehavior.AllowGet);
        }

        // GET :/Admin/DataApprove/Discard/
        public ActionResult Discard(ID_List approved_ids)
        {
            var returnData = new Object();
            if (approved_ids != null && approved_ids.ids != null)
            {
                foreach (var ID in approved_ids.ids)
                {
                    switch (approved_ids.datatype)
                    {
                        case "CBS_Attendances":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Attendances_Manage"))
                            {
                                CBS_Attendances cbs_attendances = db.CBS_Attendances.Find(ID.id);
                                if (cbs_attendances.Approved == false)
                                {
                                    db.CBS_Attendances.Remove(cbs_attendances);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_Attendances.Where(x => x.Approved == false).ToList();
                            break;
                        case "CBS_Awards":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Awards_Manage"))
                            {
                                CBS_Awards cbs_awards = db.CBS_Awards.Find(ID.id);
                                if (cbs_awards.Approved == false)
                                {
                                    db.CBS_Awards.Remove(cbs_awards);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_Awards.Where(x => x.Approved == false).ToList();
                            break;
                        case "CBS_Bonuses":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Bonuses_Manage"))
                            {
                                CBS_Bonuses cbs_bonuses = db.CBS_Bonuses.Find(ID.id);
                                if (cbs_bonuses.Approved == false)
                                {
                                    db.CBS_Bonuses.Remove(cbs_bonuses);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_Bonuses.Where(x => x.Approved == false).ToList();
                            break;
                        case "CBS_CustomerFeedbackScore":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_CustomerFeedbackScore_Manage"))
                            {
                                CBS_CustomerFeedbackScore cbs_customerfeedbackscore = db.CBS_CustomerFeedbackScore.Find(ID.id);
                                if (cbs_customerfeedbackscore.Approved == false)
                                {
                                    db.CBS_CustomerFeedbackScore.Remove(cbs_customerfeedbackscore);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_CustomerFeedbackScore.Where(x => x.Approved == false).ToList();
                            break;
                        case "CBS_EmployeeBillingUtilization":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_EmployeeBillingUtilization_Manage"))
                            {
                                CBS_EmployeeBillingUtilization cbs_employeebillingutilization = db.CBS_EmployeeBillingUtilization.Find(ID.id);
                                if (cbs_employeebillingutilization.Approved == false)
                                {
                                    db.CBS_EmployeeBillingUtilization.Remove(cbs_employeebillingutilization);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_EmployeeBillingUtilization.Where(x => x.Approved == false).ToList();
                            break;

                        case "CBS_Engagement":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Engagement_Manage"))
                            {
                                CBS_Engagement cbs_engagement = db.CBS_Engagement.Find(ID.id);
                                if (cbs_engagement.Approved == false)
                                {
                                    db.CBS_Engagement.Remove(cbs_engagement);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_Engagement.Where(x => x.Approved == false).ToList();
                            break;
                        case "CBS_FuelAllowances":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_FuelAllowances_Manage"))
                            {
                                CBS_FuelAllowances cbs_fuelallowances = db.CBS_FuelAllowances.Find(ID.id);
                                if (cbs_fuelallowances.Approved == false)
                                {
                                    db.CBS_FuelAllowances.Remove(cbs_fuelallowances);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_FuelAllowances.Where(x => x.Approved == false).ToList();
                            break;
                        case "CBS_Increments":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Increments_Manage"))
                            {
                                CBS_Increments cbs_increments = db.CBS_Increments.Find(ID.id);
                                if (cbs_increments.Approved == false)
                                {
                                    db.CBS_Increments.Remove(cbs_increments);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_Increments.Where(x => x.Approved == false).ToList();
                            break;
                        case "CBS_MentorBuddy":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_MentorBuddy_Manage"))
                            {
                                CBS_MentorBuddy cbs_mentorbuddy = db.CBS_MentorBuddy.Find(ID.id);
                                if (cbs_mentorbuddy.Approved == false)
                                {
                                    db.CBS_MentorBuddy.Remove(cbs_mentorbuddy);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_MentorBuddy.Where(x => x.Approved == false).ToList();
                            break;
                        case "CBS_Promotions":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Promotions_Manage"))
                            {
                                CBS_Promotions cbs_promotions = db.CBS_Promotions.Find(ID.id);
                                if (cbs_promotions.Approved == false)
                                {
                                    db.CBS_Promotions.Remove(cbs_promotions);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_Promotions.Where(x => x.Approved == false).ToList();
                            break;

                        case "CBS_PublicAppearences":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_PublicAppearences_Manage"))
                            {
                                CBS_PublicAppearences cbs_publicappearences = db.CBS_PublicAppearences.Find(ID.id);
                                if (cbs_publicappearences.Approved == false)
                                {
                                    db.CBS_PublicAppearences.Remove(cbs_publicappearences);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_PublicAppearences.Where(x => x.Approved == false).ToList();
                            break;
                        case "CBS_TechnologyExposure":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_TechnologyExposure_Manage"))
                            {
                                CBS_TechnologyExposure cbs_technologyexposure = db.CBS_TechnologyExposure.Find(ID.id);
                                if (cbs_technologyexposure.Approved == false)
                                {
                                    db.CBS_TechnologyExposure.Remove(cbs_technologyexposure);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_TechnologyExposure.Where(x => x.Approved == false).ToList();
                            break;
                        case "CBS_Trainings":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Trainings_Manage"))
                            {
                                CBS_Trainings cbs_trainings = db.CBS_Trainings.Find(ID.id);
                                if (cbs_trainings.Approved == false)
                                {
                                    db.CBS_Trainings.Remove(cbs_trainings);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_Trainings.Where(x => x.Approved == false).ToList();
                            break;
                        case "CBS_Travels":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Travels_Manage"))
                            {
                                CBS_Travels cbs_travels = db.CBS_Travels.Find(ID.id);
                                if (cbs_travels.Approved == false)
                                {
                                    db.CBS_Travels.Remove(cbs_travels);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_Travels.Where(x => x.Approved == false).ToList();
                            break;
                        case "CBS_UniversitySessions":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_UniversitySessions_Manage"))
                            {
                                CBS_UniversitySessions cbs_universitysessions = db.CBS_UniversitySessions.Find(ID.id);
                                if (cbs_universitysessions.Approved == false)
                                {
                                    db.CBS_UniversitySessions.Remove(cbs_universitysessions);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_UniversitySessions.Where(x => x.Approved == false).ToList();
                            break;

                        case "CBS_ValueInnovations":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_ValueInnovations_Manage"))
                            {
                                CBS_ValueInnovations cbs_valueinnovations = db.CBS_ValueInnovations.Find(ID.id);
                                if (cbs_valueinnovations.Approved == false)
                                {
                                    db.CBS_ValueInnovations.Remove(cbs_valueinnovations);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_ValueInnovations.Where(x => x.Approved == false).ToList();
                            break;

                        case "CBS_SalaryInformation":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_SalaryInformation_Manage"))
                            {
                                CBS_SalaryInformation cbs_salaryinformation = db.CBS_SalaryInformation.Find(ID.id);
                                if (cbs_salaryinformation.Approved == false)
                                {
                                    db.CBS_SalaryInformation.Remove(cbs_salaryinformation);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_SalaryInformation.Where(x => x.Approved == false).ToList();
                            break;

                        case "CBS_AdditionalAccomplishments":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_AdditionalAccomplishments_Manage"))
                            {
                                CBS_AdditionalAccomplishments cbs_additionalaccomplishments = db.CBS_AdditionalAccomplishments.Find(ID.id);
                                if (cbs_additionalaccomplishments.Approved == false)
                                {
                                    db.CBS_AdditionalAccomplishments.Remove(cbs_additionalaccomplishments);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_AdditionalAccomplishments.Where(x => x.Approved == false).ToList();
                            break;

                        case "CBS_Benefits":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Benefits_Manage"))
                            {
                                CBS_Benefits cbs_benifits = db.CBS_Benefits.Find(ID.id);
                                if (cbs_benifits.Approved == false)
                                {
                                    db.CBS_Benefits.Remove(cbs_benifits);
                                    db.SaveChanges();
                                }
                            }
                            returnData = db.CBS_Benefits.Where(x => x.Approved == false).ToList();
                            break;
                    }
                }
                return Json(returnData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                switch (approved_ids.datatype)
                {
                    case "CBS_Attendances":
                        returnData = db.CBS_Attendances.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_Awards":
                        returnData = db.CBS_Awards.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_Bonuses":
                        returnData = db.CBS_Bonuses.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_CustomerFeedbackScore":
                        returnData = db.CBS_CustomerFeedbackScore.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_EmployeeBillingUtilization":
                        returnData = db.CBS_EmployeeBillingUtilization.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_Engagement":
                        returnData = db.CBS_Engagement.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_FuelAllowances":
                        returnData = db.CBS_FuelAllowances.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_Increments":
                        returnData = db.CBS_Increments.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_MentorBuddy":
                        returnData = db.CBS_MentorBuddy.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_Promotions":
                        returnData = db.CBS_Promotions.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_PublicAppearences":
                        returnData = db.CBS_PublicAppearences.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_TechnologyExposure":
                        returnData = db.CBS_TechnologyExposure.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_Trainings":
                        returnData = db.CBS_Trainings.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_Travels":
                        returnData = db.CBS_Travels.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_UniversitySessions":
                        returnData = db.CBS_UniversitySessions.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_ValueInnovations":
                        returnData = db.CBS_ValueInnovations.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_SalaryInformation":
                        returnData = db.CBS_SalaryInformation.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_AdditionalAccomplishments":
                        returnData = db.CBS_AdditionalAccomplishments.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_Benefits":
                        returnData = db.CBS_Benefits.Where(x => x.Approved == false).ToList();
                        break;
                }
                return Json(returnData, JsonRequestBehavior.AllowGet);
            }
        }

        // GET :/Admin/DataApprove/Approve/
        public ActionResult Approve(ID_List approved_ids)
        {
            var returnData = new Object();
            if (approved_ids != null && approved_ids.ids != null)
            {
                foreach (var ID in approved_ids.ids)
                {
                    switch (approved_ids.datatype)
                    {
                        case "CBS_Attendances":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Attendances_Manage"))
                            {
                                CBS_Attendances cbs_attendances = db.CBS_Attendances.Find(ID.id);
                                if (cbs_attendances.TargetRowID == null)
                                {
                                    cbs_attendances.Approved = true;
                                }
                                else
                                {
                                    cbs_attendances.Approved = true;
                                    CBS_Attendances cbs_attendances_old = db.CBS_Attendances.Find(cbs_attendances.TargetRowID);
                                    db.CBS_Attendances.Remove(cbs_attendances_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_Attendances.Where(x => x.Approved == false ).ToList();
                            break;
                        case "CBS_Awards":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Awards_Manage"))
                            {
                                CBS_Awards cbs_awards = db.CBS_Awards.Find(ID.id);
                                if (cbs_awards.TargetRowID == null)
                                {
                                    cbs_awards.Approved = true;
                                }
                                else
                                {
                                    cbs_awards.Approved = true;
                                    CBS_Awards cbs_awards_old = db.CBS_Awards.Find(cbs_awards.TargetRowID);
                                    db.CBS_Awards.Remove(cbs_awards_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_Awards.Where(x => x.Approved == false ).ToList();
                            break;
                        case "CBS_Bonuses":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Bonuses_Manage"))
                            {
                                CBS_Bonuses cbs_bonuses = db.CBS_Bonuses.Find(ID.id);
                                if (cbs_bonuses.TargetRowID == null)
                                {
                                    cbs_bonuses.Approved = true;
                                }
                                else
                                {
                                    cbs_bonuses.Approved = true;
                                    CBS_Bonuses cbs_bonuses_old = db.CBS_Bonuses.Find(cbs_bonuses.TargetRowID);
                                    db.CBS_Bonuses.Remove(cbs_bonuses_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_Bonuses.Where(x => x.Approved == false ).ToList();
                            break;
                        case "CBS_CustomerFeedbackScore":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_CustomerFeedbackScore_Manage"))
                            {
                                CBS_CustomerFeedbackScore cbs_customerfeedbackscore = db.CBS_CustomerFeedbackScore.Find(ID.id);
                                if (cbs_customerfeedbackscore.TargetRowID == null)
                                {
                                    cbs_customerfeedbackscore.Approved = true;
                                }
                                else
                                {
                                    cbs_customerfeedbackscore.Approved = true;
                                    CBS_CustomerFeedbackScore cbs_customerfeedbackscore_old = db.CBS_CustomerFeedbackScore.Find(cbs_customerfeedbackscore.TargetRowID);
                                    db.CBS_CustomerFeedbackScore.Remove(cbs_customerfeedbackscore_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_CustomerFeedbackScore.Where(x => x.Approved == false ).ToList();
                            break;
                        case "CBS_EmployeeBillingUtilization":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_EmployeeBillingUtilization_Manage"))
                            {
                                CBS_EmployeeBillingUtilization cbs_employeebillingutilization = db.CBS_EmployeeBillingUtilization.Find(ID.id);
                                if (cbs_employeebillingutilization.TargetRowID == null)
                                {
                                    cbs_employeebillingutilization.Approved = true;
                                }
                                else
                                {
                                    cbs_employeebillingutilization.Approved = true;
                                    CBS_EmployeeBillingUtilization cbs_employeebillingutilization_old = db.CBS_EmployeeBillingUtilization.Find(cbs_employeebillingutilization.TargetRowID);
                                    db.CBS_EmployeeBillingUtilization.Remove(cbs_employeebillingutilization_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_EmployeeBillingUtilization.Where(x => x.Approved == false ).ToList();
                            break;

                        case "CBS_Engagement":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Engagement_Manage"))
                            {
                                CBS_Engagement cbs_engagement = db.CBS_Engagement.Find(ID.id);
                                if (cbs_engagement.TargetRowID == null)
                                {
                                    cbs_engagement.Approved = true;
                                }
                                else
                                {
                                    cbs_engagement.Approved = true;
                                    CBS_Engagement cbs_engagement_old = db.CBS_Engagement.Find(cbs_engagement.TargetRowID);
                                    db.CBS_Engagement.Remove(cbs_engagement_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_Engagement.Where(x => x.Approved == false ).ToList();
                            break;
                        case "CBS_FuelAllowances":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_FuelAllowances_Manage"))
                            {
                                CBS_FuelAllowances cbs_fuelallowances = db.CBS_FuelAllowances.Find(ID.id);
                                if (cbs_fuelallowances.TargetRowID == null)
                                {
                                    cbs_fuelallowances.Approved = true;
                                }
                                else
                                {
                                    cbs_fuelallowances.Approved = true;
                                    CBS_FuelAllowances cbs_fuelallowances_old = db.CBS_FuelAllowances.Find(cbs_fuelallowances.TargetRowID);
                                    db.CBS_FuelAllowances.Remove(cbs_fuelallowances_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_FuelAllowances.Where(x => x.Approved == false ).ToList();
                            break;
                        case "CBS_Increments":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Increments_Manage"))
                            {
                                CBS_Increments cbs_increments = db.CBS_Increments.Find(ID.id);
                                if (cbs_increments.TargetRowID == null)
                                {
                                    cbs_increments.Approved = true;
                                }
                                else
                                {
                                    cbs_increments.Approved = true;
                                    CBS_Increments cbs_increments_old = db.CBS_Increments.Find(cbs_increments.TargetRowID);
                                    db.CBS_Increments.Remove(cbs_increments_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_Increments.Where(x => x.Approved == false ).ToList();
                            break;
                        case "CBS_MentorBuddy":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_MentorBuddy_Manage"))
                            {
                                CBS_MentorBuddy cbs_mentorbuddy = db.CBS_MentorBuddy.Find(ID.id);
                                if (cbs_mentorbuddy.TargetRowID == null)
                                {
                                    cbs_mentorbuddy.Approved = true;
                                }
                                else
                                {
                                    cbs_mentorbuddy.Approved = true;
                                    CBS_MentorBuddy cbs_mentorbuddy_old = db.CBS_MentorBuddy.Find(cbs_mentorbuddy.TargetRowID);
                                    db.CBS_MentorBuddy.Remove(cbs_mentorbuddy_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_MentorBuddy.Where(x => x.Approved == false ).ToList();
                            break;
                        case "CBS_Promotions":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Promotions_Manage"))
                            {
                                CBS_Promotions cbs_promotions = db.CBS_Promotions.Find(ID.id);
                                if (cbs_promotions.TargetRowID == null)
                                {
                                    cbs_promotions.Approved = true;
                                }
                                else
                                {
                                    cbs_promotions.Approved = true;
                                    CBS_Promotions cbs_promotions_old = db.CBS_Promotions.Find(cbs_promotions.TargetRowID);
                                    db.CBS_Promotions.Remove(cbs_promotions_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_Promotions.Where(x => x.Approved == false ).ToList();
                            break;
                        case "CBS_PublicAppearences":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_PublicAppearences_Manage"))
                            {
                                CBS_PublicAppearences cbs_publicappearences = db.CBS_PublicAppearences.Find(ID.id);
                                if (cbs_publicappearences.TargetRowID == null)
                                {
                                    cbs_publicappearences.Approved = true;
                                }
                                else
                                {
                                    cbs_publicappearences.Approved = true;
                                    CBS_PublicAppearences cbs_publicappearences_old = db.CBS_PublicAppearences.Find(cbs_publicappearences.TargetRowID);
                                    db.CBS_PublicAppearences.Remove(cbs_publicappearences_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_PublicAppearences.Where(x => x.Approved == false ).ToList();
                            break;

                        case "CBS_TechnologyExposure":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_TechnologyExposure_Manage"))
                            {
                                CBS_TechnologyExposure cbs_technologyexposure = db.CBS_TechnologyExposure.Find(ID.id);
                                if (cbs_technologyexposure.TargetRowID == null)
                                {
                                    cbs_technologyexposure.Approved = true;
                                }
                                else
                                {
                                    cbs_technologyexposure.Approved = true;
                                    CBS_TechnologyExposure cbs_technologyexposure_old = db.CBS_TechnologyExposure.Find(cbs_technologyexposure.TargetRowID);
                                    db.CBS_TechnologyExposure.Remove(cbs_technologyexposure_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_TechnologyExposure.Where(x => x.Approved == false ).ToList();
                            break;
                        case "CBS_Trainings":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Trainings_Manage"))
                            {
                                CBS_Trainings cbs_trainings = db.CBS_Trainings.Find(ID.id);
                                if (cbs_trainings.TargetRowID == null)
                                {
                                    cbs_trainings.Approved = true;
                                }
                                else
                                {
                                    cbs_trainings.Approved = true;
                                    CBS_Trainings cbs_trainings_old = db.CBS_Trainings.Find(cbs_trainings.TargetRowID);
                                    db.CBS_Trainings.Remove(cbs_trainings_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_Trainings.Where(x => x.Approved == false ).ToList();
                            break;
                        case "CBS_Travels":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Travels_Manage"))
                            {
                                CBS_Travels cbs_travels = db.CBS_Travels.Find(ID.id);
                                if (cbs_travels.TargetRowID == null)
                                {
                                    cbs_travels.Approved = true;
                                }
                                else
                                {
                                    cbs_travels.Approved = true;
                                    CBS_Travels cbs_travels_old = db.CBS_Travels.Find(cbs_travels.TargetRowID);
                                    db.CBS_Travels.Remove(cbs_travels_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_Travels.Where(x => x.Approved == false ).ToList();
                            break;
                        case "CBS_UniversitySessions":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_UniversitySessions_Manage"))
                            {
                                CBS_UniversitySessions cbs_universitysessions = db.CBS_UniversitySessions.Find(ID.id);
                                if (cbs_universitysessions.TargetRowID == null)
                                {
                                    cbs_universitysessions.Approved = true;
                                }
                                else
                                {
                                    cbs_universitysessions.Approved = true;
                                    CBS_UniversitySessions cbs_universitysessions_old = db.CBS_UniversitySessions.Find(cbs_universitysessions.TargetRowID);
                                    db.CBS_UniversitySessions.Remove(cbs_universitysessions_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_UniversitySessions.Where(x => x.Approved == false ).ToList();
                            break;
                        case "CBS_ValueInnovations":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_ValueInnovations_Manage"))
                            {
                                CBS_ValueInnovations cbs_valueinnovations = db.CBS_ValueInnovations.Find(ID.id);
                                if (cbs_valueinnovations.TargetRowID == null)
                                {
                                    cbs_valueinnovations.Approved = true;
                                }
                                else
                                {
                                    cbs_valueinnovations.Approved = true;
                                    CBS_ValueInnovations cbs_valueinnovations_old = db.CBS_ValueInnovations.Find(cbs_valueinnovations.TargetRowID);
                                    db.CBS_ValueInnovations.Remove(cbs_valueinnovations_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_ValueInnovations.Where(x => x.Approved == false ).ToList();
                            break;

                        case "CBS_SalaryInformation":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_SalaryInformation_Manage"))
                            {
                                CBS_SalaryInformation cbs_salaryinformation = db.CBS_SalaryInformation.Find(ID.id);
                                if (cbs_salaryinformation.TargetRowID == null)
                                {
                                    cbs_salaryinformation.Approved = true;
                                }
                                else
                                {
                                    cbs_salaryinformation.Approved = true;
                                    CBS_SalaryInformation cbs_salaryinformation_old = db.CBS_SalaryInformation.Find(cbs_salaryinformation.TargetRowID);
                                    db.CBS_SalaryInformation.Remove(cbs_salaryinformation_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_SalaryInformation.Where(x => x.Approved == false).ToList();
                            break;

                        case "CBS_AdditionalAccomplishments":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_AdditionalAccomplishments_Manage"))
                            {
                                CBS_AdditionalAccomplishments cbs_additionalaccomplishments = db.CBS_AdditionalAccomplishments.Find(ID.id);
                                if (cbs_additionalaccomplishments.TargetRowID == null)
                                {
                                    cbs_additionalaccomplishments.Approved = true;
                                }
                                else
                                {
                                    cbs_additionalaccomplishments.Approved = true;
                                    CBS_AdditionalAccomplishments cbs_additionalaccomplishments_old = db.CBS_AdditionalAccomplishments.Find(cbs_additionalaccomplishments.TargetRowID);
                                    db.CBS_AdditionalAccomplishments.Remove(cbs_additionalaccomplishments_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_AdditionalAccomplishments.Where(x => x.Approved == false).ToList();
                            break;

                        case "CBS_Benefits":
                            if (User.IsInRole("Admin") || User.IsInRole("Manager") || User.IsInRole("CBS_Benefits_Manage"))
                            {
                                CBS_Benefits cbs_benefits = db.CBS_Benefits.Find(ID.id);

                                if (cbs_benefits.TargetRowID == null)
                                {
                                    cbs_benefits.Approved = true;
                                }
                                else
                                {
                                    cbs_benefits.Approved = true;
                                    CBS_Benefits cbs_benefits_old = db.CBS_Benefits.Find(cbs_benefits.TargetRowID);
                                    db.CBS_Benefits.Remove(cbs_benefits_old);
                                }
                                db.SaveChanges();
                            }
                            returnData = db.CBS_Benefits.Where(x => x.Approved == false).ToList();
                            break;
                    }
                }
                return Json(returnData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                switch (approved_ids.datatype)
                {
                    case "CBS_Attendances":
                        returnData = db.CBS_Attendances.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_Awards":
                        returnData = db.CBS_Awards.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_Bonuses":
                        returnData = db.CBS_Bonuses.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_CustomerFeedbackScore":
                        returnData = db.CBS_CustomerFeedbackScore.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_EmployeeBillingUtilization":
                        returnData = db.CBS_EmployeeBillingUtilization.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_Engagement":
                        returnData = db.CBS_Engagement.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_FuelAllowances":
                        returnData = db.CBS_FuelAllowances.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_Increments":
                        returnData = db.CBS_Increments.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_MentorBuddy":
                        returnData = db.CBS_MentorBuddy.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_Promotions":
                        returnData = db.CBS_Promotions.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_PublicAppearences":
                        returnData = db.CBS_PublicAppearences.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_TechnologyExposure":
                        returnData = db.CBS_TechnologyExposure.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_Trainings":
                        returnData = db.CBS_Trainings.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_Travels":
                        returnData = db.CBS_Travels.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_UniversitySessions":
                        returnData = db.CBS_UniversitySessions.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_ValueInnovations":
                        returnData = db.CBS_ValueInnovations.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_SalaryInformation":
                        returnData = db.CBS_SalaryInformation.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_AdditionalAccomplishments":
                        returnData = db.CBS_AdditionalAccomplishments.Where(x => x.Approved == false).ToList();
                        break;
                    case "CBS_Benefits":
                        returnData = db.CBS_Benefits.Where(x => x.Approved == false).ToList();
                        break;
                }

                return Json(returnData, JsonRequestBehavior.AllowGet);
            }
        }
    }

    public class ID_List
    {
        public List<ID> ids { get; set; }
        public string datatype { get; set; }
    }

    public class ID
    {
        public int id { get; set; }
    }
}
