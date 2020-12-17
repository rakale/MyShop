using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Common;

namespace Abc.Facade.Shop {
    public sealed class OrderItemViewFactory : AbstractViewFactory<OrderItemData, OrderItem, OrderItemView> {
        protected internal override OrderItem toObject(OrderItemData d) => new OrderItem(d);
    }
}
