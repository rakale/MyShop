using Abc.Data.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Facade.Shop.Factories;
using Abc.Facade.Shop.Views;
using Abc.Pages.Common;
using Abc.Pages.Common.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abc.Pages.Shop.Base {
    public abstract class ProductsBasePage<TPage> :
        ViewPage<TPage, IProductsRepository, Product, ProductView, ProductData>
        where TPage : PageModel {
        public IEnumerable<SelectListItem> Catalogs { get; }
        public IEnumerable<SelectListItem> Brands { get; }
        public IBasketsRepository Baskets { get; }
        public IBasketItemsRepository BasketItems { get; }

        protected ProductsBasePage(IProductsRepository r, ICatalogsRepository c, IBrandsRepository b,
            IBasketsRepository ba, IBasketItemsRepository bi)
            : base(r, "Products") {
            Catalogs = newItemsList<Catalog, CatalogData>(c);
            Brands = newItemsList<Brand, BrandData>(b);
            Baskets = ba;
            BasketItems = bi;
        }
        public string CatalogName(string id) => itemName(Catalogs, id);
        public string BrandName(string id) => itemName(Brands, id);
        protected internal override Product toObject(ProductView v) => new ProductViewFactory().Create(v);
        protected internal override ProductView toView(Product o) => new ProductViewFactory().Create(o);
        protected override void createTableColumns() {
            createColumn(x => Item.Name);
            createColumn(x => Item.Code);
            createColumn(x => Item.Definition);
            createColumn(x => Item.Price);
            createColumn(x => Item.PictureUri);
            createColumn(x => Item.CatalogId);
            createColumn(x => Item.BrandId);
        }
        public virtual async Task<IActionResult> OnGetSelectAsync(string id, string sortOrder, string searchString,
            int pageIndex, string fixedFilter, string fixedValue) {

            Product p = await db.Get(id);
            Basket b = await Baskets.GetLatestForUser(User.Identity.Name);
            BasketItem i = await BasketItems.Add(b, p);

            var url = new Uri($"{basketItemsPage}/Edit?handler=Edit" +
                $"&id={i.Id}" +
                $"&fixedFilter={nameof(i.BasketId)}" +
                $"&fixedValue={b.Id}", UriKind.Relative);

            return Redirect(url.ToString());
        }

        protected abstract string basketItemsPage { get; }
    }
}
