namespace WebFormsChat.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebFormsChat.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ChatDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ChatDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var userManager = new UserManager<User>(new UserStore<User>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            
            roleManager.Create(new IdentityRole("admin"));
            roleManager.Create(new IdentityRole("moderator"));

            var userAdmin = new User
            {
                UserName = "a@a.a",
                FirstName = "Pesho",
                LastName = "Goshov",
                Email = "a@a.a"
            };
            var userMod = new User
            {
                UserName = "m@m.m",
                FirstName = "Stamat",
                LastName = "Peshov",
                Email = "m@m.m"
            };

            var resultAdmin = userManager.Create(userAdmin, "123456");
            var resultMod = userManager.Create(userMod, "123456");
            if (resultAdmin.Succeeded && resultMod.Succeeded)
            {
                userManager.AddToRole(userAdmin.Id, "admin");
                userManager.AddToRole(userMod.Id, "moderator");
            }
        }
    }
}
