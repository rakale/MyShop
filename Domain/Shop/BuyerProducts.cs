using Abc.Data.Common;
using Abc.Data.Shop;
using Abc.Domain.Common;

namespace Abc.Domain.Shop {
    public abstract class BuyerProducts<TData> : DefinedEntity<TData>
        where TData : BuyerProductsData, new() {
        protected BuyerProducts(TData d) : base(d) { }
        public string BuyerId => Data?.BuyerId ?? Unspecified;
        public Buyer Buyer => new GetFrom<IBuyersRepository, Buyer>().ById(BuyerId);
    }
}
