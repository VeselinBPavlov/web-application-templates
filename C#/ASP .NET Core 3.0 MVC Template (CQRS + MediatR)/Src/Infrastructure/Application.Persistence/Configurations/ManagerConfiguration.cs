namespace Application.Persistence.Configurations
{  
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(c => c.Id);

            builder.OwnsOne(c => c.ManagerName); 
        }
    }
}