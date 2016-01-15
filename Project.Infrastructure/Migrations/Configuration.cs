using Project.Infrastructure.Models;
using System.Data.Entity.Migrations;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Project.Infrastructure.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Project.Infrastructure.Models.ApplicationDbContext>
    {
       public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }


        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentity(context);
            base.Seed(context);
        }

        public static void InitializeIdentity(ApplicationDbContext db)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var roleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>());

            const string name = "test@test.com";
            const string password = "!Q2w3e";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name };
                userManager.Create(user, password);
                userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}
