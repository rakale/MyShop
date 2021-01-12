using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Domain.Shop.Model;
using Abc.Facade.Common;
using Abc.Facade.Shop.Views;

namespace Abc.Facade.Shop.Factories {
    public sealed class CatalogViewFactory : AbstractViewFactory<CatalogData, Catalog, CatalogView> {
        protected internal override Catalog toObject(CatalogData d) => new Catalog(d);
    }
}
