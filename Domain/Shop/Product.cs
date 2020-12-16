using Abc.Data.Shop;
using Abc.Domain.Common;

namespace Abc.Domain.Shop {
    public sealed class Product : NamedEntity<ProductData> {
        public Product(ProductData d) : base(d) { }

        public string Description => Data?.Description ?? Unspecified;
        public decimal Price => Data?.Price ?? UnspecifiedDecimal;
        public string PictureUri => Data?.PictureUri ?? Unspecified;
        public string CatalogTypeId => Data?.CatalogTypeId ?? Unspecified;
        public string CatalogBrandId => Data?.CatalogBrandId ?? Unspecified;
    }


}
