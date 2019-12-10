namespace Template.Application.Managers.Commands.Create
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Common.Interfaces;
    using Domain.Entities;
    using Domain.Enumerations;

    public class CreateManagerCommandHandler : IRequestHandler<CreateManagerCommand, Unit>
    {
        private readonly ITemplateDbContext context;

        public CreateManagerCommandHandler(ITemplateDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(CreateManagerCommand request, CancellationToken cancellationToken)
        {
            var manager = new Manager
            {                
                FirstName = request.FirstName,
                LastName = request.LastName,
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
