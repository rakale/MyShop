using Abc.Pages.Common.Aids;
using Abc.Pages.Common.Consts;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Abc.Pages.Common.Extensions {


    public static class RowHtml {

        public static IHtmlContent Row(
            this IHtmlHelper h,
            bool hasSelect,
            Uri pageUrl,
            string itemId,
            params IHtmlContent[] values) {
            if (h == null) throw new ArgumentNullException(nameof(h));

            var a = new Args(pageUrl, itemId);

            return row(hasSelect, a, values);
        }

        public static IHtmlContent Row(
            this IHtmlHelper h,
            bool hasSelect,
            Uri pageUrl,
            string itemId,
            string fixedFilter,
            string fixedValue,
            params IHtmlContent[] values) {

            if (h == null) throw new ArgumentNullException(nameof(h));

            var a = new Args(pageUrl, itemId, fixedFilter, fixedValue);

            return row(hasSelect, a, values);
        }


        public static IHtmlContent Row(
            this IHtmlHelper h,
            bool hasSelect,
            Uri pageUrl,
            string itemId,
            string sortOrder,
            string searchString,
            int pageIndex,
            string fixedFilter,
            string fixedValue,
            params IHtmlContent[] values) {

            if (h == null) throw new ArgumentNullException(nameof(h));

            var a = new Args(pageUrl, itemId, fixedFilter, fixedValue, sortOrder, searchString, pageIndex);

            return row(hasSelect, a, values);
        }
        public static IHtmlContent Row(
            this IHtmlHelper h,
            bool hasSelect,
            bool hasEdit,
            bool hasDetails,
            bool hasDelete,
            Uri pageUrl,
            string itemId,
            string sortOrder,
            string searchString,
            int pageIndex,
            string fixedFilter,
            string fixedValue,
            params IHtmlContent[] values) {

            if (h == null) throw new ArgumentNullException(nameof(h));

            var a = new Args(pageUrl, itemId, fixedFilter, fixedValue, sortOrder, searchString, pageIndex);

            return row(hasSelect, hasEdit, hasDetails, hasDelete, a, values);
        }

        internal static IHtmlContent row(bool hasSelect, Args a, params IHtmlContent[] values) {
            var s = htmlStrings(hasSelect, a, values);

            return new HtmlContentBuilder(s);
        }
        internal static IHtmlContent row(bool hasSelect, bool hasEdit, bool hasDetails, bool hasDelete, Args a, params IHtmlContent[] values) {
            var s = htmlStrings(hasSelect, hasEdit, hasDetails, hasDelete, a, values);

            return new HtmlContentBuilder(s);
        }

        internal static List<object> htmlStrings(bool hasSelect, bool hasEdit, bool hasDetails, bool hasDelete, Args a,
            params IHtmlContent[] values) {
            var list = new List<object>();
            foreach (var value in values) addValue(list, value);
            list.Add(new HtmlString("<td>"));
            var hasButton = false;
            if (hasSelect) {
                list.Add(new HtmlString(Href.Compose(a, Actions.Index, Captions.Select)));
                hasButton = true;
            }

            if (hasEdit) {
                if (hasButton) list.Add(" | ");
                list.Add(new HtmlString(Href.Compose(a, Actions.Edit, Captions.Edit)));
                hasButton = true;
            }

            if (hasDetails) {
                if (hasButton) list.Add(" | ");
                list.Add(new HtmlString(Href.Compose(a, Actions.Details, Captions.Details)));
                hasButton = true;
            }

            if (hasDelete) {
                if (hasButton) list.Add(" | ");
                list.Add(new HtmlString(Href.Compose(a, Actions.Delete, Captions.Delete)));
                list.Add(new HtmlString("</td>"));
            }

            return list;
        }

        internal static List<object> htmlStrings(bool hasSelect, Args a, params IHtmlContent[] values) {
            var list = new List<object>();
            foreach (var value in values) addValue(list, value);
            list.Add(new HtmlString("<td>"));

            if (hasSelect) {
                list.Add(new HtmlString(Href.Compose(a, Actions.Index, Captions.Select)));
                list.Add(" | ");
            }

            list.Add(new HtmlString(Href.Compose(a, Actions.Edit, Captions.Edit)));
            list.Add(" | ");
            list.Add(new HtmlString(Href.Compose(a, Actions.Details, Captions.Details)));
            list.Add(" | ");
            list.Add(new HtmlString(Href.Compose(a, Actions.Delete, Captions.Delete)));
            list.Add(new HtmlString("</td>"));

            return list;
        }

        internal static void addValue(List<object> htmlStrings, IHtmlContent value) {
            if (htmlStrings is null) return;
            if (value is null) return;
            htmlStrings.Add(new HtmlString("<td>"));
            htmlStrings.Add(value);
            htmlStrings.Add(new HtmlString("</td>"));
        }

    }

}
