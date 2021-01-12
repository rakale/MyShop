using Abc.Facade.Common;
using System.ComponentModel;

namespace Abc.Facade.Shop {
    public abstract class BuyerProductView : DefinedView {
        [DisplayName("Buyer")]public string BuyerId { get; set; }
    }
}
