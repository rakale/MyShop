﻿using Abc.Aids.Extensions;
using Abc.Data.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Infra.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Abc.Infra.Shop {
    public sealed class BasketItemsRepository :
        PaginatedRepository<BasketItem, BasketItemData>, IBasketItemsRepository {
        public BasketItemsRepository(ShopDbContext c) : base(c, c.BasketItems) { }

        public async Task<BasketItem> Add(Basket b, Product p) {
            BasketItemData d = new BasketItemData {
                BasketId = b.Id,
                ProductId = p.Id,
                Quantity = 1
            };
            var o = toDomainObject(d);
            await Add(o);
            return o;
        }

        protected override async Task<BasketItemData> getData(string id) {
            var basketId = id?.GetHead();
            var productId = id?.GetTail();
            return await dbSet.FirstOrDefaultAsync(
                m => m.BasketId == basketId &&
                m.ProductId == productId);
        }

        protected override BasketItemData getDataById(BasketItemData d) =>
            dbSet.Find(d?.BasketId, d?.ProductId);

        protected internal override BasketItem toDomainObject(BasketItemData d) => new BasketItem(d);
    }
}
