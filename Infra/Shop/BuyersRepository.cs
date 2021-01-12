using Abc.Data.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Infra.Common;


namespace Abc.Infra.Shop {
    public sealed class BuyersRepository :
        UniqueEntityRepository<Buyer, BuyerData>, IBuyersRepository {
        public BuyersRepository(ShopDbContext c) : base(c, c.Buyers) { }
        protected internal override Buyer toDomainObject(BuyerData d) => new Buyer(d);
    }
}
