namespace Template.Application.Common.Interfaces
{    
    using System.Threading.Tasks;
    using System.Threading;
    
    using Microsoft.EntityFrameworkCore;

    using Domain.Entities;

    public interface ITemplateDbContext
    {
         DbSet<Manager> Managers { get; set; }

        DbSet<TemplateUser> TemplateUsers { get; set; }

        DbSet<TemplateRole> TemplateRoles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}