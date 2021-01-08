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
    public class CatalogsPage :ViewPage<CatalogsPage, ICatalogsRepository, Catalog, CatalogView, CatalogData> {
        public CatalogsPage(ICatalogsRepository r) : base(r, "Catalogs") { }
        protected internal override Uri pageUrl() => new Uri("/Shop/Catalogs", UriKind.Relative);
        protected internal override Catalog toObject(CatalogView v) => new CatalogViewFactory().Create(v);
        protected internal override CatalogView toView(Catalog o) => new CatalogViewFactory().Create(o);
        protected override void createTableColumns() {
            createColumn(x => Item.Id);
            createColumn(x => Item.Name);
            createColumn(x => Item.Code);
            createColumn(x => Item.From);
            createColumn(x => Item.To);
        }

        public override string GetName(IHtmlHelper<CatalogsPage> html, int i) {
            switch (i) {
                case 3:
                case 4:
                    return html.DisplayNameFor(Columns[i] as Expression<Func<CatalogsPage, DateTime?>>);
                default:
                    return base.GetName(html, i);
            }
        }

        public override IHtmlContent GetValue(IHtmlHelper<CatalogsPage> html, int i) {
            switch (i) {
                case 3:
                case 4:
                    return html.DisplayFor(Columns[i] as Expression<Func<CatalogsPage, DateTime?>>);
                default:
                    return base.GetValue(html, i);
            }
        }
    }
}
