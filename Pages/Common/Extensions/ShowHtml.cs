using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Abc.Pages.Common.Extensions {

    public static class ShowHtml {

        public static IHtmlContent Show<TModel, TResult>(
            this IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult>> e) {
            if (h == null) throw new ArgumentNullException(nameof(h));

            var s = htmlStrings(h, e);

            return new HtmlContentBuilder(s);
        }

        public static IHtmlContent Show<TModel, TResult>(
            this IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult>> e,
            object value) {
            if (h == null) throw new ArgumentNullException(nameof(h));

            var s = htmlStrings(h, e, value.ToString());

            return new HtmlContentBuilder(s);
        }

        public static IHtmlContent ShowCaption<TModel, TResult>(
            this IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult>> e,
            string caption) {

            if (h == null) throw new ArgumentNullException(nameof(h));

            var s = htmlStringsCaption(h, e, caption);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> htmlStrings<TModel, TResult>(
            IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult>> e) {

            return new List<object> {
                new HtmlString("<dt class=\"col-sm-2\">"),
                h.DisplayNameFor(e),
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                h.DisplayFor(e),
                new HtmlString("</dd>")
            };
        }

        internal static List<object> htmlStrings<TModel, TResult>(
            IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult>> e,
            string value) {

            return new List<object> {
                new HtmlString("<dt class=\"col-sm-2\">"),
                h.DisplayNameFor(e),
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                h.Raw(value),
                new HtmlString("</dd>")
            };
        }

        internal static List<object> htmlStringsCaption<TModel, TResult>(
            IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult>> e,
            string caption) {

            return new List<object> {
                new HtmlString("<dt class=\"col-sm-2\">"),
                h.Label(caption),
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                h.DisplayFor(e),
                new HtmlString("</dd>")
            };
        }


    }

}
