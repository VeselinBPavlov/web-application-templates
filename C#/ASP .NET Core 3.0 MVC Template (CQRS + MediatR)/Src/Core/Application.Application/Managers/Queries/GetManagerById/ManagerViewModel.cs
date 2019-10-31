namespace Application.Application.Managers.Queries.GetManagerById
{
    using System;
    using System.Linq.Expressions;
    using global::Application.Domain.Entities;

    public class ManagerViewModel
    {
        public string Id { get; set; }

        public string ManagerFirstName { get; set; }

        public string ManagerLastName { get; set; }

        public string ReceptionDay { get; set; }

        public static Expression<Func<Manager, ManagerViewModel>> Projection
        {
            get
            {
                return manager => new ManagerViewModel
                {
                    Id = manager.Id,
                    ManagerFirstName = manager.ManagerName.FirstName,
                    ManagerLastName = manager.ManagerName.LastName,
                    ReceptionDay = manager.ReceptionDay.ToString()
                };
            }
        }

        public static ManagerViewModel Create(Manager manager)
        {
            return Projection.Compile().Invoke(manager);
        }
    }
}