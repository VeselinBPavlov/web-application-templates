namespace Template.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Migrations;

    using Domain.Entities;
    using Application.Common.Interfaces;
    using Template.Persistence.Infrastructure;
    using IdentityServer4.EntityFramework.Options;
    using Microsoft.Extensions.Options;

    public class TemplateDbContext : KeyApiAuthorizationDbContext<TemplateUser, TemplateRole, string>, ITemplateDbContext
    {
        public DbSet<Manager> Managers { get; set; }

        public DbSet<TemplateRole> TemplateRoles { get; set; }

        public DbSet<TemplateUser> TempalteUsers { get; set; }

        public TemplateDbContext(DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(TemplateDbContext).Assembly);            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ReplaceService<IMigrationsSqlGenerator, CustomSqlServerMigrationsSqlGenerator>();
        }        
    }    
}