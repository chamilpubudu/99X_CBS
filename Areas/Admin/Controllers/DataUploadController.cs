using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Xml;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity;
using _99X_CBS.Models;


namespace _99X_CBS.Areas.Admin.Controllers
{
    public class DataUploadController : Controller
    {
        private Entities db = new Entities();
        //
        // GET: /Admin/DataUpload/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            DataSet ds = new DataSet();
            if (Request.Files["file"].ContentLength > 0)
            {
                string fileExtension = System.IO.Path.GetExtension(Request.Files["file"].FileName);

                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    string fileLocation = Server.MapPath("~/Content/") + Request.Files["file"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                    {

                        System.IO.File.Delete(fileLocation);
                    }
                    Request.Files["file"].SaveAs(fileLocation);
                    string excelConnectionString = string.Empty;
                    excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    //connection String for xls file format.
                    if (fileExtension == ".xls")
                    {
                        excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    //connection String for xlsx file format.
                    else if (fileExtension == ".xlsx")
                    {

                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }
                    //Create Connection to Excel work book and add oledb namespace
                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                    excelConnection.Open();
                    DataTable dt = new DataTable();

                    dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dt == null)
                    {
                        return null;
                    }

                    String[] excelSheets = new String[dt.Rows.Count];
                    int t = 0;
                    //excel data saves in temp file here.
                    foreach (DataRow row in dt.Rows)
                    {
                        excelSheets[t] = row["TABLE_NAME"].ToString();
                        t++;
                    }
                    OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);


                    string query = string.Format("Select * from [{0}]", excelSheets[0]);
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                    {
                        dataAdapter.Fill(ds);
                    }
                }
                if (fileExtension.ToString().ToLower().Equals(".xml"))
                {
                    string fileLocation = Server.MapPath("~/Content/") + Request.Files["FileUpload"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                    {
                        System.IO.File.Delete(fileLocation);
                    }

                    Request.Files["FileUpload"].SaveAs(fileLocation);
                    XmlTextReader xmlreader = new XmlTextReader(fileLocation);
                    //DataSet ds = new DataSet();
                    ds.ReadXml(xmlreader);
                    xmlreader.Close();
                }

                if (Request.Files["file"].FileName.Equals("Awards.xlsx"))
                {
                    CBS_Awards cbs_awards = new CBS_Awards();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        cbs_awards.Employee_Name = ds.Tables[0].Rows[i][0].ToString();
                        cbs_awards.Award_Date = ds.Tables[0].Rows[i][1].ToString();
                        cbs_awards.Award = ds.Tables[0].Rows[i][2].ToString();

                        if (ModelState.IsValid)
                        {
                            db.CBS_Awards.Add(cbs_awards);
                            db.SaveChanges();
                        }
                    }



                }
                else if (Request.Files["file"].FileName.Equals("Attendances.xlsx"))
                {
                    CBS_Attendances cbs_attendances = new CBS_Attendances();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        cbs_attendances.Employee_Name = ds.Tables[0].Rows[i][0].ToString();
                        cbs_attendances.Average_InTime = ds.Tables[0].Rows[i][1].ToString();
                        cbs_attendances.Average_OutTime = ds.Tables[0].Rows[i][2].ToString();
                        cbs_attendances.Weekends_Worked = ds.Tables[0].Rows[i][3].ToString();
                        cbs_attendances.Medical_Leaves_Taken = ds.Tables[0].Rows[i][4].ToString();
                        cbs_attendances.Casual_Leaves_Taken = ds.Tables[0].Rows[i][5].ToString();
                        cbs_attendances.Annual_Leaves_Taken = ds.Tables[0].Rows[i][6].ToString();
                        cbs_attendances.Lieu_Leaves_Taken = ds.Tables[0].Rows[i][7].ToString();
                        cbs_attendances.Number_of_Days_Reported_to_Work = ds.Tables[0].Rows[i][8].ToString();

                        if (ModelState.IsValid)
                        {
                            db.CBS_Attendances.Add(cbs_attendances);
                            db.SaveChanges();
                        }
                    }


                }

