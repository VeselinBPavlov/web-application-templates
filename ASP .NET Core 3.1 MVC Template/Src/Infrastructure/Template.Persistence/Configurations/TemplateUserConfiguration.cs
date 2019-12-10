namespace Template.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TemplateUserConfiguration : IEntityTypeConfiguration<TemplateUser>
    {
        public void Configure(EntityTypeBuilder<TemplateUser> builder)
        {
            builder.HasMany(e => e.Claims)
                   .WithOne()
                   .HasForeignKey(e => e.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Logins)
                   .WithOne()
                   .HasForeignKey(e => e.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Roles)
                   .WithOne()
                   .HasForeignKey(e => e.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
