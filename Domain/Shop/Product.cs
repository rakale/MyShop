using Abc.Data.Shop;
using Abc.Domain.Common;
using System.Collections.Generic;

namespace Abc.Domain.Shop {
    public sealed class Product : NamedEntity<ProductData> {
        public Product(ProductData d) : base(d) { }

        public string Description => Data?.Description ?? Unspecified;
        public decimal Price => Data?.Price ?? UnspecifiedDecimal;
        public string PictureUri => Data?.PictureUri ?? Unspecified;
        public byte[] Picture => Data?.Picture ?? new List<byte>().ToArray();
        public string CatalogTypeId => Data?.CatalogTypeId ?? Unspecified;
        public string CatalogBrandId => Data?.CatalogBrandId ?? Unspecified;
    }


}
