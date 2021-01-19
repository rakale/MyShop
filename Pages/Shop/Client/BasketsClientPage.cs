using Abc.Aids.Reflection;
using Abc.Data.Shop;
using Abc.Domain.Shop.Repositories;
using Abc.Pages.Shop.Base;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace Abc.Pages.Shop.Client {
    public class BasketsClientPage : BasketsBasePage<BasketsClientPage> {
        public BasketsClientPage(IBasketsRepository r) : base(r) { }
        protected internal override Uri pageUrl() => new Uri("/Client/Baskets", UriKind.Relative);
        public override async Task OnGetIndexAsync(string sortOrder,
           string id, string currentFilter, string searchString, int? pageIndex,
           string fixedFilter, string fixedValue) {
            SelectedId = id;
            fixedFilter = GetMember.Name<BasketData>(x => x.BuyerId);
            fixedValue = User.Identity.Name;
            await getList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue).ConfigureAwait(true);
        }
        public override async Task<IActionResult> OnGetDetailsAsync(string id, string sortOrder, string searchString,
            int pageIndex,
            string fixedFilter, string fixedValue) {
            var name = GetMember.Name<BasketItemData>(x => x.BasketId);
            var page = "/Client/BasketItems";
            var url = new Uri($"{page}/Index?handler=Index&fixedFilter={name}&fixedValue={id}",
                UriKind.Relative);

            await Task.CompletedTask.ConfigureAwait(false);

            return Redirect(url.ToString());
        }
        protected override void createTableColumns() {
            createColumn(x => Item.BuyerName);
            createColumn(x => Item.BuyerAddress);
            createColumn(x => Item.TotalPrice);
            createColumn(x => Item.From);
            createColumn(x => Item.Closed);
        }
    }
}
