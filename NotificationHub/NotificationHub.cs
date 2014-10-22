using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Web.Security;
using System.Diagnostics;
using _99X_CBS.Models;

namespace _99X_CBS.NotificationHub
{
    public class NotificationHub : Hub
    {

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;
            var Db = new ApplicationDbContext();
            if (Context.User.Identity.IsAuthenticated)
            {
                var user = Db.Users.First(u => u.UserName == name);
                var allRoles = user.Roles;
                foreach (var role in allRoles)
                {
                    Groups.Add(Context.ConnectionId, role.Role.Name);
                }
            }
            return base.OnConnected();
        }

        public void Send(string group, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.Group(group).addNewMessageToPage(group, message);
        }

        public static void Notify(string message)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            hubContext.Clients.All.addNewMessageToPage(message);
        }

        public static void GroupNotify(string group, string message)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            hubContext.Clients.Group("Admin").addNewMessageToPage(group, message);
            hubContext.Clients.Group("Manager").addNewMessageToPage(group, message);
            hubContext.Clients.Group(group).addNewMessageToPage(group, message);
        }
    }
}