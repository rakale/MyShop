using Abc.Aids.Methods;
using System.ComponentModel;

namespace Abc.Facade.Shop.Views {
    public sealed class OrderItemView : ItemProductView {
        [DisplayName("Product name")] public string ProductName { get; set; }
        [DisplayName("Product image")] public string PictureUri { get; set; }
        [DisplayName("Unit price")] public decimal UnitPrice { get; set; }
        [DisplayName("Total price")] public decimal TotalPrice { get; set; }
        [DisplayName("Order")] public string OrderId { get; set; }

        public override string GetId() => Compose.Id(OrderId, base.ProductId);
    }
}
