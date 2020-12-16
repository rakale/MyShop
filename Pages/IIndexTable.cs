using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pages {
    public interface IIndexTable<TPage, TData> {
        int ColumnsCount { get; }
        int RowsCount { get; }
        void SetItem(int i);
        string ItemId { get; }
        string GetName(IHtmlHelper<TPage> h, int i);
        IHtmlContent GetValue(IHtmlHelper<TPage> h, int i);
    }
}
