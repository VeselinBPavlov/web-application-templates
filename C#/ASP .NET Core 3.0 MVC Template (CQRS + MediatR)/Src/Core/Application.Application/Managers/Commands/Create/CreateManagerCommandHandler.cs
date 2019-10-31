namespace Application.Application.Managers.Commands.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Domain.Entities;
    using Domain.Enumerations;
    using Domain.ValueObjects;
    using global::Application.Application.Common.Interfaces;

    public class CreateManagerCommandHandler : IRequestHandler<CreateManagerCommand, Unit>
    {
        private readonly IApplicationDbContext context;
        private readonly IMediator mediator;

        public CreateManagerCommandHandler(IApplicationDbContext context, IMediator mediator)
        {
            this.context = context;
            this.mediator = mediator;
        }

        public async Task<Unit> Handle(CreateManagerCommand request, CancellationToken cancellationToken)
        {
            var managerName = ManagerName.For($"{request.ManagerFirstName} {request.ManagerLastName}");

            var manager = new Manager
            {                
                ManagerName = managerName,
                ReceptionDay = Enum.Parse<WeekDay>(request.ReceptionDay),
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false
            };

            this.context.Managers.Add(manager);

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
