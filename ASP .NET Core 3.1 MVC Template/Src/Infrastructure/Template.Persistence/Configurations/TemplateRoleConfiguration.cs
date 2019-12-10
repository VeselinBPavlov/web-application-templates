namespace Template.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TemplateRoleConfiguration : IEntityTypeConfiguration<TemplateRole>
    {
        public void Configure(EntityTypeBuilder<TemplateRole> builder)
        {
            
        }
    }
}
