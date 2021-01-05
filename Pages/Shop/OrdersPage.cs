using Abc.Data.Shop;
using Abc.Infra;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Abc.Pages.Common;
using System;
using System.Linq.Expressions;
using Abc.Domain.Shop;
using Abc.Facade.Shop;

namespace Abc.Pages.Shop {
    public class OrdersPage : ViewPage<OrdersPage,IOrdersRepository, Order, OrderView, OrderData> {
        public OrdersPage(IOrdersRepository r) : base(r, "Orders") { }
          
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

        protected internal override Uri pageUrl() => new Uri("/Shop/Orders", UriKind.Relative);

        protected internal override Order toObject(OrderView v) => new OrderViewFactory().Create(v);

        protected internal override OrderView toView(Order o) => new OrderViewFactory().Create(o);
    }

}
