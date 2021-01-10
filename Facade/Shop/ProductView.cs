using Abc.Facade.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace Abc.Facade.Shop {
    public class ProductView : NamedView {
        public string Description { get; set; }
        public decimal Price { get; set; }
        [DisplayName("Picture")] public string PictureUri { get; set; }
        [DisplayName("Picture")] public IFormFile PictureFile { get; set; }
        [DisplayName("Catalog")] public string CatalogTypeId { get; set; }
        [DisplayName("Brand")] public string CatalogBrandId { get; set; }
    }

}
