using Abc.Data.Common;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pages {
    public abstract class AbstractPage<TPage, TData> : PageModel, IIndexTable<TPage, TData>
        where TPage : PageModel
        where TData : UniqueEntityData {

        private readonly DbContext context;
        private readonly DbSet<TData> set;

        protected AbstractPage(DbContext c, DbSet<TData> s) {
            context = c;
            set = s;
            createTableColumns();
        }

        protected abstract void createTableColumns();

        public List<LambdaExpression> Columns { get; }
            = new List<LambdaExpression>();

        protected void createColumn<TResult>(Expression<Func<TPage, TResult>> e) => Columns.Add(e);

        public IList<TData> Items { get; set; }
        public TData Item { get; set; }

        public async Task OnGetIndexAsync() => Items = await set.ToListAsync();

        public void SetItem(int i) {
            Item = null;
            if (isCorrectIndex(i, Items)) Item = Items[i];
        }

        private bool isCorrectIndex<TList>(int i, IList<TList> l) => i >= 0 && i < l?.Count;

        public virtual string GetName(IHtmlHelper<TPage> html, int i) {
            if (isCorrectIndex(i, Columns))
                return html.DisplayNameFor(Columns[i] as Expression<Func<TPage, string>>);
            return Undefined;
        }

        public virtual IHtmlContent GetValue(IHtmlHelper<TPage> html, int i)
            => html.DisplayFor(Columns[i] as Expression<Func<TPage, string>>);

        public string Caption { get; protected set; }

        public int ColumnsCount => Columns?.Count ?? -1;

        public int RowsCount => Items?.Count ?? -1;

        public string ItemId => Item.Id;

        public string Undefined => "Undefined";
    }
}