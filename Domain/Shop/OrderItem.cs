using Abc.Data.Shop;
using Abc.Domain.Common;

namespace Abc.Domain.Shop {
    public sealed class OrderItem : Entity<OrderItemData> {
        public OrderItem(OrderItemData d) : base(d) { }

        public string ProductId => Data?.ProductId ?? Unspecified;
        //TODO public string ProductName => Data?.ProductName ?? Unspecified;
        //TODO public string PictureUri => Data?.PictureUri ?? Unspecified;
        //TODO public decimal UnitPrice => Data?.UnitPrice ?? UnspecifiedDecimal;
        public int Units => Data?.Units ?? UnspecifiedInteger;
        public string OrderId => Data?.OrderId ?? Unspecified;
    }


}
