using Abc.Domain.Shop.Repositories;
using Abc.Pages.Shop.Base;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Abc.Pages.Shop.Admin {
    public class BasketItemsPage : BasketItemsBasePage<BasketItemsPage> {
        public BasketItemsPage(IBasketItemsRepository r, IBasketsRepository b, IProductsRepository p) : base(r, b, p) { }
        protected internal override Uri pageUrl() => new Uri("/Shop/BasketItems", UriKind.Relative);
        protected override void createTableColumns() {
            createColumn(x => Item.GetId());
            createColumn(x => Item.BasketId);
            createColumn(x => Item.ProductId);
            createColumn(x => Item.ProductName);
            createColumn(x => Item.UnitPrice);
            createColumn(x => Item.Quantity);
            createColumn(x => Item.TotalPrice);
            createColumn(x => Item.From);
            createColumn(x => Item.To);
        }
        public override string GetName(IHtmlHelper<BasketItemsPage> h, int i) => i switch {
            4 or 6 => getName<decimal>(h, i),
            5 => getName<int>(h, i),
            7 or 8 => getName<DateTime?>(h, i),
            _ => base.GetName(h, i)
        };

        public override IHtmlContent GetValue(IHtmlHelper<BasketItemsPage> h, int i) => i switch {
            4 or 6 => getValue<decimal>(h, i),
            5 => getValue<int>(h, i),
            7 or 8 => getValue<DateTime?>(h, i),
            _ => base.GetValue(h, i)
        };
    }
}
