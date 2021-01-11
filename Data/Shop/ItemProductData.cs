using Abc.Data.Common;

namespace Abc.Data.Shop {
    public abstract class ItemProductData : PeriodData {
        public int Quantity { get; set; }
        public string ProductId { get; set; }
    }
}
