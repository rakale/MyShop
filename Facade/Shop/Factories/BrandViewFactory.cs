using Abc.Data.Shop;
using Abc.Domain.Shop.Model;
using Abc.Facade.Common;
using Abc.Facade.Shop.Views;

namespace Abc.Facade.Shop.Factories {
    public sealed class BrandViewFactory : AbstractViewFactory<BrandData, Brand, BrandView> {
        protected internal override Brand toObject(BrandData d) => new Brand(d);
    }
}
