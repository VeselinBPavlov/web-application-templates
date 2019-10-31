namespace Application.Application.Managers.Commands.Update
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Microsoft.EntityFrameworkCore;

    using Domain.ValueObjects;
    using global::Application.Application.Common.Exceptions;
    using global::Application.Application.Common.Interfaces;
    using global::Application.Domain.Enumerations;

    public class UpdateManagerCommandHandler : IRequestHandler<UpdateManagerCommand, Unit>
    {
        private const string Entity = "Manager";
        private readonly IApplicationDbContext context;

        public UpdateManagerCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(UpdateManagerCommand request, CancellationToken cancellationToken)
        {
            var manager = await this.context.Managers
                .SingleOrDefaultAsync(m => m.Id == request.Id && m.IsDeleted != true, cancellationToken);

            if (manager == null)
            {
                throw new NotFoundException(Entity, request.Id);
            }

            var managerName = ManagerName.For($"{request.ManagerFirstName} {request.ManagerLastName}");

            manager.ManagerName = managerName;
            manager.ReceptionDay = Enum.Parse<WeekDay>(request.ReceptionDay);
            manager.ModifiedOn = DateTime.UtcNow;

            this.context.Managers.Update(manager);

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
