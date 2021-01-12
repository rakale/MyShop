using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Common;

namespace Abc.Facade.Shop {
    public sealed class BuyerViewFactory : AbstractViewFactory<BuyerData, Buyer, BuyerView> {
        protected internal override Buyer toObject(BuyerData d) => new Buyer(d);
    }
}