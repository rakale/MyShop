using Abc.Data.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Facade.Shop.Factories;
using Abc.Facade.Shop.Views;
using Abc.Pages.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Abc.Pages.Shop.Base {
    public abstract class BuyersBasePage<TPage> :
        ViewPage<TPage, IBuyersRepository, Buyer, BuyerView, BuyerData>
        where TPage : PageModel {
        protected BuyersBasePage(IBuyersRepository r, string title) : base(r, title) { }
        

        protected internal override Buyer toObject(BuyerView v) => new BuyerViewFactory().Create(v);

        protected internal override BuyerView toView(Buyer o) => new BuyerViewFactory().Create(o);
        protected override void createTableColumns() {
            createColumn(x => Item.Name);
            createColumn(x => Item.Id);
            createColumn(x => Item.Address);            
        }

        public override string GetName(IHtmlHelper<TPage> h, int i) => i switch {
            1 => "e-mail",
            _ => base.GetName(h, i)
        };
    }
}

