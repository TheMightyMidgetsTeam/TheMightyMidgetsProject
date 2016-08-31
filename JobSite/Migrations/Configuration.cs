namespace JobSite.Migrations
{
    using JobSite.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                // If the database is empty, populate sample data in it
                CreateUser(context, "admin@gmail.com", "123", "System Administrator");
                CreateUser(context, "pesho@gmail.com", "123", "Peter Ivanov");
                CreateUser(context, "merry@gmail.com", "123", "Maria Petrova");
                CreateUser(context, "geshu@gmail.com", "123", "George Petrov");
                CreateRole(context, "Administrators");
                AddUserToRole(context, "admin@gmail.com", "Administrators");
                context.SaveChanges();
            }
            if (!context.Cities.Any())
            {
                CreateCity(context, "София");
                CreateCity(context, "Пловдив");
                CreateCity(context, "Варна");
                CreateCity(context, "Русе");
                CreateCity(context, "Бургас");
                CreateCity(context, "Велико Търново");
                CreateCity(context, "Добрич");
                CreateCity(context, "Плевен");
                CreateCity(context, "Стара Загора");
                CreateCity(context, "Сливен");
                CreateCity(context, "Шумен");
                CreateCity(context, "Перник");
                context.SaveChanges();
            }
            if (!context.Categories.Any())
            {
                CreateCategory(context, "Медии");
                CreateCategory(context, "Логистика, Спедиция");
                CreateCategory(context, "Контакт центрове (Call Centers)");
                CreateCategory(context, "Институции/Държавна администрация");
                CreateCategory(context, "Инженери");
                CreateCategory(context, "Изкуство, Развлечение, Промоции");
                CreateCategory(context, "ИТ - Разработка/поддръжка на хардуер");
                CreateCategory(context, "ИТ - Разработка/поддръжка на софтуер");
                CreateCategory(context, "ИТ - Административни дейности и продажби");
                CreateCategory(context, "Здравеопазване и фармация");
                CreateCategory(context, "Застраховане");
                CreateCategory(context, "Енергетика и Ютилитис (Ток/Вода/Парно/Газ)");
                CreateCategory(context, "Дизайн, Криейтив, Видео и Анимация");
                CreateCategory(context, "Бизнес/Консултантски услуги");
                CreateCategory(context, "Банки/Кредитиране");
                CreateCategory(context, "Административни и офис дейности");
                CreateCategory(context, "Автомобили, Автосервизи, Бензиностанции");
                CreateCategory(context, "Авиация, Летища и Авиолинии");
                context.SaveChanges();
            }
        }

        private void CreateUser(ApplicationDbContext context,
            string email, string password, string fullName)
        {
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FullName = fullName
            };

            var userCreateResult = userManager.Create(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }
        }

        private void CreateRole(ApplicationDbContext context, string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(roleName));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }
        }

        private void AddUserToRole(ApplicationDbContext context, string userName, string roleName)
        {
            var user = context.Users.First(u => u.UserName == userName);
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var addAdminRoleResult = userManager.AddToRole(user.Id, roleName);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }

        private void CreateCity(ApplicationDbContext context,
            string name)
        {
            var city = new City();
            city.CityName = name;
            context.Cities.Add(city);
        }
        private void CreateCategory(ApplicationDbContext context,
    string name)
        {
            var category = new Category();
            category.CategoryName = name.ToString();
           // context.Categories.Add()
            context.Categories.Add(category);
        }
    }
}
