using Abc.Aids.Methods;
using Abc.Data.Common;
using Abc.Domain.Common;

namespace Abc.Facade.Common {
    public abstract class AbstractViewFactory<TData, TObject, TView>
        where TData : PeriodData, new()
        where TView : PeriodView, new()
        where TObject : IEntity<TData> {

        public TObject Create(TView v) {
            var d = new TData();
            Copy.Members(v, d);
            return toObject(d);
        }

        internal protected abstract TObject toObject(TData d);

        public TView Create(TObject o) {
            var v = new TView();
            Copy.Members(o.Data, v);
            return v;
        }
    }
}
