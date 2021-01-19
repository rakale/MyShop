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
    public abstract class OrderItemsBasePage<TPage> : ViewPage<TPage,
        IOrderItemsRepository, OrderItem, OrderItemView, OrderItemData>
        where TPage : PageModel {
        protected OrderItemsBasePage(IOrderItemsRepository r) : base(r, "OrderItems") { }
        protected internal override Uri pageUrl() => new Uri("/Shop/OrderItems", UriKind.Relative);
        protected internal override OrderItem toObject(OrderItemView v) => new OrderItemViewFactory().Create(v);
        protected internal override OrderItemView toView(OrderItem o) => new OrderItemViewFactory().Create(o);
        protected override void createTableColumns() {
            createColumn(x => Item.ProductId);
            createColumn(x => Item.ProductName);
            createColumn(x => Item.PictureUri);
            createColumn(x => Item.UnitPrice);
            createColumn(x => Item.Quantity);
            createColumn(x => Item.OrderId);
            createColumn(x => Item.From);
            createColumn(x => Item.To);
        }
    }
}
