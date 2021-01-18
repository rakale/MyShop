using Abc.Domain.Common;
using Abc.Domain.Shop.Model;
using System.Threading.Tasks;

namespace Abc.Domain.Shop.Repositories {
    public interface IBasketItemsRepository : IRepository<BasketItem> {
        Task<BasketItem> Add(Basket b, Product p);
    }
}
