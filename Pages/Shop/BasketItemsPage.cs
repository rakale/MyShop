using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Shop;
using Abc.Pages.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;

namespace Abc.Pages.Shop {
    public class BasketItemsPage :ViewPage<BasketItemsPage, 
        IBasketItemsRepository, BasketItem, BasketItemView, BasketItemData> {
        public BasketItemsPage(IBasketItemsRepository r) : base(r, "BasketItems") { }
        protected internal override Uri pageUrl() => new Uri("/Shop/BasketItems", UriKind.Relative);
        protected internal override BasketItem toObject(BasketItemView v) => new BasketItemViewFactory().Create(v);
        protected internal override BasketItemView toView(BasketItem o) => new BasketItemViewFactory().Create(o);
        protected override void createTableColumns() {
            createColumn(x => Item.Id);
            createColumn(x => Item.UnitPrice);
            createColumn(x => Item.Quantity);
            createColumn(x => Item.CatalogItemId);
            createColumn(x => Item.BasketId);
            createColumn(x => Item.From);
            createColumn(x => Item.To);
        }
        public override string GetName(IHtmlHelper<BasketItemsPage> html, int i) {
            switch (i) {
                case 1:
                    return html.DisplayNameFor(Columns[i] as Expression<Func<BasketItemsPage, decimal>>);
                case 2:
                    return html.DisplayNameFor(Columns[i] as Expression<Func<BasketItemsPage, int>>);
                case 5:
                case 6:
                    return html.DisplayNameFor(Columns[i] as Expression<Func<BasketItemsPage, DateTime?>>);
                default:
                    return base.GetName(html, i);
            }
        }

        public override IHtmlContent GetValue(IHtmlHelper<BasketItemsPage> html, int i) {
            switch (i) {
                case 1:
                    return html.DisplayFor(Columns[i] as Expression<Func<BasketItemsPage, decimal>>);
                case 2:
                    return html.DisplayFor(Columns[i] as Expression<Func<BasketItemsPage, int>>);
                case 5:
                case 6:
                    return html.DisplayFor(Columns[i] as Expression<Func<BasketItemsPage, DateTime?>>);
                default:
                    return base.GetValue(html, i);
            }
        }
    }
}
