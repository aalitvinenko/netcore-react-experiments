using Backend.Domain.Common;
using Backend.Domain.Entities;

namespace Backend.Domain.Event
{
    public class PostPublishedEvent : DomainEvent
    {
        public PostPublishedEvent(Post post)
        {
            Post = post;
        }

        public Post Post { get; }
    }
}