                else if (Request.Files["file"].FileName.Equals("CustomerFeedbackScore.xlsx"))
                {
                    CBS_CustomerFeedbackScore cbs_customerfeedbackscore = new CBS_CustomerFeedbackScore();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        cbs_customerfeedbackscore.Employee_Name = ds.Tables[0].Rows[i][0].ToString();
                        cbs_customerfeedbackscore.Feedback_Date = ds.Tables[0].Rows[i][1].ToString();
                        cbs_customerfeedbackscore.Score = ds.Tables[0].Rows[i][2].ToString();
                        cbs_customerfeedbackscore.Comments = ds.Tables[0].Rows[i][3].ToString();

                        if (ModelState.IsValid)
                        {
                            db.CBS_CustomerFeedbackScore.Add(cbs_customerfeedbackscore);
                            db.SaveChanges();
                        }
                    }


                }

                else if (Request.Files["file"].FileName.Equals("EmployeeBillingUtilization.xlsx"))
                {
                    CBS_EmployeeBillingUtilization cbs_employeebillingutilization = new CBS_EmployeeBillingUtilization();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        cbs_employeebillingutilization.Employee_Name = ds.Tables[0].Rows[i][0].ToString();
                        cbs_employeebillingutilization.From_Date = ds.Tables[0].Rows[i][1].ToString();
                        cbs_employeebillingutilization.To_Date = ds.Tables[0].Rows[i][2].ToString();
                        cbs_employeebillingutilization.Project = ds.Tables[0].Rows[i][3].ToString();
                        cbs_employeebillingutilization.Billing_Utilization = ds.Tables[0].Rows[i][4].ToString();

                        if (ModelState.IsValid)
                        {
                            db.CBS_EmployeeBillingUtilization.Add(cbs_employeebillingutilization);
                            db.SaveChanges();
                        }
                    }

                }

                else if (Request.Files["file"].FileName.Equals("Employees.xlsx"))
                {
                    CBS_Employees cbs_employees = new CBS_Employees();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        cbs_employees.Employee_Name = ds.Tables[0].Rows[i][0].ToString();
                        cbs_employees.Designation = ds.Tables[0].Rows[i][1].ToString();
                        cbs_employees.Date_Joined = ds.Tables[0].Rows[i][2].ToString();
                        cbs_employees.Career_Started_On = ds.Tables[0].Rows[i][3].ToString();
                        cbs_employees.Appraisal_Score = ds.Tables[0].Rows[i][4].ToString();

                        if (ModelState.IsValid)
                        {
                            db.CBS_Employees.Add(cbs_employees);
                            db.SaveChanges();
                        }
                    }
                }

                else if (Request.Files["file"].FileName.Equals("Engagement.xlsx"))
                {
                    CBS_Engagement cbs_engagement = new CBS_Engagement();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        cbs_engagement.Employee_Name = ds.Tables[0].Rows[i][0].ToString();
                        cbs_engagement.Date = ds.Tables[0].Rows[i][1].ToString();
                        cbs_engagement.Event = ds.Tables[0].Rows[i][2].ToString();

                        if (ModelState.IsValid)
                        {
                            db.CBS_Engagement.Add(cbs_engagement);
                            db.SaveChanges();
                        }
                    }
                }

                else if (Request.Files["file"].FileName.Equals("FuelAllowances.xlsx"))
                {
                    CBS_FuelAllowances cbs_fuelallowances = new CBS_FuelAllowances();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        cbs_fuelallowances.Employee_Name = ds.Tables[0].Rows[i][0].ToString();
                        cbs_fuelallowances.Fueling_Date = ds.Tables[0].Rows[i][1].ToString();
                        cbs_fuelallowances.Number_Of_Liters = ds.Tables[0].Rows[i][2].ToString();
                        cbs_fuelallowances.Amount = ds.Tables[0].Rows[i][3].ToString();

                        if (ModelState.IsValid)
                        {
                            db.CBS_FuelAllowances.Add(cbs_fuelallowances);
                            db.SaveChanges();
                        }
                    }
                }

                else if (Request.Files["file"].FileName.Equals("Increments.xlsx"))
                {
                    CBS_Increments cbs_increments = new CBS_Increments();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        cbs_increments.Employee_Name = ds.Tables[0].Rows[i][0].ToString();
                        cbs_increments.Effective_Date = ds.Tables[0].Rows[i][1].ToString();
                        cbs_increments.Increment_Amount = ds.Tables[0].Rows[i][2].ToString();

                        if (ModelState.IsValid)
                        {
                            db.CBS_Increments.Add(cbs_increments);
                            db.SaveChanges();
                        }
                    }
                }

                else if (Request.Files["file"].FileName.Equals("MentorBuddy.xlsx"))
                {
                    CBS_MentorBuddy cbs_mentorbuddy = new CBS_MentorBuddy();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        cbs_mentorbuddy.Employee_Name = ds.Tables[0].Rows[i][0].ToString();
                        cbs_mentorbuddy.Mentor_or_Buddy_Type = ds.Tables[0].Rows[i][1].ToString();
                        cbs_mentorbuddy.Mentor_or_Buddy = ds.Tables[0].Rows[i][2].ToString();

                        if (ModelState.IsValid)
                        {
                            db.CBS_MentorBuddy.Add(cbs_mentorbuddy);
                            db.SaveChanges();
                        }
                    }
                }

                else if (Request.Files["file"].FileName.Equals("Promotions.xlsx"))
                {
                    CBS_Promotions cbs_promotions = new CBS_Promotions();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        cbs_promotions.Employee_Name = ds.Tables[0].Rows[i][0].ToString();
                        cbs_promotions.Date = ds.Tables[0].Rows[i][1].ToString();
                        cbs_promotions.Promoted_To = ds.Tables[0].Rows[i][2].ToString();
                        cbs_promotions.Previous_Designation = ds.Tables[0].Rows[i][3].ToString();

                        if (ModelState.IsValid)
                        {
                            db.CBS_Promotions.Add(cbs_promotions);
                            db.SaveChanges();
                        }
                    }
                }

                else if (Request.Files["file"].FileName.Equals("PublicAppearences.xlsx"))
                {
                    CBS_PublicAppearences cbs_publicappearance = new CBS_PublicAppearences();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        cbs_publicappearance.Employee_Name = ds.Tables[0].Rows[i][0].ToString();
                        cbs_publicappearance.Appearance_Date = ds.Tables[0].Rows[i][1].ToString();
                        cbs_publicappearance.Location = ds.Tables[0].Rows[i][2].ToString();
                        cbs_publicappearance.Event_Name = ds.Tables[0].Rows[i][3].ToString();
                        cbs_publicappearance.Session_Topic = ds.Tables[0].Rows[i][4].ToString();
                        cbs_publicappearance.Number_Of_Participants = ds.Tables[0].Rows[i][5].ToString();

                        if (ModelState.IsValid)
                        {
                            db.CBS_PublicAppearences.Add(cbs_publicappearance);
                            db.SaveChanges();
                        }
                    }
                }

                else if (Request.Files["file"].FileName.Equals("TechnologyExposure.xlsx"))
                {
                    CBS_TechnologyExposure cbs_technologyexposure = new CBS_TechnologyExposure();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        cbs_technologyexposure.Employee_Name = ds.Tables[0].Rows[i][0].ToString();
                        cbs_technologyexposure.Engagement = ds.Tables[0].Rows[i][1].ToString();
                        cbs_technologyexposure.Technologies = ds.Tables[0].Rows[i][2].ToString();

                        if (ModelState.IsValid)
                        {
                            db.CBS_TechnologyExposure.Add(cbs_technologyexposure);
                            db.SaveChanges();
                        }
                    }
                }

                else if (Request.Files["file"].FileName.Equals("Trainings.xlsx"))
                {
                    CBS_Trainings cbs_trainings = new CBS_Trainings();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        cbs_trainings.Employee_Name = ds.Tables[0].Rows[i][0].ToString();
                        cbs_trainings.Course_Name = ds.Tables[0].Rows[i][1].ToString();
                        cbs_trainings.Training_Provider = ds.Tables[0].Rows[i][2].ToString();
                        cbs_trainings.External = ds.Tables[0].Rows[i][3].ToString();
                        cbs_trainings.Category = ds.Tables[0].Rows[i][4].ToString();
                        cbs_trainings.Training_Month = ds.Tables[0].Rows[i][5].ToString();
                        cbs_trainings.Time_Duration = ds.Tables[0].Rows[i][6].ToString();
                        cbs_trainings.Cost_Money = ds.Tables[0].Rows[i][7].ToString();

                        if (ModelState.IsValid)
                        {
                            db.CBS_Trainings.Add(cbs_trainings);
                            db.SaveChanges();
                        }
                    }
                }

                else if (Request.Files["file"].FileName.Equals("Travels.xlsx"))
                {
                    CBS_Travels cbs_travels = new CBS_Travels();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        cbs_travels.Employee_Name = ds.Tables[0].Rows[i][0].ToString();
                        cbs_travels.Started_Date = ds.Tables[0].Rows[i][1].ToString();
                        cbs_travels.Number_Of_Days = ds.Tables[0].Rows[i][2].ToString();
                        cbs_travels.Country = ds.Tables[0].Rows[i][3].ToString();
                        cbs_travels.City = ds.Tables[0].Rows[i][4].ToString();
                        cbs_travels.Allowance_In_SLR = ds.Tables[0].Rows[i][5].ToString();
                        cbs_travels.Purpose = ds.Tables[0].Rows[i][6].ToString();

                        if (ModelState.IsValid)
                        {
                            db.CBS_Travels.Add(cbs_travels);
                            db.SaveChanges();
                        }
                    }
                }

                else if (Request.Files["file"].FileName.Equals("UniversitySessions.xlsx"))
                {
                    CBS_UniversitySessions cbs_universitysessions = new CBS_UniversitySessions();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        cbs_universitysessions.Employee_Name = ds.Tables[0].Rows[i][0].ToString();
                        cbs_universitysessions.Session_Date = ds.Tables[0].Rows[i][1].ToString();
                        cbs_universitysessions.Initiated_By = ds.Tables[0].Rows[i][2].ToString();
                        cbs_universitysessions.Location = ds.Tables[0].Rows[i][3].ToString();
                        cbs_universitysessions.Number_Of_Participants = ds.Tables[0].Rows[i][4].ToString();
                        cbs_universitysessions.Participants = ds.Tables[0].Rows[i][5].ToString();
                        cbs_universitysessions.Session_Type = ds.Tables[0].Rows[i][6].ToString();
                        cbs_universitysessions.Time_Duration = ds.Tables[0].Rows[i][7].ToString();
                        cbs_universitysessions.Topic = ds.Tables[0].Rows[i][8].ToString();
                        cbs_universitysessions.To_the_University = ds.Tables[0].Rows[i][9].ToString();

                        if (ModelState.IsValid)
                        {
                            db.CBS_UniversitySessions.Add(cbs_universitysessions);
                            db.SaveChanges();
                        }
                    }
                }

                else if (Request.Files["file"].FileName.Equals("ValueInnovations.xlsx"))
                {
                    CBS_ValueInnovations cbs_valueinnovations = new CBS_ValueInnovations();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        cbs_valueinnovations.Employee_Name = ds.Tables[0].Rows[i][0].ToString();
                        cbs_valueinnovations.Innovation_Date = ds.Tables[0].Rows[i][1].ToString();
                        cbs_valueinnovations.Value_Innovation = ds.Tables[0].Rows[i][2].ToString();


                        if (ModelState.IsValid)
                        {
                            db.CBS_ValueInnovations.Add(cbs_valueinnovations);
                            db.SaveChanges();
                        }
                    }
                }
            }
            return View();
        }

    }
}