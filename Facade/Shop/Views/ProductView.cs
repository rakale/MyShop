using Abc.Facade.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace Abc.Facade.Shop.Views {
    public sealed class ProductView : DefinedView {
        public decimal Price { get; set; }
        [DisplayName("Picture")] public string PictureUri { get; set; }
        [DisplayName("Picture")] public IFormFile PictureFile { get; set; }
        [DisplayName("Catalog")] public string CatalogId { get; set; }
        [DisplayName("Brand")] public string BrandId { get; set; }
    }

}
