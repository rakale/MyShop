using Abc.Data.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Infra.Common;
using System.Threading.Tasks;

namespace Abc.Infra.Shop {
    public sealed class OrdersRepository :
        UniqueEntityRepository<Order, OrderData>, IOrdersRepository {
        public OrdersRepository(ShopDbContext c) : base(c, c.Orders) { }

        public async Task<Order> Add(Basket b) {
            OrderData d = new OrderData {
                BuyerId = b.BuyerId,
                Name = b.Name,
                City = b.Buyer.City,
                Country = b.Buyer.Country,
                State = b.Buyer.State,
                Street = b.Buyer.Street,
                ZipCode = b.Buyer.ZipCode,
                From = b.ValidFrom
            };
            var obj = toDomainObject(d);
            await Add(obj);
            return obj;
        }

        protected internal override Order toDomainObject(OrderData d) => new Order(d);
    }
}
