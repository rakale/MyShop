using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Abc.Pages.Common.Extensions {
    public interface IIndexTable<TPage> {
        int ColumnsCount { get; }
        int RowsCount { get; }
        void SetItem(int i);
        string GetName(IHtmlHelper<TPage> h, int i);
        IHtmlContent GetValue(IHtmlHelper<TPage> h, int i);
        Uri GetSortStringExpression(int i);
        string ItemId { get; }
        Uri PageUrl { get; }
        string SortOrder { get; }
        string SearchString { get; }
        int PageIndex { get; }
        string FixedFilter { get; }
        string FixedValue { get; }
    }
}
