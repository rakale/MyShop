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
using System.Collections.Generic;

namespace Abc.Pages.Shop.Base {
    public abstract class BasketItemsBasePage<TPage> : ViewPage<TPage,
        IBasketItemsRepository, BasketItem, BasketItemView, BasketItemData>
        where TPage : PageModel {
        public IEnumerable<SelectListItem> Products { get; }
        public IEnumerable<SelectListItem> Baskets { get; }
        protected BasketItemsBasePage(IBasketItemsRepository r, IBasketsRepository b, IProductsRepository p)
            : base(r, "Basket items") {
            Products = newItemsList<Product, ProductData>(p);
            Baskets = newItemsList<Basket, BasketData>(b);
        }
        protected internal override string pageSubtitle() => BasketsName(FixedValue);
        public string BasketsName(string id) => itemName(Baskets, id);
        public string ProductName(string id) => itemName(Products, id);
        protected internal override BasketItem toObject(BasketItemView v) => new BasketItemViewFactory().Create(v);
        protected internal override BasketItemView toView(BasketItem o) => new BasketItemViewFactory().Create(o);
    }
}
