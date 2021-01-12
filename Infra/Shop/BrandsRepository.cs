using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Infra.Common;

namespace Abc.Infra.Shop {
    public sealed class BrandsRepository :
        UniqueEntityRepository<Brand, BrandData>, IBrandsRepository {
        public BrandsRepository(ShopDbContext c) : base(c, c.Brands) { }

        protected internal override Brand toDomainObject(BrandData d) => new Brand(d);
    }
}
