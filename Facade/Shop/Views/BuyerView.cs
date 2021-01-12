using Abc.Facade.Common;
using Abc.Facade.Shop.Factories;
using System.ComponentModel;

namespace Abc.Facade.Shop.Views {
    public sealed class BuyerView : NamedView {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        [DisplayName("Zip code")]
        public string ZipCode { get; set; }
        public string Address => new BuyerViewFactory().Create(this).ToString();
    }
}
