using Abc.Data.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Facade.Shop.Factories;
using Abc.Facade.Shop.Views;
using Abc.Pages.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abc.Pages.Shop.Base {
    public abstract class BasketItemsBasePage<TPage> : ViewPage<TPage,
        IBasketItemsRepository, BasketItem, BasketItemView, BasketItemData>
        where TPage : PageModel {
        public IEnumerable<SelectListItem> Products { get; }
        public IEnumerable<SelectListItem> Baskets { get; }
        public IBasketsRepository BasketsRepo { get; }
        public IOrdersRepository Orders { get; }
        public IOrderItemsRepository OrderItems { get; }

        protected BasketItemsBasePage(IBasketItemsRepository r, IBasketsRepository b, IProductsRepository p,
            IOrdersRepository o, IOrderItemsRepository oi)
            : base(r, "Basket items") {
            Products = newItemsList<Product, ProductData>(p);
            Baskets = newItemsList<Basket, BasketData>(b);
            BasketsRepo = b;
            Orders = o;
            OrderItems = oi;
        }
        protected internal override string pageSubtitle() => BasketsName(FixedValue);
        public string BasketsName(string id) => itemName(Baskets, id);
        public string ProductName(string id) => itemName(Products, id);
        protected internal override BasketItem toObject(BasketItemView v) => new BasketItemViewFactory().Create(v);
        protected internal override BasketItemView toView(BasketItem o) => new BasketItemViewFactory().Create(o);
        public Uri OrdersUrl => ordersUrl();
        protected internal Uri ordersUrl()
            => new Uri($"{PageUrl}/Orders" +
                       "?handler=Orders" +
                       $"&pageIndex={PageIndex}" +
                       $"&sortOrder={SortOrder}" +
                       $"&searchString={SearchString}" +
                       $"&fixedFilter={FixedFilter}" +
                       $"&fixedValue={FixedValue}", UriKind.Relative);

        public override IActionResult OnGetCreate(
                string sortOrder, string searchString, int? pageIndex,
                string fixedFilter, string fixedValue, int? switchOfCreate) {
            return Redirect("/Client/Products/Index?handler=Index");
        }
        public async Task<IActionResult> OnGetOrdersAsync(string id, string sortOrder, string searchString,
            int pageIndex, string fixedFilter, string fixedValue) {

            Basket b = await BasketsRepo.Get(fixedValue);
            await BasketsRepo.Close(b);
            Order o = await Orders.Add(b);
            await OrderItems.Add(o, b);

            var url = new Uri($"{ordersPage}/Details?handler=Details" +
                $"&id={o.Id}", UriKind.Relative);

            return Redirect(url.ToString());

        }
        protected abstract string ordersPage { get; }
    }
}
