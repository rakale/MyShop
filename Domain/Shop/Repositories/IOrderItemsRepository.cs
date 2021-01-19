using Abc.Domain.Common;
using Abc.Domain.Shop.Model;
using System.Threading.Tasks;

namespace Abc.Domain.Shop.Repositories {
    public interface IOrderItemsRepository : IRepository<OrderItem> {
        Task Add(Order o, Basket b);
    }
}
