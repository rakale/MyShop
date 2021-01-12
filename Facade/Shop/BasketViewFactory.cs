using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Common;

namespace Abc.Facade.Shop {
    public sealed class BasketViewFactory : AbstractViewFactory<BasketData, Basket, BasketView> {
        protected internal override Basket toObject(BasketData d) => new Basket(d);
        public override BasketView Create(Basket o) {
            var v = base.Create(o);
            v.BuyerName = o?.Buyer?.Name;
            v.BuyerAddress = o?.Buyer?.Address;
            v.Closed = o?.Data?.To != null;
            v.TotalPrice = o?.TotalPrice ?? decimal.Zero;
            return v;
        }
    }
}
