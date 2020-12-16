using System.Collections.Generic;
using Abc.Aids.Methods;

namespace Abc.Domain.Common {

    public sealed class GetFrom<TRepository, TObject>
        where TRepository : IRepository<TObject> {

        internal TRepository repository
            => GetRepository.Instance<TRepository>();

        public TObject ById(string id) 
            => Safe.Run(() => repository.Get(id).GetAwaiter().GetResult(), default(TObject));
        
        public IReadOnlyList<TObject> ListBy(string field, string value) {
            var r = repository;

            return list(r, field, value);
        }

        public IReadOnlyList<TObject> ListBy(string field, string value, string searchString) {
            var r = repository;
            r.SearchString = searchString;

            return list(r, field, value);
        }

        private static IReadOnlyList<TObject> list(TRepository r, string field, string value) {
            r.FixedFilter = field;
            r.FixedValue = value;
            r.PageIndex = -1;

            return r.Get().GetAwaiter().GetResult();
        }

    }

}