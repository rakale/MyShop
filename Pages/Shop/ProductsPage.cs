using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Shop;
using Abc.Infra;
using Abc.Pages.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Abc.Pages.Shop {
    public class ProductsPage :ViewPage<ProductsPage, IProductsRepository, Product, ProductView, ProductData> {
        public IEnumerable<SelectListItem> Catalogs { get; }
        public IEnumerable<SelectListItem> Brands { get; }
        public ProductsPage(IProductsRepository r, ICatalogsRepository c, IBrandsRepository b) 
            : base(r, "Products") {
            Catalogs = newItemsList<Catalog, CatalogData>(c);
            Brands = newItemsList<Brand, BrandData>(b);
        }
        public string CatalogName(string id) => itemName(Catalogs, id);
        public string BrandName(string id) => itemName(Brands, id);
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

        public override string GetName(IHtmlHelper<ProductsPage> h, int i) => i switch {
            4 => getName<decimal>(h, i),
            8 or 9 => getName<DateTime?>(h, i),
            _ => base.GetName(h, i)
        };

        public override IHtmlContent GetValue(IHtmlHelper<ProductsPage> h, int i) => i switch {
            4 => getValue<decimal>(h, i),
            6 => getRaw(h, CatalogName(Item.CatalogTypeId)),
            7 => getRaw(h, BrandName(Item.CatalogBrandId)),
            8 or 9 => getValue<DateTime?>(h, i),
            _ => base.GetValue(h, i)
        };
    }
}
