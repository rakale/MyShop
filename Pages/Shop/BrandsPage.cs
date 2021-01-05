
using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Facade.Shop;
using Abc.Infra;
using Abc.Pages.Common;
using System;

namespace Abc.Pages.Shop {
    public class BrandsPage : ViewPage<BrandsPage,IBrandsRepository, Brand, BrandView, BrandData> {
        public BrandsPage(IBrandsRepository r) : base(r, "Brands") { }
            
        protected override void createTableColumns() {
            createColumn(x => Item.Id);
            createColumn(x => Item.Name);
        }

        protected internal override Uri pageUrl() => new Uri("/Shop/Brands", UriKind.Relative);

        protected internal override Brand toObject(BrandView v) => new BrandViewFactory().Create(v);

        protected internal override BrandView toView(Brand o) => new BrandViewFactory().Create(o);
    }

}
