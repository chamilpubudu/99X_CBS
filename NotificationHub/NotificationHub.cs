using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Web.Security;
using System.Diagnostics;
using _99X_CBS.Models;
using Newtonsoft.Json;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace _99X_CBS.NotificationHub
{
    public class NotificationHub : Hub
    {

      private static Entities entitiesDb = new Entities();
      private static ApplicationDbContext applicationDbContext = new ApplicationDbContext();

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;
            if (Context.User.Identity.IsAuthenticated)
            {
                var user = applicationDbContext.Users.First(u => u.UserName == name);
                var allRoles = user.Roles;
                foreach (var role in allRoles)
                {
                    Groups.Add(Context.ConnectionId, role.Role.Name);
                }
            }
            return base.OnConnected();
        }

        public void getInitialNotifications()
        {
            string name = Context.User.Identity.Name;
            List<CBS_NotificationInfo> cbs_NotificationInfoList = entitiesDb.CBS_NotificationInfo.Where(n => n.UserID == name).OrderByDescending(n => n.NotifiedTime).Take(10).ToList();
            string strJson = JsonConvert.SerializeObject(cbs_NotificationInfoList);
            Clients.Caller.setInitialNotifications(strJson);
        }


        public void viewNotification(int ID)
        {
            string name = Context.User.Identity.Name;
            CBS_NotificationInfo cbs_NotificationInfo = entitiesDb.CBS_NotificationInfo.Find(ID);
            cbs_NotificationInfo.Viewed = true;
            entitiesDb.Entry(cbs_NotificationInfo).State = EntityState.Modified;
            entitiesDb.SaveChanges();
            Clients.Caller.reloadNotifications();
        }

        public static void NotifyAll(string message, string link)
        {
            
            HashSet<ApplicationUser> usersList = new HashSet<ApplicationUser>();
            usersList.UnionWith(applicationDbContext.Users.ToList());

            SaveNotificationToDB(usersList, message, link);

            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            hubContext.Clients.All.reloadNotifications();
        }

        public static void GroupNotify(string groupName, string message, string link)
        {
            var roleNameAdmin = "Admin";
            var roleNameManager = "Manager";

            HashSet<ApplicationUser> usersList = new HashSet<ApplicationUser>();
            usersList.UnionWith(GetUsersInGroup(roleNameAdmin));
            usersList.UnionWith(GetUsersInGroup(roleNameManager));
            usersList.UnionWith(GetUsersInGroup(groupName));

            SaveNotificationToDB(usersList,message,link);

            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            hubContext.Clients.Group("Admin").reloadNotifications();
            hubContext.Clients.Group("Manager").reloadNotifications();
            hubContext.Clients.Group(groupName).reloadNotifications();
        }

        private static List<ApplicationUser> GetUsersInGroup(string groupName)
        {
            return applicationDbContext.Users.Where(u => u.Roles.Where(r => r.Role.Name == groupName).FirstOrDefault().Role.Name == groupName).ToList();
        }

        private static void SaveNotificationToDB(HashSet<ApplicationUser> usersList, string message, string link)
        {
            CBS_NotificationInfo cbs_NotificationInfo = new CBS_NotificationInfo();
            cbs_NotificationInfo.NotifiedTime = System.DateTime.Now;
            cbs_NotificationInfo.Message = message;
            cbs_NotificationInfo.Viewed = false;
            cbs_NotificationInfo.Link = link;
            cbs_NotificationInfo.NotificationID = System.DateTime.Now.Ticks.ToString();

            foreach (var user in usersList)
            {
                var notification = (CBS_NotificationInfo)cbs_NotificationInfo.Clone();
                notification.UserID = user.UserName;
                entitiesDb.CBS_NotificationInfo.Add(notification);
            }
            entitiesDb.SaveChanges(); 
        }
    }
}