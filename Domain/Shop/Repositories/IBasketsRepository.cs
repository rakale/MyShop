using Abc.Domain.Common;
using Abc.Domain.Shop.Model;
using System.Threading.Tasks;

namespace Abc.Domain.Shop.Repositories {
    public interface IBasketsRepository : IRepository<Basket> {
        Task<Basket> GetLatestForUser(string name);
        Task Close(Basket b);
    }
}
