using Abc.Data.Shop;
using Infra;

namespace Pages {
    public class BasketsPage : AbstractPage<BasketsPage, BasketData> {
        public BasketsPage(ShopDbContext c) : base(c, c.Baskets) {
            Caption = "Baskets";
        }

        protected override void createTableColumns() {
            createColumn(x => Item.Id);
            createColumn(x => Item.BuyerId);
        }
    }

}
