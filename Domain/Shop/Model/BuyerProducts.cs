using Abc.Data.Shop;
using Abc.Domain.Common;
using Abc.Domain.Shop.Repositories;

namespace Abc.Domain.Shop.Model {
    public abstract class BuyerProducts<TData> : DefinedEntity<TData>
        where TData : BuyerProductsData, new() {
        protected BuyerProducts(TData d) : base(d) { }
        public string BuyerId => Data?.BuyerId ?? Unspecified;
        public Buyer Buyer => new GetFrom<IBuyersRepository, Buyer>().ById(BuyerId);
    }
}
