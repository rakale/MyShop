using Abc.Aids.Extensions;
using Abc.Data.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Infra.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Abc.Infra.Shop {
    public sealed class OrderItemsRepository :
        PaginatedRepository<OrderItem, OrderItemData>, IOrderItemsRepository {
        public OrderItemsRepository(ShopDbContext c) : base(c, c.OrderItems) { }

        public async Task Add(Order o, Basket b) {
            foreach (var e in b.Items) {
                OrderItemData d = new OrderItemData {
                    OrderId = o.Id,
                    ProductId = e.ProductId,
                    Quantity = e.Quantity
                };
                var obj = toDomainObject(d);
                await Add(obj);
            }
        }

        protected override async Task<OrderItemData> getData(string id) {
            var orderId = id?.GetHead();
            var productId = id?.GetTail();
            return await dbSet.FirstOrDefaultAsync(
                m => m.OrderId == orderId &&
                m.ProductId == productId);
        }

        protected override OrderItemData getDataById(OrderItemData d) =>
            dbSet.Find(d?.OrderId, d?.ProductId);

        protected internal override OrderItem toDomainObject(OrderItemData d) => new OrderItem(d);
    }
}
