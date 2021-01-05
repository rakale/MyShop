using Abc.Data.Shop;
using Abc.Infra;
using Abc.Pages.Common;
using Abc.Domain.Shop;
using Abc.Facade.Shop;
using System;

namespace Abc.Pages.Shop {
    public class BasketsPage : ViewPage<BasketsPage, IBasketsRepository, Basket, BasketView, BasketData> {
        public BasketsPage(IBasketsRepository r) : base(r, "Baskets") { }

        protected override void createTableColumns() {
            createColumn(x => Item.Id);
            createColumn(x => Item.BuyerId);
        }

        protected internal override Uri pageUrl() => new Uri("/Shop/Baskets", UriKind.Relative);
        

        protected internal override Basket toObject(BasketView v) => new BasketViewFactory().Create(v);


        protected internal override BasketView toView(Basket o) => new BasketViewFactory().Create(o);


    }
}


