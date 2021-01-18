using Abc.Domain.Shop.Repositories;
using Abc.Pages.Shop.Base;
using System;

namespace Abc.Pages.Shop.Client {
    public class ProductsClientPage : ProductsBasePage<ProductsClientPage> {
        public ProductsClientPage(IProductsRepository r, ICatalogsRepository c, IBrandsRepository b)
            : base(r, c, b) {
        }
        protected internal override Uri pageUrl() => new Uri("/Client/Products", UriKind.Relative);
    }
}
