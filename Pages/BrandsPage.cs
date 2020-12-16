
using Abc.Data.Shop;
using Infra;

namespace Pages {
    public class BrandsPage : AbstractPage<BrandsPage, BrandData> {
        public BrandsPage(ShopDbContext c) : base(c, c.Brands) {
            Caption = "Brands";
        }
        protected override void createTableColumns() {
            createColumn(x => Item.Id);
            createColumn(x => Item.Name);
        }
    }

}
