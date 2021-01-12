using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Domain.Shop.Model;
using Abc.Facade.Common;
using Abc.Facade.Shop.Views;

namespace Abc.Facade.Shop.Factories {
    public sealed class BuyerViewFactory : AbstractViewFactory<BuyerData, Buyer, BuyerView> {
        protected internal override Buyer toObject(BuyerData d) => new Buyer(d);
    }
}