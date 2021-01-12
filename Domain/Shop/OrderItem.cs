using Abc.Data.Shop;

namespace Abc.Domain.Shop {
    public sealed class OrderItem : ItemProduct<OrderItemData> {
        public OrderItem(OrderItemData d) : base(d) { }
        public string OrderId => Data?.OrderId ?? Unspecified;
    }


}
