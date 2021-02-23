using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Domain.Event
{
    public class PostCreatedEvent : DomainEvent
    {
        public PostCreatedEvent(Post post)
        {
            Post = post;
        }

        public Post Post { get; }
    }
}