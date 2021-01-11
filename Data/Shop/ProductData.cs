using Abc.Data.Common;

namespace Abc.Data.Shop {
    public sealed class ProductData : DefinedEntityData {
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public byte[] Picture { get; set; }
        public string CatalogId { get; set; }
        public string BrandId { get; set; }
    }

}
