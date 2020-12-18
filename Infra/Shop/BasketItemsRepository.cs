using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Infra.Common;

namespace Abc.Infra.Shop {
    public sealed class BasketItemsRepository :
        UniqueEntityRepository<BasketItem, BasketItemData>, IBasketItemsRepository {
        public BasketItemsRepository(ShopDbContext c) : base(c, c.BasketItems) { }

        protected internal override BasketItem toDomainObject(BasketItemData d) => new BasketItem(d);
    }
}
