using System;
using Abc.Data.Common;

namespace Abc.Domain.Common {

    public abstract class Entity<TData> : ValueObject<TData>, IEntity<TData> where TData : PeriodData, new() {


        protected internal Entity(TData d = null): base(d) { }
        
        public virtual DateTime ValidFrom => Data?.From ?? UnspecifiedValidFrom;

        public virtual DateTime ValidTo => Data?.To ?? UnspecifiedValidTo;
    }

}
