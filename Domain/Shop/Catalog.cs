using Abc.Data.Shop;
using Abc.Domain.Common;

namespace Abc.Domain.Shop {
    public sealed class Catalog : NamedEntity<CatalogData> {
        public Catalog(CatalogData d) : base(d) { }
    }


}
