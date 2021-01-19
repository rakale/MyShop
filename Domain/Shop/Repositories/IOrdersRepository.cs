using Abc.Domain.Common;
using Abc.Domain.Shop.Model;
using System.Threading.Tasks;

namespace Abc.Domain.Shop.Repositories {
    public interface IOrdersRepository : IRepository<Order> {
        Task<Order> Add(Basket b);
    }
}
