using System.Threading.Tasks;
using Domain.Common;

namespace WebUI.Shared.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
