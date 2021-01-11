using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Abc.Pages.Common.Extensions {
    public static class ShowImageHtmlExtension {
        public static IHtmlContent DisplayImageFor(
            this IHtmlHelper h, string value, int height = 75) {
            var s = htmlStrings(value, height);
            return new HtmlContentBuilder(s);
        }

        public static IHtmlContent DisplayImageFor<TModel, TResult>(
            this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e, int height = 75) {
            if (h == null) throw new ArgumentNullException(nameof(h));
            var s = htmlStrings(h, e, height);
            return new HtmlContentBuilder(s);
        }

        internal static List<object> htmlStrings(string value, int height) {
            var l = new List<object> { new HtmlString(img(value, height)) };
            return l;
        }

        internal static List<object> htmlStrings<TModel, TResult>(
            IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult>> e, int height) {

            return new List<object> {
                new HtmlString("<dt class=\"col-sm-2\">"),
                h.DisplayNameFor(e),
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                getImage(h, e, height),
                new HtmlString("</dd>")
            };
        }

        private static HtmlString getImage<TModel, TResult>(IHtmlHelper<TModel> h,
            Expression<Func<TModel, TResult>> e, int height) {
            var value = h.ValueFor(e);
            return new HtmlString(img(value, height));
        }

        private static string img(string value, int height)
            => $"<img src=\"{value}\" alt=\"uu\" style=\"height: {height}px\"/>";
    }
}
