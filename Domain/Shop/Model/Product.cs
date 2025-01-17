﻿using Abc.Data.Shop;
using Abc.Domain.Common;
using Abc.Domain.Shop.Repositories;
using System.Collections.Generic;

namespace Abc.Domain.Shop.Model {
    public sealed class Product : DefinedEntity<ProductData> {
        public Product(ProductData d) : base(d) { }
        public decimal Price => Data?.Price ?? UnspecifiedDecimal;
        public string PictureUri => Data?.PictureUri ?? Unspecified;
        public byte[] Picture => Data?.Picture ?? new List<byte>().ToArray();
        public string CatalogId => Data?.CatalogId ?? Unspecified;
        public string BrandId => Data?.BrandId ?? Unspecified;
        public Brand Brand => new GetFrom<IBrandsRepository, Brand>().ById(BrandId);
        public Catalog Catalog => new GetFrom<ICatalogsRepository, Catalog>().ById(CatalogId);
        public override string ToString() => $"{Name} ({Brand.Name})";
    }



}
