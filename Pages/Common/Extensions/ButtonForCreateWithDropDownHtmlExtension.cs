using Abc.Pages.Common.Consts;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Abc.Pages.Common.Extensions {

    public static class ButtonForCreateWithDropDownHtmlExtension {

        public static IHtmlContent ShowCreateDropDown<TPage, TEnum>(this IHtmlHelper<TPage> h,
            IButtonForCreateDropDown<TPage, TEnum> page) {
            var s = HtmlStrings(page);
            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlStrings<TPage, TEnum>(IButtonForCreateDropDown<TPage, TEnum> page) {

            var l = new List<object>();
            l.Add(new HtmlString("<div class=\"dropdown\">"));
            l.Add(new HtmlString($"<button class=\"btn btn-link\" id=\"dropdownMenuButton\" data-toggle=\"dropdown\">{Captions.Create}</button>"));
            l.Add(new HtmlString("<div class=\"dropdown-menu\" aria-labelledby=\"dropdownMenuButton\">"));

            for (int i = 0; i < page.DropDownEntryCount; i++) {
                l.Add(new HtmlString(GetDropDownRow(i, page)));
            }
            l.Add(new HtmlString("</div>"));
            l.Add(new HtmlString("</div>"));

            return l;
        }

        internal static string GetDropDownRow<TPage, TEnum>(int i, IButtonForCreateDropDown<TPage, TEnum> page) {
            var s = "<a class=\"dropdown-item\" " +
                $"href=\"{page.GetDropDownEntryUri(i)}\">" +
                $"{page.GetDropDownEntryName(i)}</a>";
            return s;
        }
    }
}
