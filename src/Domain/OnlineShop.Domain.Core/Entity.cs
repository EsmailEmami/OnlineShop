﻿namespace OnlineShop.Domain.Core
{
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
        public virtual DateTime CreateDate => DateTime.Now;
        public virtual bool Deleted { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity<TPrimaryKey> other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetHashCode() != other.GetHashCode())
                return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<TPrimaryKey>? first, Entity<TPrimaryKey>? second)
        {
            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return true;

            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
                return false;

            return first.Equals(second);
        }
        public static bool operator !=(Entity<TPrimaryKey>? first, Entity<TPrimaryKey>? second) => !(first == second);
        public override int GetHashCode() => GetType().GetHashCode() * 365 + Id.GetHashCode();
    }

    public abstract class Entity : Entity<Guid>, IEntity<Guid>
    {
    }
}