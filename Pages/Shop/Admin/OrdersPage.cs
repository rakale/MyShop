using Abc.Domain.Shop.Repositories;
using Abc.Pages.Shop.Base;

namespace Abc.Pages.Shop.Admin {
    public class OrdersPage : OrdersBasePage<OrdersPage> {
        public OrdersPage(IOrdersRepository r) : base(r) { }
    }
}
