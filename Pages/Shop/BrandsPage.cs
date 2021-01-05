using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Shop;
using Abc.Infra;
using Abc.Pages.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;

namespace Abc.Pages.Shop {
    public class BrandsPage :ViewPage<BrandsPage, IBrandsRepository, Brand, BrandView, BrandData> {
        public BrandsPage(IBrandsRepository r) : base(r, "Brands") { }
        protected internal override Uri pageUrl() => new Uri("/Shop/Brands", UriKind.Relative);

        protected internal override Brand toObject(BrandView v) => new BrandViewFactory().Create(v);

        protected internal override BrandView toView(Brand o) => new BrandViewFactory().Create(o);
        protected override void createTableColumns() {
            createColumn(x => Item.Id);
            createColumn(x => Item.Name);
            createColumn(x => Item.Code);
            createColumn(x => Item.From);
            createColumn(x => Item.To);
        }

        public override string GetName(IHtmlHelper<BrandsPage> html, int i) {
            if (i == 3 || i == 4)
                return html.DisplayNameFor(Columns[i] as Expression<Func<BrandsPage, DateTime?>>);
            return base.GetName(html, i);
        }

        public override IHtmlContent GetValue(IHtmlHelper<BrandsPage> html, int i) {
            if (i == 3 || i == 4)
                return html.DisplayFor(Columns[i] as Expression<Func<BrandsPage, DateTime?>>);
            return base.GetValue(html, i);
        }

    }
}
