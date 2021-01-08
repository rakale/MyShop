using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Shop;
using Abc.Pages.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;

namespace Abc.Pages.Shop {
    public class OrderItemsPage :ViewPage<OrderItemsPage,
        IOrderItemsRepository, OrderItem, OrderItemView, OrderItemData> {
        public OrderItemsPage(IOrderItemsRepository r) : base(r, "OrderItems") { }
        protected internal override Uri pageUrl() => new Uri("/Shop/OrderItems", UriKind.Relative);
        protected internal override OrderItem toObject(OrderItemView v) => new OrderItemViewFactory().Create(v);
        protected internal override OrderItemView toView(OrderItem o) => new OrderItemViewFactory().Create(o);
        protected override void createTableColumns() {
            createColumn(x => Item.Id);
            createColumn(x => Item.CatalogItemId);
            createColumn(x => Item.ProductName);
            createColumn(x => Item.PictureUri);
            createColumn(x => Item.UnitPrice);
            createColumn(x => Item.Units);
            createColumn(x => Item.OrderId);
            createColumn(x => Item.From);
            createColumn(x => Item.To);
        }
        public override string GetName(IHtmlHelper<OrderItemsPage> html, int i) {
            switch (i) {
                case 4:
                    return html.DisplayNameFor(Columns[i] as Expression<Func<OrderItemsPage, decimal>>);
                case 5:
                    return html.DisplayNameFor(Columns[i] as Expression<Func<OrderItemsPage, int>>);
                case 7:
                case 8:
                    return html.DisplayNameFor(Columns[i] as Expression<Func<OrderItemsPage, DateTime?>>);
                default:
                    return base.GetName(html, i);
            }
        }

        public override IHtmlContent GetValue(IHtmlHelper<OrderItemsPage> html, int i) {
            switch (i) {
                case 4:
                    return html.DisplayFor(Columns[i] as Expression<Func<OrderItemsPage, decimal>>);
                case 5:
                    return html.DisplayFor(Columns[i] as Expression<Func<OrderItemsPage, int>>);
                case 7:
                case 8:
                    return html.DisplayFor(Columns[i] as Expression<Func<OrderItemsPage, DateTime?>>);
                default:
                    return base.GetValue(html, i);
            }
        }
    }
}
