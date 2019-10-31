namespace Application.Application.Managers.Queries.GetAllManagers
{
    using AutoMapper;
    using global::Application.Application.Interfaces.Mapping;
    using global::Application.Domain.Entities;

    public class ManagerAllViewModel : IHaveCustomMapping
    {
         public int Id { get; set; }

        public string CompanyName { get; set; }

        public string VatNumber { get; set; }

        public string ManagerNames { get; set; }

        public string Phone { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Manager, ManagerAllViewModel>()
                .ForMember(x => x.ManagerNames, y => y.MapFrom(src => src.ManagerName.ToString()));
        }
    }
}