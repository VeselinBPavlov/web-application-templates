namespace Template.Persistence
{
    using System;
    using System.Linq;

    using Domain.Entities;
    using Domain.Enumerations;

    public class ApplicationInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            var initializer = new ApplicationInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Managers.Any())
            {
                return; // Db has been seeded
            }

            SeedManagers(context);

            SeedRoles(context);
        }

        private void SeedManagers(ApplicationDbContext context)
        {
            var managers = new[]
            {
                new Manager { Id = Guid.NewGuid().ToString(), FirstName = "Ivan", LastName = "Ivanov", ReceptionDay = WeekDay.Monday, CreatedOn = DateTime.UtcNow },
                new Manager { Id = Guid.NewGuid().ToString(), FirstName = "Petar", LastName = "Petrov", ReceptionDay = WeekDay.Monday, CreatedOn = DateTime.UtcNow },
                new Manager { Id = Guid.NewGuid().ToString(), FirstName = "Sasho", LastName = "Trifonov", ReceptionDay = WeekDay.Monday, CreatedOn = DateTime.UtcNow },
                new Manager { Id = Guid.NewGuid().ToString(), FirstName = "Lambi", LastName = "Kostov", ReceptionDay = WeekDay.Monday, CreatedOn = DateTime.UtcNow },
                new Manager { Id = Guid.NewGuid().ToString(), FirstName = "Simeon", LastName = "Atanasov", ReceptionDay = WeekDay.Monday, CreatedOn = DateTime.UtcNow }
            };

            context.Managers.AddRange(managers);
            context.SaveChanges();
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            var roles = new[]
            {
                new TemplateRole { Id = Guid.NewGuid().ToString(), Name = "Administrator", NormalizedName = "ADMINISTRATOR", CreatedOn = DateTime.UtcNow, IsDeleted = false },
                new TemplateRole { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER", CreatedOn = DateTime.UtcNow, IsDeleted = false },
            };

            context.TemplateRoles.AddRange(roles);
            context.SaveChanges();
        }
    }
}