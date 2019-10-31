namespace Template.Application.Managers.Queries.GetAllManagers
{
    using AutoMapper;

    using Domain.Entities;
    using Interfaces.Mapping;

    public class ManagerAllViewModel : IHaveCustomMapping
    {
         public int Id { get; set; }

        public string CompanyName { get; set; }

        public string VatNumber { get; set; }

        public string ManagerNames { get; set; }

        public string Phone { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Manager, ManagerAllViewModel>();
        }
    }
}