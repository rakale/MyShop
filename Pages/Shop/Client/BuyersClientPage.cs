using Abc.Aids.Reflection;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Facade.Shop.Views;
using Abc.Pages.Shop.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Abc.Pages.Shop.Client {
    [Authorize]
    public sealed class BuyersClientPage : BuyersBasePage<BuyersClientPage> {
        public BuyersClientPage(IBuyersRepository r) : base(r, "My data") { }
        protected internal override Uri pageUrl() => new Uri("/Client/Buyers", UriKind.Relative);
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate) {
            Item = new BuyerView {
                Id = User.Identity.Name
            };
            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }

        public override async Task OnGetIndexAsync(string sortOrder,
            string id, string currentFilter, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue) {
            fixedFilter = GetMember.Name<BuyerView>(x => x.Id);
            fixedValue = User.Identity.Name;
            await base.OnGetIndexAsync(sortOrder, id, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue);
        }

        public bool HasData() {
            var userId = User.Identity.Name;
            var o = db.GetById(userId) as Buyer;
            return o.Id == userId;
        }
    }
}
