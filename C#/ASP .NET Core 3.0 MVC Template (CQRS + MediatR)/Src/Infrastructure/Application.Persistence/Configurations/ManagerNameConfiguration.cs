namespace Application.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Domain.ValueObjects;

    public class ManagerNameConfiguration : IEntityTypeConfiguration<ManagerName>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ManagerName> builder)
        {
            builder.Property(m => m.FirstName)
                   .HasMaxLength(50)
                   .IsUnicode()
                   .IsRequired();

            builder.Property(m => m.LastName)
                   .HasMaxLength(50)
                   .IsUnicode()
                   .IsRequired();
        }
    }
}