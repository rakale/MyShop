using Abc.Aids.Reflection;
using Abc.Data.Shop;
using Abc.Domain.Common;
using System.Collections.Generic;

namespace Abc.Domain.Shop {
    public sealed class Basket : BuyerProducts<BasketData> {
        private readonly string basketId = GetMember.Name<BasketItemData>(x => x.BasketId);
        public Basket(BasketData d) : base(d) { }
        
        public IReadOnlyList<BasketItem> Items =>
            new GetFrom<IBasketItemsRepository, BasketItem>().ListBy(basketId, Id);

    }


}
