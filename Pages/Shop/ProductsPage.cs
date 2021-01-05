using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Shop;
using Abc.Infra;
using Abc.Pages.Common;
using System;

namespace Abc.Pages.Shop {
    public class ProductsPage : ViewPage<ProductsPage,IProductsRepository, Product, ProductView, ProductData> {
        public ProductsPage(IProductsRepository r) : base(r, "Products") { }
        protected override void createTableColumns() {
            createColumn(x => Item.Id);
        }

        protected internal override Uri pageUrl() => new Uri("/Shop/Products", UriKind.Relative);

        protected internal override Product toObject(ProductView v) => new ProductViewFactory().Create(v);

        protected internal override ProductView toView(Product o) => new ProductViewFactory().Create(o);
    }

}
