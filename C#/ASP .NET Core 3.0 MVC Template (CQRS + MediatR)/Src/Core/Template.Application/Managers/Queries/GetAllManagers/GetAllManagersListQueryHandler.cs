namespace Template.Application.Managers.Queries.GetAllManagers
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    using Common.Interfaces;

    public class GetAllManagersListQueryHandler : IRequestHandler<GetAllManagersListQuery, ManagersListViewModel>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetAllManagersListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ManagersListViewModel> Handle(GetAllManagersListQuery request, CancellationToken cancellationToken)
        {
            return new ManagersListViewModel
            {
                Managers = await this.context.Managers.Where(c => c.IsDeleted != true).ProjectTo<ManagerAllViewModel>(this.mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}