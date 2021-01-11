using Abc.Aids.Extensions;
using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Infra.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Abc.Infra.Shop {
    public sealed class BasketItemsRepository :
        PaginatedRepository<BasketItem, BasketItemData>, IBasketItemsRepository {
        public BasketItemsRepository(ShopDbContext c) : base(c, c.BasketItems) { }

        protected override async Task<BasketItemData> getData(string id) {
            var basketId = id?.GetHead();
            var productId = id?.GetTail();
            return await dbSet.FirstOrDefaultAsync(
                m=>m.BasketId == basketId &&
                m.ProductId == productId);
        }

        protected override BasketItemData getDataById(BasketItemData d) =>
            dbSet.Find(d?.BasketId, d?.ProductId);

        protected internal override BasketItem toDomainObject(BasketItemData d) => new BasketItem(d);
    }
}
