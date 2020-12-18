using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Infra.Common;

namespace Abc.Infra.Shop {
    public sealed class OrderItemsRepository :
        UniqueEntityRepository<OrderItem, OrderItemData>, IOrderItemsRepository {
        public OrderItemsRepository(ShopDbContext c) : base(c, c.OrderItems) { }

        protected internal override OrderItem toDomainObject(OrderItemData d) => new OrderItem(d);
    }
}
