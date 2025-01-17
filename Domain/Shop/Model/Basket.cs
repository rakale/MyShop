﻿using Abc.Aids.Reflection;
using Abc.Data.Shop;
using Abc.Domain.Common;
using Abc.Domain.Shop.Repositories;
using System.Collections.Generic;

namespace Abc.Domain.Shop.Model {
    public sealed class Basket : BuyerProducts<BasketData> {
        private readonly string basketId = GetMember.Name<BasketItemData>(x => x.BasketId);
        public Basket(BasketData d) : base(d) { }

        public IReadOnlyList<BasketItem> Items =>
            new GetFrom<IBasketItemsRepository, BasketItem>().ListBy(basketId, Id);
        public decimal TotalPrice {
            get {
                var sum = decimal.Zero;
                foreach (var i in Items) sum += i.TotalPrice;
                return sum;
            }
        }
    }
}
