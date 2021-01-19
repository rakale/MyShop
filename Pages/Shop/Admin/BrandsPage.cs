using Abc.Domain.Shop.Repositories;
using Abc.Pages.Shop.Base;
using System;

namespace Abc.Pages.Shop.Admin {
    public class BrandsPage : BrandsBasePage<BrandsPage> {
        protected internal override Uri pageUrl() => new Uri("/Shop/Brands", UriKind.Relative);
        public BrandsPage(IBrandsRepository r) : base(r) { }
    }
}
