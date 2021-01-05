using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Abc.Pages.Common.Extensions {

    public static class EnumHtml {

        public static IHtmlContent EnumEditor<TModel, TResult>(
            this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e) {

            var l = new SelectList(Enum.GetNames(typeof(TResult)));

            var s = htmlStrings(h, e, l);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult>> e, SelectList l) {
            return new List<object> {
                new HtmlString("<div class=\"form-group\">"),
                h.LabelFor(e, new {@class = "text-dark"}),
                h.DropDownListFor(e, l, new {@class = "form-control"}),
                h.ValidationMessageFor(e, "", new {@class = "text-danger"}),
                new HtmlString("</div>")
            };
        }

    }

}