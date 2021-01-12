using Abc.Domain.Shop.Repositories;
using Abc.Pages.Shop.Base;


namespace Abc.Pages.Shop.Admin {
    public class BasketItemsPage : BasketItemsBasePage<BasketItemsPage> {
        public BasketItemsPage(IBasketItemsRepository r) : base(r) { }
    }
}
        