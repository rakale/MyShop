using Abc.Domain.Shop.Repositories;
using Abc.Pages.Common.Extensions;
using Abc.Pages.Shop.Base;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Abc.Pages.Shop.Client {
    public class BasketItemsClientPage : BasketItemsBasePage<BasketItemsClientPage> {
        protected override string ordersPage => "/Client/Orders";

        public BasketItemsClientPage(IBasketItemsRepository r, IBasketsRepository b, IProductsRepository p,
            IOrdersRepository o, IOrderItemsRepository oi) : base(r, b, p, o, oi) { }
        protected internal override Uri pageUrl() => new Uri("/Client/BasketItems", UriKind.Relative);
        protected override void createTableColumns() {
            createColumn(x => Item.ProductName);
            createColumn(x => Item.ProductImage);
            createColumn(x => Item.UnitPrice);
            createColumn(x => Item.Quantity);
            createColumn(x => Item.TotalPrice);
        }
        public override IHtmlContent GetValue(IHtmlHelper<BasketItemsClientPage> h, int i) => i switch {
            1 => h.DisplayImageFor(Item.ProductImage),
            _ => base.GetValue(h, i)
        };
    }
}
