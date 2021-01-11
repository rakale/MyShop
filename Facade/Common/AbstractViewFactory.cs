using Abc.Aids.Methods;
using Abc.Data.Common;
using Abc.Domain.Common;

namespace Abc.Facade.Common {
    public abstract class AbstractViewFactory<TData, TObject, TView>
        where TData : PeriodData, new()
        where TView : PeriodView, new()
        where TObject : IEntity<TData> {

        public virtual TObject Create(TView v) {
            var d = new TData();
            copyMembers(v, d);
            return toObject(d);
        }

        internal protected abstract TObject toObject(TData d);

        internal protected virtual void copyMembers(TView v, TData d) => Copy.Members(v, d);
        internal protected virtual void copyMembers(TData d, TView v) => Copy.Members(d, v);

        public virtual TView Create(TObject o) {
            var v = new TView();
            copyMembers(o.Data, v);
            return v;
        }
    }
}
