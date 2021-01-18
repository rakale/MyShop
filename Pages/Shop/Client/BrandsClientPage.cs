using Abc.Aids.Reflection;
using Abc.Data.Shop;
using Abc.Domain.Shop.Repositories;
using Abc.Pages.Shop.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Abc.Pages.Shop.Client {
    [Authorize]
    public class BrandsClientPage : BrandsBasePage<BrandsClientPage> {
        protected internal override Uri pageUrl() => new Uri("/Client/Brands", UriKind.Relative);
        public BrandsClientPage(IBrandsRepository r) : base(r) { }
        protected override void createTableColumns() {
            createColumn(x => Item.Code);
            createColumn(x => Item.Name);
        }

        public override async Task<IActionResult> OnGetDetailsAsync(string id, string sortOrder, string searchString,
            int pageIndex,
            string fixedFilter, string fixedValue) {
            var name = GetMember.Name<ProductData>(x => x.BrandId);
            var page = "/Client/Products";
            var url = new Uri($"{page}/Index?handler=Index&fixedFilter={name}&fixedValue={id}",
                UriKind.Relative);
            await Task.CompletedTask.ConfigureAwait(false);
            return Redirect(url.ToString());
        }
    }
}
