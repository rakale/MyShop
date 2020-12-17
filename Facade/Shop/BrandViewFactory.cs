using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Common;

namespace Abc.Facade.Shop {
    public sealed class BrandViewFactory : AbstractViewFactory<BrandData, Brand, BrandView> {
        protected internal override Brand toObject(BrandData d) => new Brand(d);
    }
}
