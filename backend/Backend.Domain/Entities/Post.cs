using Backend.Domain.Common;
using Backend.Domain.Event;
using System.Collections.Generic;

namespace Backend.Domain.Entities
{
    public class Post : AuditableEntity, IHasDomainEvent
    {
        public Post()
        {
            DomainEvents = new List<DomainEvent>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        private bool _published;

        public bool Published
        {
            get => _published;
            set
            {
                if (value && !_published)
                {
                    DomainEvents.Add(new PostPublishedEvent(this));
                }

                _published = value;
            }
        }

        public List<DomainEvent> DomainEvents { get; set; }
    }
}