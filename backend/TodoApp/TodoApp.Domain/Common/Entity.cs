using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Domain.Common
{
    public abstract class Entity<TId>
    {
        public virtual TId Id { get; protected set; } = default!;
    }
    public abstract class AuditableEntity<TId> : Entity<TId>
    {
        public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
        public string CreatedBy { get; protected set; } = default!;

        public DateTime? UpdatedAt { get; protected set; }
        public string? UpdatedBy { get; protected set; }

        protected AuditableEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public void SetCreated(string userId)
        {
            CreatedAt = DateTime.UtcNow;
            CreatedBy = userId;
        }

        public void SetUpdated(string userId)
        {
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = userId;
        }
    }
    public abstract class AggregateRoot<TId> : AuditableEntity<TId>
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        protected void AddDomainEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
