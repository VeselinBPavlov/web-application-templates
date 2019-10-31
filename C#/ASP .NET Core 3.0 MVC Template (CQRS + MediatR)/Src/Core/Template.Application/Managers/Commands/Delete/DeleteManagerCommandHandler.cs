namespace Template.Application.Managers.Commands.Delete
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Common.Exceptions;
    using Common.Interfaces;

    public class DeleteManagerCommandHandler : IRequestHandler<DeleteManagerCommand>
    {
        private const string Entity = "Manager";

        private readonly IApplicationDbContext context;

        public DeleteManagerCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteManagerCommand request, CancellationToken cancellationToken)
        {
            var Manager = await this.context.Managers
                .FindAsync(request.Id);

            if (Manager == null || Manager.IsDeleted == true)
            {
                throw new NotFoundException(Entity, request.Id);
            }

            Manager.DeletedOn = DateTime.UtcNow;
            Manager.IsDeleted = true;

            this.context.Managers.Update(Manager);
            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
