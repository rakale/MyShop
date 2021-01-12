using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Shop;
using Abc.Pages.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Abc.Pages.Shop {
    public class OrdersPage : ViewPage<OrdersPage, IOrdersRepository, Order, OrderView, OrderData> {
        public OrdersPage(IOrdersRepository r) : base(r, "Orders") { }
        protected internal override Uri pageUrl() => new Uri("/Shop/Orders", UriKind.Relative);
        protected internal override Order toObject(OrderView v) => new OrderViewFactory().Create(v);
        protected internal override OrderView toView(Order o) => new OrderViewFactory().Create(o);
        protected override void createTableColumns() {
            createColumn(x => Item.Id);
            createColumn(x => Item.BuyerId);
            createColumn(x => Item.Street);
            createColumn(x => Item.City);
            createColumn(x => Item.State);
            createColumn(x => Item.ZipCode);
            createColumn(x => Item.Country);
            createColumn(x => Item.From);
            createColumn(x => Item.To);
        }

        public override string GetName(IHtmlHelper<OrdersPage> h, int i) => i switch {
            7 or 8 => getName<DateTime?>(h, i),
            _ => base.GetName(h, i)
        };
        public override IHtmlContent GetValue(IHtmlHelper<OrdersPage> h, int i) => i switch {
            7 or 8 => getValue<DateTime?>(h, i),
            _ => base.GetValue(h, i)
        };

    }

}
