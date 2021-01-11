using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Abc.Pages.Common.Extensions {
    public static class DropDownHtml {
        public static IHtmlContent DropDown<TModel, TResult>(
            this IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult>> e,
            IEnumerable<SelectListItem> items) {

            var s = htmlStrings(h, e, items);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> htmlStrings<TModel, TResult>(
            IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult>> e,
            IEnumerable<SelectListItem> items) {

            return new List<object> {
                new HtmlString("<div class=\"form-group\">"),
                h.LabelFor(e, new {@class = "text-dark"}),
                h.DropDownListFor(e, items, new {@class = "form-control"}),
                h.ValidationMessageFor(e, "", new {@class = "text-danger"}),
                new HtmlString("</div>")
            };
        }

    }
}
