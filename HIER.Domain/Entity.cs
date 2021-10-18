using System;

namespace HIER.Domain
{
    //! Base class for classes that will be stored using EF Core.
    //! Always inherit from it for those classes
    public abstract class Entity
    {
        public virtual long Id { get; protected set; }

        protected Entity()
        {
        }

        protected Entity(long id)
        {
            Id = id;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Entity other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (Id.Equals(default) || other.Id.Equals(default))
                return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (ToString() + Id).GetHashCode();
        }
    }
}
