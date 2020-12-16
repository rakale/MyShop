using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Soft.Extensions {
    public static class ButtonsHtml {
        public static IHtmlContent Buttons(this IHtmlHelper h, string id) {
            var s = htmlStrings(h, id);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStrings(IHtmlHelper h, string id) {
            return new List<object> {
                new HtmlString($"<a href=\"./Edit?handler=edit&id={id}\">Edit</a> |"),
                new HtmlString($"<a href=\"./Details?handler=details&id={id}\">Details</a> |"),
                new HtmlString($"<a href=\"./Delete?handler=delete&id={id}\">Delete</a>")
            };
        }
    }
}
