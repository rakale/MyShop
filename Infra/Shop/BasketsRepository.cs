using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Infra.Common;

namespace Abc.Infra.Shop {
    public sealed class BasketsRepository :
        UniqueEntityRepository<Basket, BasketData>, IBasketsRepository {
        public BasketsRepository(ShopDbContext c) : base(c, c.Baskets) { }

        protected internal override Basket toDomainObject(BasketData d) => new Basket(d);
    }
}
