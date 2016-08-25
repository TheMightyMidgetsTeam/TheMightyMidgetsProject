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
            //    CreateUser(context, "pesho@gmail.com", "123", "Peter Ivanov");
            //    CreateUser(context, "merry@gmail.com", "123", "Maria Petrova");
            //    CreateUser(context, "geshu@gmail.com", "123", "George Petrov");

            //    CreateRole(context, "Administrators");
            //    AddUserToRole(context, "admin@gmail.com", "Administrators");

            //    CreatePost(context,
            //        title: "Work Begins on HTML5.1",
        }
    }
}
