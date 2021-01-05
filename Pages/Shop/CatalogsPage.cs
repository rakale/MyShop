using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Shop;
using Abc.Infra;
using Abc.Pages.Common;
using System;

namespace Abc.Pages.Shop {
    public class CatalogsPage : ViewPage<CatalogsPage, ICatalogsRepository, Catalog, CatalogView, CatalogData> {
        public CatalogsPage(ICatalogsRepository r) : base(r, "Catalogs") { }
        protected override void createTableColumns() {
            createColumn(x => Item.Id);
            createColumn(x => Item.Name);
        }

        protected internal override Uri pageUrl() => new Uri("/Shop/Catalogs", UriKind.Relative);

        protected internal override Catalog toObject(CatalogView v) => new CatalogViewFactory().Create(v);

        protected internal override CatalogView toView(Catalog o) => new CatalogViewFactory().Create(o);
    
    }
}


