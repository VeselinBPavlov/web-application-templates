namespace Template.Persistence
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Migrations;
    
    using Domain.Entities;
    using Common;
    using Application.Common.Interfaces;

    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        public DbSet<Manager> Managers { get; set; }

        public DbSet<TemplateUser> TemplateUsers { get; set; }

        public DbSet<TemplateRole> TemplateRoles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ReplaceService<IMigrationsSqlGenerator, CustomSqlServerMigrationsSqlGenerator>();
        }        
    }    
}