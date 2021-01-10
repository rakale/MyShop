using Abc.Data.Common;

namespace Abc.Data.Shop {
    public class ProductData : NamedEntityData {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public byte[] Picture { get; set; }
        public string CatalogTypeId { get; set; }
        public string CatalogBrandId { get; set; }
    }

}
