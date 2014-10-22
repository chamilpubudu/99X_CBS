using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_99X_CBS.Startup))]
namespace _99X_CBS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
