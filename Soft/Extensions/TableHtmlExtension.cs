using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pages;
using System.Collections.Generic;

namespace Soft.Extensions {
    public static class TableHtmlExtension {
        public static IHtmlContent ShowTable<TPage, TData>(this IHtmlHelper<TPage> h,
            IIndexTable<TPage, TData> page) {
            var s = htmlStrings(h, page);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStrings<TPage, TData>(this IHtmlHelper<TPage> h,
            IIndexTable<TPage, TData> page) {
            var l = new List<object> {
                new HtmlString("<table class=\"table\">"),
                new HtmlString("<thead>"),
                new HtmlString("<tr>")
            };
            for (var i = 0; i < page.ColumnsCount; i++) {
                l.Add(new HtmlString("<th>"));
                l.Add(new HtmlString(page.GetName(h, i)));
                l.Add(new HtmlString("</th>"));
            }
            l.Add(new HtmlString("<th></th>"));
            l.Add(new HtmlString("</tr>"));
            l.Add(new HtmlString("</thead>"));
            l.Add(new HtmlString("<tbody>"));
            for (var i = 0; i < page.RowsCount; i++) {
                page.SetItem(i);
                l.Add(new HtmlString("<tr>"));
                for (var j = 0; j < page.ColumnsCount; j++) {
                    l.Add(new HtmlString("<td>"));
                    l.Add(page.GetValue(h, j));
                    l.Add(new HtmlString("</td>"));
                }
                l.Add(new HtmlString("<td>"));
                l.Add(h.Buttons(page.ItemId));
                l.Add(new HtmlString("</td>"));
                l.Add(new HtmlString("</tr>"));
            }
            l.Add(new HtmlString("</tbody>"));
            l.Add(new HtmlString("</table>"));
            return l;
        }
    }
}
