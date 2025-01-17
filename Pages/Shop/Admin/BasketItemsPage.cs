﻿using Abc.Domain.Shop.Repositories;
using Abc.Pages.Shop.Base;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Abc.Pages.Shop.Admin {
    public class BasketItemsPage : BasketItemsBasePage<BasketItemsPage> {
        protected override string ordersPage => "/Shop/Orders";

        public BasketItemsPage(IBasketItemsRepository r, IBasketsRepository b, IProductsRepository p,
            IOrdersRepository o, IOrderItemsRepository oi) : base(r, b, p, o, oi) { }
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
            0 => "Id",
            _ => base.GetName(h, i)
        };
        public override IHtmlContent GetValue(IHtmlHelper<BasketItemsPage> h, int i) => i switch {
            0 => getRaw(h, Item.GetId()),
            _ => base.GetValue(h, i)
        };
    }
}
