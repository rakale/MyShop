using Abc.Domain.Shop.Repositories;
using Abc.Pages.Common.Extensions;
using Abc.Pages.Shop.Base;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Abc.Pages.Shop.Client {
    public class ProductsClientPage : ProductsBasePage<ProductsClientPage> {
        protected override string basketItemsPage => "/Client/BasketItems";

        public ProductsClientPage(IProductsRepository r, ICatalogsRepository c, IBrandsRepository b,
            IBasketsRepository ba, IBasketItemsRepository bi)
            : base(r, c, b, ba, bi) {
        }
        protected internal override Uri pageUrl() => new Uri("/Client/Products", UriKind.Relative);

        public override string GetName(IHtmlHelper<ProductsClientPage> h, int i) => i switch {
            3 => getName<decimal>(h, i),
            _ => base.GetName(h, i)
        };

        public override IHtmlContent GetValue(IHtmlHelper<ProductsClientPage> h, int i) => i switch {
            3 => getValue<decimal>(h, i),
            4 => h.DisplayImageFor(Item.PictureUri),
            5 => getRaw(h, CatalogName(Item.CatalogId)),
            6 => getRaw(h, BrandName(Item.BrandId)),
            _ => base.GetValue(h, i)
        };
    }
}
