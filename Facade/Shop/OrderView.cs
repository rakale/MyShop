
using System.ComponentModel;

namespace Abc.Facade.Shop {
    public sealed class OrderView : BuyerProductView {
        public string Reciever { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        [DisplayName("Zip code")] public string ZipCode { get; set; }
        public string Address => new OrderViewFactory().Create(this).ToString();
        [DisplayName("Buyer address")] public string BuyerAddress { get; set; }
        [DisplayName("Buyer name")] public string BuyerName { get; set; }
        [DisplayName("Total price")] public decimal TotalPrice { get; set; }
        public bool Closed { get; set; }
    }

}
