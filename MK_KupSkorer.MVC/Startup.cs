using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MK_KupSkorer.MVC.Startup))]
namespace MK_KupSkorer.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
