using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MK_KupSkorer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MK_KupSkorer.Services
{
    public class RoleService
    {
        public void CreateAdmin()
        {
            ApplicationDbContext ctx = new ApplicationDbContext();

            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));


            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));

            if(!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }
        }

        public void MakeMeAdmin()
        {
            ApplicationDbContext ctx = new ApplicationDbContext();

            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));

            var myUser = ctx.Users.SingleOrDefault(u => u.UserName == "Dusty Bottoms");
            if (myUser != null)
            {
                var result = userManager.AddToRole(myUser.Id, "Admin");
            }
        }

    }
}
