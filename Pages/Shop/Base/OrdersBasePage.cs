using Abc.Data.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Facade.Shop.Factories;
using Abc.Facade.Shop.Views;
using Abc.Pages.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Abc.Pages.Shop.Base {
    public abstract class OrdersBasePage<TPage>
        : ViewPage<TPage, IOrdersRepository, Order, OrderView, OrderData>
        where TPage : PageModel {
        public OrdersBasePage(IOrdersRepository r) : base(r, "Orders") { }
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
    }
}
