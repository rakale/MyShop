using Abc.Data.Shop;
using Abc.Domain.Common;

namespace Abc.Domain.Shop {
    public sealed class BasketItem : UniqueEntity<BasketItemData> {
        public BasketItem(BasketItemData d) : base(d) { }
        public decimal UnitPrice => Data?.UnitPrice ?? UnspecifiedDecimal;
        public int Quantity => Data?.Quantity ?? UnspecifiedInteger;
        public string CatalogItemId => Data?.CatalogItemId ?? Unspecified;
        public string BasketId => Data?.BasketId ?? Unspecified;
    }


}
