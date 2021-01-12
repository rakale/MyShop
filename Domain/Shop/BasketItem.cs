using Abc.Data.Shop;

namespace Abc.Domain.Shop {
    public sealed class BasketItem : ItemProduct<BasketItemData> {
        public BasketItem(BasketItemData d) : base(d) { }
        public string BasketId => Data?.BasketId ?? Unspecified;        
    }


}
