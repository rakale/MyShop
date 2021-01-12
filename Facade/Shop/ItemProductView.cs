using Abc.Facade.Common;
using System.ComponentModel;

namespace Abc.Facade.Shop {
    public abstract class ItemProductView : PeriodView {
        public int Quantity { get; set; }
        [DisplayName("Product")]
        public string ProductId { get; set; }
    }
}
