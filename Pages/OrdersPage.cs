using Abc.Data.Shop;
using Abc.Infra;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;

namespace Pages {
    public class OrdersPage : AbstractPage<OrdersPage, OrderData> {
        public OrdersPage(ShopDbContext c) : base(c, c.Orders) {
            Caption = "Orders";
        }
        protected override void createTableColumns() {
            createColumn(x => Item.Id);
            createColumn(x => Item.BuyerId);
            createColumn(x => Item.City);
            createColumn(x => Item.Country);
            createColumn(x => Item.State);
            createColumn(x => Item.Street);
            createColumn(x => Item.ZipCode);
            createColumn(x => Item.OrderDate);
        }

        public override string GetName(IHtmlHelper<OrdersPage> html, int i) {
            if (i == 7) return html.DisplayNameFor(Columns[i] as Expression<Func<OrdersPage, DateTime>>);
            return base.GetName(html, i);

        }

        public override IHtmlContent GetValue(IHtmlHelper<OrdersPage> html, int i) {
            if (i == 7) return html.DisplayFor(Columns[i] as Expression<Func<OrdersPage, DateTime>>);
            return base.GetValue(html, i);
        }

    }

}
