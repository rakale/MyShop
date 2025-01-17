﻿using Abc.Data.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Infra.Common;

namespace Abc.Infra.Shop {
    public sealed class CatalogsRepository :
        UniqueEntityRepository<Catalog, CatalogData>, ICatalogsRepository {
        public CatalogsRepository(ShopDbContext c) : base(c, c.Catalogs) { }

        protected internal override Catalog toDomainObject(CatalogData d) => new Catalog(d);
    }
}
