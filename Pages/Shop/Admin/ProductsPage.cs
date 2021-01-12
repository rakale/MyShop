using Abc.Data.Shop;
using Abc.Domain.Shop;
using Abc.Domain.Shop.Model;
using Abc.Domain.Shop.Repositories;
using Abc.Facade.Shop.Factories;
using Abc.Facade.Shop.Views;
using Abc.Pages.Common;
using Abc.Pages.Common.Extensions;
using Abc.Pages.Shop.Base;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Abc.Pages.Shop.Admin {
    public class ProductsPage : ProductsBasePage<ProductsPage> {

        public ProductsPage(IProductsRepository r, ICatalogsRepository c, IBrandsRepository b)
            : base(r,c,b) { }
        }
    }