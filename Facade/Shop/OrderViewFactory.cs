using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Common;

namespace Abc.Facade.Shop {
    public sealed class OrderViewFactory : AbstractViewFactory<OrderData, Order, OrderView> {
        protected internal override Order toObject(OrderData d) => new Order(d);
        public override OrderView Create(Order o) {
            var v = base.Create(o);
            v.BuyerName = o.Buyer.Name;
            v.BuyerAddress = o.Buyer.Address;
            v.TotalPrice = o.TotalPrice;
            v.Closed = o?.Data?.To != null;
            return v;
        }
    }
}
