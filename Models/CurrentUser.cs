using System.Linq;
using System.Security.Principal;
using System.Web;
using Microsoft.AspNet.Identity;
using System;

namespace _99X_CBS.Models
{
    public class CurrentUser
    {
        public static string GetEmpID(HttpSessionStateBase Session, IPrincipal User)
        {
            object employeeID = Session["_currentEmployeeID"];
            if (employeeID == null)
            {
                Entities db = new Entities();
                string userID = User.Identity.GetUserName();
                CBS_Employees cbs_Employee = null;
                try {
                    
                    cbs_Employee = db.CBS_Employees.Where(x => x.Approved == true && x.UserID == userID).First();
                }catch{
                    return "";
                }
                if (cbs_Employee != null)
                {
                    employeeID = cbs_Employee.EmpID;
                    HttpContext.Current.Session["_currentEmployeeID"] = employeeID;
                }                
            }
            return employeeID.ToString();
        }
    }
}