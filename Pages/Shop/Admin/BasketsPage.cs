using Abc.Domain.Shop.Repositories;
using Abc.Pages.Shop.Base;
using System;

namespace Abc.Pages.Shop.Admin {
    public class BasketsPage : BasketsBasePage<BasketsPage> {
        public BasketsPage(IBasketsRepository r) : base(r) { }
        protected internal override Uri pageUrl() => new Uri("/Shop/Baskets", UriKind.Relative);
        protected override void createTableColumns() {
            createColumn(x => Item.Id);
            createColumn(x => Item.BuyerId);
            createColumn(x => Item.Name);
            createColumn(x => Item.Code);
            createColumn(x => Item.Definition);
            createColumn(x => Item.From);
            createColumn(x => Item.To);
        }
    }
}