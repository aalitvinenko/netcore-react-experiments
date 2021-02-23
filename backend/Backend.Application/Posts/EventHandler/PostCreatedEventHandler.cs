using Backend.Application.Common.Models;
using Backend.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Posts.EventHandler
{
    public class PostCreatedEventHandler : INotificationHandler<DomainEventNotification<PostCreatedEvent>>
    {
        private readonly ILogger<PostCreatedEventHandler> _logger;

        public PostCreatedEventHandler(ILogger<PostCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(DomainEventNotification<PostCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            if (domainEvent.Post != null)
            {
            }
        }
    }
}