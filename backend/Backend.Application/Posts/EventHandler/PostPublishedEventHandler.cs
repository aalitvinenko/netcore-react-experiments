using Backend.Application.Common.Models;
using Backend.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Posts.EventHandler
{
    public class PostPublishedEventHandler : INotificationHandler<DomainEventNotification<PostPublishedEvent>>
    {
        private readonly ILogger<PostPublishedEventHandler> _logger;

        public PostPublishedEventHandler(ILogger<PostPublishedEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(DomainEventNotification<PostPublishedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            if (domainEvent.Post != null)
            {
            }
        }
    }
}