namespace AspNetIdentity.WebApi.Migrations
{
    using AspNetIdentity.WebApi.Infrastructure;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AspNetIdentity.WebApi.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AspNetIdentity.WebApi.Infrastructure.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "memo",
                Email = "iemomon@hotmail.com",
                EmailConfirmed = true,
                FirstName = "Michael",
                LastName = "Emo",
                Level = 1,
                JoinDate = DateTime.Now.AddYears(-3)
            };

            manager.Create(user, "P@ssword");

            user = new ApplicationUser()
            {
                UserName = "simple",
                Email = "user@hotmail.com",
                EmailConfirmed = true,
                FirstName = "Jon",
                LastName = "Nelson",
                Level = 1,
                JoinDate = DateTime.Now.AddYears(-2)
            };
            manager.Create(user, "P@ssword");

            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = "SuperAdmin" });
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
                roleManager.Create(new IdentityRole { Name = "DHUser" });
                roleManager.Create(new IdentityRole { Name = "DHAdmin" });
                roleManager.Create(new IdentityRole { Name = "DSUser" });
                roleManager.Create(new IdentityRole { Name = "DSAdmin" });
                roleManager.Create(new IdentityRole { Name = "WPUser" });
                roleManager.Create(new IdentityRole { Name = "WPAdmin" });
            }

            var lookUpUser = manager.FindByName("memo");
            manager.AddToRoles(lookUpUser.Id, new string[] { "SuperAdmin", "Admin" });

            lookUpUser = manager.FindByName("simple");
            manager.AddToRoles(lookUpUser.Id, new string[] { "User" });
        }
    }
}
