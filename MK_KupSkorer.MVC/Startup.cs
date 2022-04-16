using Microsoft.Owin;
using MK_KupSkorer.Services;
using Owin;


[assembly: OwinStartupAttribute(typeof(MK_KupSkorer.MVC.Startup))]
namespace MK_KupSkorer.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var roleService = new RoleService();
            roleService.CreateAdmin();
            roleService.MakeMeAdmin();
        }
    }
}
