using System.ComponentModel;

namespace Abc.Facade.Shop.Views {
    public sealed class BasketView : BuyerProductView {
        [DisplayName("Buyer name")] public string BuyerName { get; set; }
        [DisplayName("Buyer address")] public string BuyerAddress { get; set; }
        [DisplayName("Total Price")] public decimal TotalPrice { get; set; }
        [DisplayName("Closed")] public bool Closed { get; set; }
    }
}
