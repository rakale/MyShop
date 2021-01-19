using Abc.Domain.Shop.Repositories;
using Abc.Pages.Shop.Base;

namespace Abc.Pages.Shop.Admin {
    public class CatalogsPage : CatalogsBasePage<CatalogsPage> {
        public CatalogsPage(ICatalogsRepository r) : base(r) { }
    }
}