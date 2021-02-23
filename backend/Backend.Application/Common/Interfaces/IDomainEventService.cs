using Backend.Domain.Common;
using System.Threading.Tasks;

namespace Backend.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}