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
    public class BasketsPage : ViewPage<BasketsPage, IBasketsRepository, Basket, BasketView, BasketData> {
        public BasketsPage(IBasketsRepository r) : base(r, "Baskets"){}
        protected internal override Uri pageUrl() => new Uri("/Shop/Baskets", UriKind.Relative);
        protected internal override Basket toObject(BasketView v) => new BasketViewFactory().Create(v);
        protected internal override BasketView toView(Basket o) => new BasketViewFactory().Create(o);
        protected override void createTableColumns() {
            createColumn(x => Item.Id);
            createColumn(x => Item.BuyerId);
            createColumn(x => Item.From);
            createColumn(x => Item.To);
        }
        public override string GetName(IHtmlHelper<BasketsPage> html, int i) {
            switch (i) {
                case 2:
                case 3:
                    return getName<DateTime?>(html, i);
                default:
                    return base.GetName(html, i);
            }
        }

        public override IHtmlContent GetValue(IHtmlHelper<BasketsPage> html, int i) {
            switch (i) {
                case 2:
                case 3:
                    return getValue<DateTime?>(html, i);
                default:
                    return base.GetValue(html, i);
            }
        }
    }
}
