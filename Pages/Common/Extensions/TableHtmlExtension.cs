using Abc.Pages.Common.Aids;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Abc.Pages.Common.Extensions {
    public static class TableHtmlExtension {
        public static IHtmlContent ShowTable<TPage>(this IHtmlHelper<TPage> h,
            IIndexTable<TPage> page, string select = null, string edit = "Edit",
            string details = "Details", string delete = "Delete") {
            var b = new TableButtons(select, edit, details, delete);
            var s = HtmlStrings(h, page, b);
            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlStrings<TPage>(this IHtmlHelper<TPage> h,
            IIndexTable<TPage> page, TableButtons buttons) {
            var l = new List<object> {
                new HtmlString("<body>"),
                new HtmlString("<table class=\"table\">"),
                new HtmlString("<thead>"),
            };
            l.Add(h.Header(GetHeaders(h, page)));
            l.Add(new HtmlString("</thead>"));
            l.Add(new HtmlString("<tbody>"));
            for (int i = 0; i < page.RowsCount; i++) {
                l.Add(new HtmlString("<tr>"));
                page.SetItem(i);
                l.Add(h.Row(
                    buttons,
                    page.PageUrl,
                    page.ItemId,
                    page.SortOrder,
                    page.SearchString,
                    page.PageIndex,
                    page.FixedFilter,
                    page.FixedValue,
                    GetRows(h, page)));
                l.Add(new HtmlString("</tr>"));
            }
            l.Add(new HtmlString("</tbody>"));
            l.Add(new HtmlString("</table>"));
            l.Add(new HtmlString("</body>"));
            return l;
        }

        private static Link[] GetHeaders<TPage>(this IHtmlHelper<TPage> h, IIndexTable<TPage> page) {
            var l = new List<Link>();
            for (var i = 0; i < page.ColumnsCount; i++) {
                l.Add(new Link(page.GetName(h, i), page.GetSortStringExpression(i)));
            }
            return l.ToArray();
        }

        private static IHtmlContent[] GetRows<TPage>(this IHtmlHelper<TPage> h, IIndexTable<TPage> page) {
            var l = new List<IHtmlContent>();
            for (var i = 0; i < page.ColumnsCount; i++) {
                l.Add(page.GetValue(h, i));
            }
            return l.ToArray();
        }
    }
}
