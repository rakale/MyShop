using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Common;

namespace Abc.Facade.Shop {
    public sealed class CatalogViewFactory : AbstractViewFactory<CatalogData, Catalog, CatalogView> {
        protected internal override Catalog toObject(CatalogData d) => new Catalog(d);
    }
}
