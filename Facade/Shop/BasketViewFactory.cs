using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Common;

namespace Abc.Facade.Shop {
    public sealed class BasketViewFactory : AbstractViewFactory<BasketData, Basket, BasketView> {
        protected internal override Basket toObject(BasketData d) => new Basket(d);
    }
}
