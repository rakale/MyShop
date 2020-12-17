using Abc.Facade.Common;

namespace Abc.Facade.Shop {
    public class OrderItemView : UniqueEntityView {
        public string CatalogItemId { get; set; }
        public string ProductName { get; set; }
        public string PictureUri { get; set; }
        public decimal UnitPrice { get; set; }
        public int Units { get; set; }
        public string OrderId { get; set; }
    }

}
