using Abc.Data.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Facade.Shop.Factories;
using Abc.Facade.Shop.Views;
using Abc.Pages.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Abc.Pages.Shop.Base {
    public abstract class BasketItemsBasePage<TPage> :ViewPage<TPage,
        IBasketItemsRepository, BasketItem, BasketItemView, BasketItemData>
        where TPage : PageModel {
        protected BasketItemsBasePage(IBasketItemsRepository r) : base(r, "BasketItems") { }
        protected internal override Uri pageUrl() => new Uri("/Shop/BasketItems", UriKind.Relative);
        protected internal override BasketItem toObject(BasketItemView v) => new BasketItemViewFactory().Create(v);
        protected internal override BasketItemView toView(BasketItem o) => new BasketItemViewFactory().Create(o);
        protected override void createTableColumns() {
            createColumn(x => Item.UnitPrice);
            createColumn(x => Item.Quantity);
            createColumn(x => Item.ProductId);
            createColumn(x => Item.BasketId);
            createColumn(x => Item.From);
            createColumn(x => Item.To);
        }
        public override string GetName(IHtmlHelper<TPage> h, int i) => i switch {
            0 => getName<decimal>(h, i),
            1 => getName<int>(h, i),
            4 or 5 => getName<DateTime?>(h, i),
            _ => base.GetName(h, i)
        };

        public override IHtmlContent GetValue(IHtmlHelper<TPage> h, int i) => i switch {
            0 => getValue<decimal>(h, i),
            1 => getValue<int>(h, i),
            4 or 5 => getValue<DateTime?>(h, i),
            _ => base.GetValue(h, i)
        };
    }
}
