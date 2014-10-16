using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _99X_CBS.Models
{
    public class SystemSettings
    {
        public static string GetAppName()
        {
            Entities db = new Entities();
            string _GlobalAppName = (string)HttpContext.Current.Application["_GlobalAppName"];
            if (_GlobalAppName != null || _GlobalAppName != "")
            {
                try
                {
                    CBS_SystemSettings cbs_systemsettings = db.CBS_SystemSettings.Where(x => x.Name == "System Name").First();
                    _GlobalAppName = cbs_systemsettings.Value;
                }
                catch (InvalidOperationException e)
                {
                    _GlobalAppName = "CBS";
                }
                
            }
            
            return _GlobalAppName;
        }

        public static string GetAppLogo()
        {
            Entities db = new Entities();
            string _GlobalAppLogo = (string)HttpContext.Current.Application["_GlobalAppLogo"];
            if (_GlobalAppLogo != null || _GlobalAppLogo != "")
            {
                try
                { 
                    CBS_SystemSettings cbs_systemsettings = db.CBS_SystemSettings.Where(x => x.Name == "Photo Name").First();
                    _GlobalAppLogo = cbs_systemsettings.Value;
                }
                catch (InvalidOperationException e)
                {
                    _GlobalAppLogo = "logo-black.png";
                }

            }

            return _GlobalAppLogo;
        }
    }
}