using Microsoft.AspNet.Identity.EntityFramework;
using MK_KupSkorer.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MK_KupSkorer.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Kup> Kups { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Player> Players { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());
        }
    }
}