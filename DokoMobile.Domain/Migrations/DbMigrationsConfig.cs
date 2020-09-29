namespace DokoMobile.Domain.Migrations
{
    using DokoMobile.Domain.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class DbMigrationsConfig : DbMigrationsConfiguration<DokoMobile.Domain.ApplicationDbContext>
    {
        public DbMigrationsConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DokoMobile.Domain.ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                var adminEmail = "adm@adm.com";
                var adminUserName = adminEmail;
                var adminFullName = "Kejdi Doko";
                var adminPassword = "Kejdi@1";
                string adminRole = "Administrator";

                CreateAdminUser(context, adminEmail, adminFullName, adminPassword, adminRole, adminUserName);

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var roleCreateResult = roleManager.Create(new IdentityRole("User"));
                if (!roleCreateResult.Succeeded)
                {
                    throw new Exception(string.Join("; ", roleCreateResult.Errors));
                }
            }

            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category() { CategoryId = 1, CategoryName = "Smartphone" });
                context.Categories.Add(new Category() { CategoryId = 2, CategoryName = "Accessories" });
                context.Categories.Add(new Category() { CategoryId = 3, CategoryName = "Gaming" });
                context.Categories.Add(new Category() { CategoryId = 4, CategoryName = "Services" });
            }
        }

        private void CreateAdminUser(ApplicationDbContext context, string adminEmail, string adminFullName, string adminPassword, string adminRole, string adminUserName)
        {
            var adminUser = new ApplicationUser
            {
                Email = adminEmail,
                FullName = adminFullName,
                UserName = adminUserName,
                RegisteredDay = DateTime.Now
            };

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.PasswordValidator = new PasswordValidator
            {
                RequireDigit = true,
                RequiredLength = 6,
                RequireLowercase = true,
                RequireNonLetterOrDigit = true,
                RequireUppercase = true,
            };

            var userCreateResult = userManager.Create(adminUser, adminPassword);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(adminRole));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }

            var addAdminRoleResult = userManager.AddToRole(adminUser.Id, adminRole);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }

        }
    }
}
