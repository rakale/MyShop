using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Infra.Common;

namespace Abc.Infra.Shop {
    public sealed class OrdersRepository :
        UniqueEntityRepository<Order, OrderData>, IOrdersRepository {
        public OrdersRepository(ShopDbContext c) : base(c, c.Orders) { }

        protected internal override Order toDomainObject(OrderData d) => new Order(d);
    }
}
