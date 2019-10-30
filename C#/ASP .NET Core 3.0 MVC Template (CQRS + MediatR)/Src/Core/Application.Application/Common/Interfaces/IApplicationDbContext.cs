namespace Application.Application.Common.Interfaces
{    
    using System.Threading.Tasks;
    using System.Threading;
    
    using Microsoft.EntityFrameworkCore;

    using Domain.Entities;

    public interface IApplicationDbContext
    {
         DbSet<Manager> Managers { get; set; }

         Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}