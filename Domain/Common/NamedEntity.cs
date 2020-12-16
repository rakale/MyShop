using Abc.Data.Common;

namespace Abc.Domain.Common {

    public abstract class NamedEntity<T> : UniqueEntity<T> where T : NamedEntityData, new() {

        protected internal NamedEntity(T d = null) : base(d) { }

        public virtual string Name => Data?.Name ?? Unspecified;
        public virtual string Code => Data?.Code ?? Unspecified;

    }

}

