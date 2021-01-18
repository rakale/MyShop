using Abc.Domain.Shop.Repositories;
using Abc.Pages.Shop.Base;
using System;

namespace Abc.Pages.Shop.Client {
    public class BasketItemsClientPage : BasketItemsBasePage<BasketItemsClientPage> {
        public BasketItemsClientPage(IBasketItemsRepository r, IBasketsRepository b, IProductsRepository p) : base(r, b, p) { }
        protected internal override Uri pageUrl() => new Uri("/Client/BasketItems", UriKind.Relative);
    }
}
