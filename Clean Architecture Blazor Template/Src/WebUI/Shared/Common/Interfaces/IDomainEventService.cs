using System.Threading.Tasks;
using Template.Domain.Common;

namespace Template.WebUI.Shared.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
