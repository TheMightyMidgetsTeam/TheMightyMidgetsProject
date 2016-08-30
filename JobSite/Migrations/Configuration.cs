namespace JobSite.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "JobSite.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //if (!context.Users.Any())
            //{
            //    // If the database is empty, populate sample data in it
            //    ApplicationUserManager qq = new ApplicationUserManager();

            //    CreateUser(context, "admin@gmail.com", "123", "System Administrator");
            //    CreateUser(context, "dancho@gmail.com", "123", "Dancho Ivanov");
            //    CreateUser(context, "vasil@gmail.com", "123", "Vasil Nikolov");
            //    CreateUser(context, "petyo@gmail.com", "123", "Petyo Lazarov");
            //    CreateUser(context, "anjela@gmail.com", "123", "Anjela Aleksandrova");

            //    CreateRole(context, "Administrators");
            //    CreateRole(context, "Employers");
            //    CreateRole(context, "Users");
            //    AddUserToRole(context, "admin@gmail.com", "Administrators");
            //    AddUserToRole(context, "dancho@gmail.com", "Administrators");
            //    AddUserToRole(context, "vasil@gmail.com", "Administrators");
            //    AddUserToRole(context, "petyo@gmail.com", "Administrators");
            //    AddUserToRole(context, "anjela@gmail.com", "Administrators");

            //    context.SaveChanges();
            //}
        }
        //private void CreateUser(ApplicationDbContext context,
        //    string email, string password, string fullName)
        //{
        //    var userManager = new UserManager<ApplicationUser>(
        //        new UserStore<ApplicationUser>(context));
        //    userManager.PasswordValidator = new PasswordValidator
        //    {
        //        RequiredLength = 1,
        //        RequireNonLetterOrDigit = false,
        //        RequireDigit = false,
        //        RequireLowercase = false,
        //        RequireUppercase = false,
        //    };

        //    var user = new ApplicationUser
        //    {
        //        UserName = email,
        //        Email = email,
        //        FullName = fullName
        //    };

        //    var userCreateResult = userManager.Create(user, password);
        //    if (!userCreateResult.Succeeded)
        //    {
        //        throw new Exception(string.Join("; ", userCreateResult.Errors));
        //    }
        //}

        //private void CreateRole(ApplicationDbContext context, string roleName)
        //{
        //    var roleManager = new RoleManager<IdentityRole>(
        //        new RoleStore<IdentityRole>(context));
        //    var roleCreateResult = roleManager.Create(new IdentityRole(roleName));
        //    if (!roleCreateResult.Succeeded)
        //    {
        //        throw new Exception(string.Join("; ", roleCreateResult.Errors));
        //    }
        //}

        //private void AddUserToRole(ApplicationDbContext context, string userName, string roleName)
        //{
        //    var user = context.Users.First(u => u.UserName == userName);
        //    var userManager = new UserManager<ApplicationUser>(
        //        new UserStore<ApplicationUser>(context));
        //    var addAdminRoleResult = userManager.AddToRole(user.Id, roleName);
        //    if (!addAdminRoleResult.Succeeded)
        //    {
        //        throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
        //    }
        //}

    }
}
