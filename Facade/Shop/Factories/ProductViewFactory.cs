using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Domain.Shop.Model;
using Abc.Facade.Common;
using Abc.Facade.Shop.Views;
using System;
using System.IO;

namespace Abc.Facade.Shop.Factories {
    public sealed class ProductViewFactory : AbstractViewFactory<ProductData, Product, ProductView> {
        protected internal override Product toObject(ProductData d) => new Product(d);
        protected internal override void copyMembers(ProductView v, ProductData d) {
            base.copyMembers(v, d);
            d.PictureUri = v?.PictureFile?.FileName;
            var stream = new MemoryStream();
            v?.PictureFile?.CopyTo(stream);
            if (stream.Length < 2097152)
                d.Picture = stream.ToArray();
        }

        protected internal override void copyMembers(ProductData d, ProductView v) {
            base.copyMembers(d, v);
            var s = Convert.ToBase64String(
                d?.Picture ?? Array.Empty<byte>(),
                0, d?.Picture?.Length ?? 0);
            v.PictureUri = "data:image/jpg;base64," + s;
        }
    }
}
