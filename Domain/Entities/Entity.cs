using System;

namespace Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        protected Entity()
        {

        }
        public Entity(Guid Id)
        {
            this.Id = Id;
        }
    }
}
