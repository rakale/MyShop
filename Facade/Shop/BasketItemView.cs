using Abc.Facade.Common;
using System.ComponentModel;

namespace Abc.Facade.Shop {
    public sealed class BasketItemView : UniqueEntityView {
        [DisplayName("Unit price")]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Basket")]
        public string CatalogItemId { get; set; }
        public string BasketId { get; set; }
    }

}
