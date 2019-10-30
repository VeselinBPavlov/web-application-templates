namespace Application.Persistence
{
    using System.Linq;

    using Domain.Entities;
    using Domain.Enumerations;
    using Domain.ValueObjects;

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

            if (context.Roles.Any())
            {
                return; // Db has been seeded
            }

            SeedManagers(context);
        }

        private void SeedManagers(ApplicationDbContext context)
        {
            var manager = new Manager { ManagerName = (ManagerName)"Ivan Ivanov", ReceptionDay = WeekDay.Monday };

            context.Managers.Add(manager);
            context.SaveChanges();
        }
    }
}