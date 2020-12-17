using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Common;

namespace Abc.Facade.Shop {
    public sealed class BasketItemViewFactory : AbstractViewFactory<BasketItemData, BasketItem, BasketItemView> {
        protected internal override BasketItem toObject(BasketItemData d) => new BasketItem(d);
    }
}
