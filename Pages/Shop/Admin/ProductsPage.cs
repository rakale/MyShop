using Abc.Domain.Shop.Repositories;
using Abc.Pages.Shop.Base;
using System;

namespace Abc.Pages.Shop.Admin {
    public class ProductsPage : ProductsBasePage<ProductsPage> {
        public ProductsPage(IProductsRepository r, ICatalogsRepository c, IBrandsRepository b)
            : base(r, c, b) {
        }
        protected internal override Uri pageUrl() => new Uri("/Shop/Products", UriKind.Relative);
    }
}
