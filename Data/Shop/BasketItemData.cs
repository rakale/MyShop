using Abc.Data.Common;

namespace Abc.Data.Shop {
    public sealed class BasketItemData : PeriodData {
        public int Quantity { get; set; }
        public string ProductId { get; set; }
        public string BasketId { get; set; }
    }

}
