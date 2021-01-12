using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Facade.Shop.Factories;
using Abc.Facade.Shop.Views;
using Abc.Pages.Common;
using Abc.Pages.Shop.Base;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;

namespace Abc.Pages.Shop.Admin {
    public class CatalogsPage : CatalogsBasePage<CatalogsPage> {
        public CatalogsPage(ICatalogsRepository r) : base(r) { }
    }
}