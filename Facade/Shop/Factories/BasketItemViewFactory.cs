using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Domain.Shop.Model;
using Abc.Facade.Common;
using Abc.Facade.Shop.Views;
using System;

namespace Abc.Facade.Shop.Factories {
    public sealed class BasketItemViewFactory : AbstractViewFactory<BasketItemData, BasketItem, BasketItemView> {
        protected internal override BasketItem toObject(BasketItemData d) => new BasketItem(d);
        public override BasketItemView Create(BasketItem o) {
            var v = base.Create(o);
            v.ProductName = o.Product.ToString();
            string s = Convert.ToBase64String(
                o.Product.Picture, 0,
                o.Product.Picture.Length);
            v.ProductImage = "data:image/jpg;base64, " + s;
            v.UnitPrice = o.Product.Price;
            v.TotalPrice = o.TotalPrice;
            return v;
        }
    }
}
