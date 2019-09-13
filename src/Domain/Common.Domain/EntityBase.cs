using System;

namespace Common.Domain
{
    public abstract class EntityBase
    {
        public virtual Guid Id { get; protected internal set; }
        public bool IsTransient() => Id == Guid.Empty;

        public void GenerateNewIdentity()
        {
            if (IsTransient())
                //https://github.com/stackify/stackify-api-dotnet/blob/master/Src/StackifyLib/Utils/SequentialGuid.cs
                Id = Guid.NewGuid(); // SequentialGuid.NewGuid();
        }

        public void ChangeCurrentIdentity(Guid id)
        {
            if (id != Guid.Empty)
                Id = id;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is EntityBase other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (GetType() != other.GetType())
                return false;
            if (other.IsTransient() || IsTransient())
                return false;
            return Id == other.Id;
        }

        public static bool operator ==(EntityBase left, EntityBase right)
        {
            if (left is null && right is null)
                return true;
            if (left is null || right is null)
                return false;
            return left.Equals(right);
        }

        public static bool operator !=(EntityBase left, EntityBase right) => !(left == right);

        public override int GetHashCode() => (GetType().ToString() + Id).GetHashCode();
        /// <summary>
        /// 0 = New,
        /// 1 = Authorized,
        /// 9 = Deleted
        /// </summary>
        public int Status { get; set; } = 0;
    }
}
