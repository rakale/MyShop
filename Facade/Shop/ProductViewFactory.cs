using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Common;

namespace Abc.Facade.Shop {
    public sealed class ProductViewFactory : AbstractViewFactory<ProductData, Product, ProductView> {
        protected internal override Product toObject(ProductData d) => new Product(d);
    }
}
