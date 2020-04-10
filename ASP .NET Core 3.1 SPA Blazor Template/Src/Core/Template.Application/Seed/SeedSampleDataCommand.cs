namespace Template.Application.Seed
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Common.Interfaces;

    public class SeedSampleDataCommand : IRequest
    {
    }

    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly ITemplateDbContext context;

        public SeedSampleDataCommandHandler(ITemplateDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SampleDataSeeder(context);

            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
