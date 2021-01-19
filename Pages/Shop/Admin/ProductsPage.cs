using Abc.Domain.Shop.Repositories;
using Abc.Pages.Common.Extensions;
using Abc.Pages.Shop.Base;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Abc.Pages.Shop.Admin {
    public class ProductsPage : ProductsBasePage<ProductsPage> {
        protected override string basketItemsPage => "/Shop/BasketItems";

        public ProductsPage(IProductsRepository r, ICatalogsRepository c, IBrandsRepository b,
            IBasketsRepository ba, IBasketItemsRepository bi)
            : base(r, c, b, ba, bi) {
        }
        protected internal override Uri pageUrl() => new Uri("/Shop/Products", UriKind.Relative);
        protected override void createTableColumns() {
            createColumn(x => Item.Id);
            base.createTableColumns();
            createColumn(x => Item.From);
            createColumn(x => Item.To);
        }
        public override IHtmlContent GetValue(IHtmlHelper<ProductsPage> h, int i) => i switch {
            5 => h.DisplayImageFor(Item.PictureUri),
            6 => getRaw(h, CatalogName(Item.CatalogId)),
            7 => getRaw(h, BrandName(Item.BrandId)),
            _ => base.GetValue(h, i)
        };
    }
}
