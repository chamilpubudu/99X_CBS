using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _99X_CBS.Models
{
    public class CBS_NotificationInfo : ICloneable
    {
        public string NotificationID { get; set; }
        public bool Viewed { get; set; }
        public Nullable<System.DateTime> NotifiedTime { get; set; }
        public int ID { get; set; }
        public string Message { get; set; }
        public string UserID { get; set; }
        public string Link { get; set; }

        public object Clone()
        {
            return new CBS_NotificationInfo() { NotificationID = this.NotificationID, Viewed = this.Viewed, NotifiedTime = this.NotifiedTime, Message = this.Message, UserID = this.UserID, Link = this.Link };
        }
    }
}