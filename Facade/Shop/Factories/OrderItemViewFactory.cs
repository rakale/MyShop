using Abc.Data.Shop;
using Abc.Domain.Shop.Model;
using Abc.Facade.Common;
using Abc.Facade.Shop.Views;
using System;

namespace Abc.Facade.Shop.Factories {
    public sealed class OrderItemViewFactory : AbstractViewFactory<OrderItemData, OrderItem, OrderItemView> {
        protected internal override OrderItem toObject(OrderItemData d) => new OrderItem(d);
        public override OrderItemView Create(OrderItem o) {
            var v = base.Create(o);
            v.ProductName = o?.Product?.ToString();
            string s = Convert.ToBase64String(
                o.Product.Picture, 0,
                o.Product.Picture.Length);
            v.PictureUri = "data:image/jpg;base64, " + s;
            v.UnitPrice = o?.Product.Price ?? 0M;
            v.TotalPrice = o?.TotalPrice ?? 0M;
            return v;
        }
    }
}
