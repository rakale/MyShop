using Abc.Data.Common;

namespace Abc.Data.Shop {
    public class BasketItemData : UniqueEntityData {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string CatalogItemId { get; set; }
        public string BasketId { get; set; }
    }

}
