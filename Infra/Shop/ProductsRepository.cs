﻿using Abc.Data.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Infra.Common;

namespace Abc.Infra.Shop {
    public sealed class ProductsRepository :
        UniqueEntityRepository<Product, ProductData>, IProductsRepository {
        public ProductsRepository(ShopDbContext c) : base(c, c.Products) { }
        protected internal override Product toDomainObject(ProductData d)
            => new Product(d);
    }
}
