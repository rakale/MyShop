using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Common;
using System.IO;

namespace Abc.Facade.Shop {
    public sealed class ProductViewFactory :AbstractViewFactory<ProductData, Product, ProductView> {
        protected internal override Product toObject(ProductData d) => new Product(d);
        protected internal override void copyMembers(ProductView v, ProductData d) {
            base.copyMembers(v, d);
            d.PictureUri = v?.PictureFile?.FileName;
            var stream = new MemoryStream();
            v?.PictureFile?.CopyTo(stream);
            if (stream.Length < 2097152)
                d.Picture = stream.ToArray();
        }
    }
}
