using Abc.Domain.Shop.Repositories;
using Abc.Pages.Shop.Base;
using System;

namespace Abc.Pages.Shop.Admin {
    public sealed class BuyersPage : BuyersBasePage<BuyersPage> {
        public BuyersPage(IBuyersRepository r) : base(r, "Buyers") { }
        protected internal override Uri pageUrl() => new Uri("/Shop/Buyers", UriKind.Relative);
    }
}
