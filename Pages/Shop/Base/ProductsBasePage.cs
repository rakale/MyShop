using Abc.Data.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Facade.Shop.Factories;
using Abc.Facade.Shop.Views;
using Abc.Pages.Common;
using Abc.Pages.Common.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Abc.Pages.Shop.Base {
    public abstract class ProductsBasePage<TPage> :
        ViewPage<TPage, IProductsRepository, Product, ProductView, ProductData>
        where TPage : PageModel {
        public IEnumerable<SelectListItem> Catalogs { get; }
        public IEnumerable<SelectListItem> Brands { get; }
        protected ProductsBasePage(IProductsRepository r, ICatalogsRepository c, IBrandsRepository b)
            : base(r, "Products") {
            Catalogs = newItemsList<Catalog, CatalogData>(c);
            Brands = newItemsList<Brand, BrandData>(b);
        }
        public string CatalogName(string id) => itemName(Catalogs, id);
        public string BrandName(string id) => itemName(Brands, id);
        protected internal override Product toObject(ProductView v) => new ProductViewFactory().Create(v);
        protected internal override ProductView toView(Product o) => new ProductViewFactory().Create(o);
        protected override void createTableColumns() {
            createColumn(x => Item.Id);
            createColumn(x => Item.Name);
            createColumn(x => Item.Code);
            createColumn(x => Item.Definition);
            createColumn(x => Item.Price);
            createColumn(x => Item.PictureUri);
            createColumn(x => Item.CatalogId);
            createColumn(x => Item.BrandId);
            createColumn(x => Item.From);
            createColumn(x => Item.To);
        }

        public override string GetName(IHtmlHelper<TPage> h, int i) => i switch {
            4 => getName<decimal>(h, i),
            8 or 9 => getName<DateTime?>(h, i),
            _ => base.GetName(h, i)
        };

        public override IHtmlContent GetValue(IHtmlHelper<TPage> h, int i) => i switch {
            4 => getValue<decimal>(h, i),
            5 => h.DisplayImageFor(Item.PictureUri),
            6 => getRaw(h, CatalogName(Item.CatalogId)),
            7 => getRaw(h, BrandName(Item.BrandId)),
            8 or 9 => getValue<DateTime?>(h, i),
            _ => base.GetValue(h, i)
        };
    }
}
