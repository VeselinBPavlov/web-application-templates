namespace Template.Persistence
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Migrations;
    
    using Domain.Entities;
    using Template.Persistence.Common;
    using Application.Common.Interfaces;

    public class TemplateDbContext : IdentityDbContext, ITemplateDbContext
    {
        public DbSet<Manager> Managers { get; set; }

        public DbSet<TemplateRole> TemplateRoles { get; set; }

        public DbSet<TemplateUser> TempalteUsers { get; set; }

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options)
            : base(options)
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