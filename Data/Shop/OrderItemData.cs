using Abc.Data.Common;

namespace Abc.Data.Shop {
    public sealed class OrderItemData : PeriodData {
        public string ProductId { get; set; }        
        public int Units { get; set; }
        public string OrderId { get; set; }
    }

}
