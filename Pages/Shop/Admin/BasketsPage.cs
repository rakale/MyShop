using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Facade.Shop.Factories;
using Abc.Facade.Shop.Views;
using Abc.Pages.Common;
using Abc.Pages.Shop.Base;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public override string GetName(IHtmlHelper<BasketsPage> h, int i) => i switch {
            5 or 6 => getName<DateTime?>(h, i),
            _ => base.GetName(h, i)
        };

        public override IHtmlContent GetValue(IHtmlHelper<BasketsPage> h, int i) => i switch {
            5 or 6 => getValue<DateTime?>(h, i),
            _ => base.GetValue(h, i)
        };

    }
}