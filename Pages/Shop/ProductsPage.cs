using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Shop;
using Abc.Infra;
using Abc.Pages.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;

namespace Abc.Pages.Shop {
    public class ProductsPage :ViewPage<ProductsPage, IProductsRepository, Product, ProductView, ProductData> {
        public ProductsPage(IProductsRepository r) : base(r, "Products") { }
        protected internal override Uri pageUrl() => new Uri("/Shop/Products", UriKind.Relative);
        protected internal override Product toObject(ProductView v) => new ProductViewFactory().Create(v);
        protected internal override ProductView toView(Product o) => new ProductViewFactory().Create(o);
        protected override void createTableColumns() {
            createColumn(x => Item.Id);
            createColumn(x => Item.Name);
            createColumn(x => Item.Code);
            createColumn(x => Item.Description);
            createColumn(x => Item.Price);
            createColumn(x => Item.PictureUri);
            createColumn(x => Item.CatalogTypeId);
            createColumn(x => Item.CatalogBrandId);
            createColumn(x => Item.From);
            createColumn(x => Item.To);
        }

        public override string GetName(IHtmlHelper<ProductsPage> html, int i) {
            if (i == 4)
                return html.DisplayNameFor(Columns[i] as Expression<Func<ProductsPage, decimal>>);
            if (i == 8 || i == 9)
                return html.DisplayNameFor(Columns[i] as Expression<Func<ProductsPage, DateTime?>>);
            return base.GetName(html, i);
        }

        public override IHtmlContent GetValue(IHtmlHelper<ProductsPage> html, int i) {
            if (i == 4)
                return html.DisplayFor(Columns[i] as Expression<Func<ProductsPage, decimal>>);
            if (i == 8 || i == 9)
                return html.DisplayFor(Columns[i] as Expression<Func<ProductsPage, DateTime?>>);
            return base.GetValue(html, i);
        }
    }
}
