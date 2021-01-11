using Abc.Data.Shop;
using Abc.Domain.Common;

namespace Abc.Domain.Shop {
    public sealed class BasketItem : Entity<BasketItemData> {
        public BasketItem(BasketItemData d) : base(d) { }
        //TODO public decimal UnitPrice => Data?.UnitPrice ?? UnspecifiedDecimal;
        public int Quantity => Data?.Quantity ?? UnspecifiedInteger;
        public string ProductId => Data?.ProductId ?? Unspecified;
        public string BasketId => Data?.BasketId ?? Unspecified;
    }


}
