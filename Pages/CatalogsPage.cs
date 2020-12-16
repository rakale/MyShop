using Abc.Data.Shop;
using Infra;

namespace Pages {
    public class CatalogsPage : AbstractPage<CatalogsPage, CatalogData> {
        public CatalogsPage(ShopDbContext c) : base(c, c.Catalogs) {
            Caption = "Catalogs";
        }
        protected override void createTableColumns() {
            createColumn(x => Item.Id);
            createColumn(x => Item.Name);
        }
    }

}
