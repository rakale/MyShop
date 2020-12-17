using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Common;

namespace Abc.Facade.Shop {
    public sealed class OrderViewFactory : AbstractViewFactory<OrderData, Order, OrderView> {
        protected internal override Order toObject(OrderData d) => new Order(d);
    }
}
