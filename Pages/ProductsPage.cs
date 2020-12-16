using Abc.Data.Shop;
using Infra;

namespace Pages {
    public class ProductsPage : AbstractPage<ProductsPage, ProductData> {
        public ProductsPage(ShopDbContext c) : base(c, c.Products) {
            Caption = "Products";
        }
        protected override void createTableColumns() {
            createColumn(x => Item.Id);
        }
    }

}
