using Abc.Data.Common;

namespace Abc.Data.Shop {
    public class OrderItemData : UniqueEntityData {
        public string CatalogItemId { get; set; }
        public string ProductName { get; set; }
        public string PictureUri { get; set; }
        public decimal UnitPrice { get; set; }
        public int Units { get; set; }
        public string OrderId { get; set; }
    }

}
