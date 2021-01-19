using Abc.Domain.Shop.Repositories;
using Abc.Pages.Shop.Base;

namespace Abc.Pages.Shop.Admin {
    public class OrderItemsPage : OrderItemsBasePage<OrderItemsPage> {
        public OrderItemsPage(IOrderItemsRepository r) : base(r) { }
    }
}