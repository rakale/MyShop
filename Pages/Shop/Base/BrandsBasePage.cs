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
    public abstract class BrandsBasePage<TPage> :
        ViewPage<TPage, IBrandsRepository, Brand, BrandView, BrandData>
        where TPage : PageModel {
        protected BrandsBasePage(IBrandsRepository r) : base(r, "Brands") { }

        protected internal override Brand toObject(BrandView v) => new BrandViewFactory().Create(v);

        protected internal override BrandView toView(Brand o) => new BrandViewFactory().Create(o);
        protected override void createTableColumns() {
            createColumn(x => Item.Id);
            createColumn(x => Item.Name);
            createColumn(x => Item.Code);
            createColumn(x => Item.From);
            createColumn(x => Item.To);
        }

        public override string GetName(IHtmlHelper<TPage> h, int i) => i switch {
            3 or 4 => getName<DateTime?>(h, i),
            _ => base.GetName(h, i)
        };

        public override IHtmlContent GetValue(IHtmlHelper<TPage> h, int i) => i switch {
            3 or 4 => getValue<DateTime?>(h, i),
            _ => base.GetValue(h, i)
        };

    }
}
