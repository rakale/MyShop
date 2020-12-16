using Abc.Data.Shop;
using Abc.Domain.Common;

namespace Abc.Domain.Shop {
    public sealed class OrderItem : UniqueEntity<OrderItemData> {
        public OrderItem(OrderItemData d) : base(d) { }

        public string CatalogItemId => Data?.CatalogItemId ?? Unspecified;
        public string ProductName => Data?.ProductName ?? Unspecified;
        public string PictureUri => Data?.PictureUri ?? Unspecified;
        public decimal UnitPrice => Data?.UnitPrice ?? UnspecifiedDecimal;
        public int Units => Data?.Units ?? UnspecifiedInteger;
        public string OrderId => Data?.OrderId ?? Unspecified;
    }


}
