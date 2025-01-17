﻿using Abc.Aids.Methods;
using Abc.Data.Shop;

namespace Abc.Domain.Shop.Model {
    public sealed class BasketItem : ItemProduct<BasketItemData> {
        public BasketItem(BasketItemData d) : base(d) { }
        public string BasketId => Data?.BasketId ?? Unspecified;
        public string Id => Compose.Id(BasketId, ProductId);
    }


}
