using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _99X_CBS.Models
{
    public class CBS_NotificationInfo
    {
        public string NotificationID { get; set; }
        public bool Viewed { get; set; }
        public Nullable<System.DateTime> NotifiedTime { get; set; }
        public int ID { get; set; }
        public string Message { get; set; }
        public string UserID { get; set; }
        public string Link { get; set; }
    }
}