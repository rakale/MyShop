using Abc.Domain.Shop.Repositories;
using Abc.Pages.Shop.Base;
using System;

namespace Abc.Pages.Shop.Admin {
    public class BasketItemsPage : BasketItemsBasePage<BasketItemsPage> {
        public BasketItemsPage(IBasketItemsRepository r, IBasketsRepository b, IProductsRepository p) : base(r, b, p) { }
        protected internal override Uri pageUrl() => new Uri("/Shop/BasketItems", UriKind.Relative);
    }
}
