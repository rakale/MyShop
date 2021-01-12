using Abc.Data.Shop;
using Abc.Domain.Shop.Model;
using Abc.Facade.Common;
using Abc.Facade.Shop.Views;

namespace Abc.Facade.Shop.Factories {
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
