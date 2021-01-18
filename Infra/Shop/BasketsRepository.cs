using Abc.Data.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Infra.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Infra.Shop {
    public sealed class BasketsRepository :
        UniqueEntityRepository<Basket, BasketData>, IBasketsRepository {
        public BasketsRepository(ShopDbContext c) : base(c, c.Baskets) { }

        public async Task Close(Basket b) {
            var d = b?.Data;
            if (d == null) return;
            d.To = DateTime.Now;
            await Update(new Basket(d));
        }

        public async Task<Basket> GetLatestForUser(string name) {
            var l = await dbSet
                .Where(x => x.BuyerId == name && x.To == null)
                .OrderByDescending(x => x.From)
                .ToListAsync();
            if (l.Count > 0) return toDomainObject(l[0]);
            var d = new BasketData { BuyerId = name, From = DateTime.Now };
            var o = new Basket(d);
            await Add(o);
            return o;
        }


        protected internal override Basket toDomainObject(BasketData d) => new Basket(d);
    }
}
