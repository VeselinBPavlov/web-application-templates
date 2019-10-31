namespace Application.Application.Managers.Queries.GetManagerById
{
    using System.Threading;
    using System.Threading.Tasks;
    using global::Application.Application.Common.Exceptions;
    using global::Application.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetManagerByIdQueryHandler : IRequestHandler<GetManagerByIdQuery, ManagerViewModel>
    {
        private const string Entity = "Manager";
        private readonly IApplicationDbContext context;

        public GetManagerByIdQueryHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ManagerViewModel> Handle(GetManagerByIdQuery request, CancellationToken cancellationToken)
        {
            var manager = await this.context.Managers.Include(c => c.ManagerName).SingleOrDefaultAsync(c => c.Id == request.Id);

            if (manager == null)
            {
                throw new NotFoundException(Entity, request.Id);
            }

            return ManagerViewModel.Create(manager);
        }
    }
}