﻿using Abc.Data.Shop;
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
    public abstract class CatalogsBasePage<TPage> :
        ViewPage<TPage, ICatalogsRepository, Catalog, CatalogView, CatalogData>
        where TPage : PageModel {
        protected CatalogsBasePage(ICatalogsRepository r) : base(r, "Catalogs") { }
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