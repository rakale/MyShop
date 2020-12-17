using Abc.Facade.Common;

namespace Abc.Facade.Shop {
    public class ProductView : NamedView {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public string CatalogTypeId { get; set; }
        public string CatalogBrandId { get; set; }
    }

}
