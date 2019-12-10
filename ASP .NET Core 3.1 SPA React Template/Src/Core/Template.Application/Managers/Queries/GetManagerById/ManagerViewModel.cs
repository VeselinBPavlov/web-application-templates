namespace Template.Application.Managers.Queries.GetManagerById
{
    using System;
    using System.Linq.Expressions;

    using Domain.Entities;

    public class ManagerViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ReceptionDay { get; set; }

        public static Expression<Func<Manager, ManagerViewModel>> Projection
        {
            get
            {
                return manager => new ManagerViewModel
                {
                    Id = manager.Id,
                    FirstName = manager.FirstName,
                    LastName = manager.LastName,
                    ReceptionDay = (int)manager.ReceptionDay
                };
            }
        }

        public static ManagerViewModel Create(Manager manager)
        {
            return Projection.Compile().Invoke(manager);
        }
    }
}