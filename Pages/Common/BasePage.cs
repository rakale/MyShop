using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Abc.Aids.Reflection;
using Abc.Domain.Common;
using Abc.Facade.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abc.Pages.Common {

    public abstract class BasePage<TRepository, TDomain, TView, TData> :
        PageModel
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging {

        protected TRepository db { get; }

        protected internal BasePage(TRepository r) => db = r;

        public string SortOrder {
            get => db.SortOrder;
            set => db.SortOrder = value;
        }
        public string SearchString {
            get => db.SearchString;
            set => db.SearchString = value;
        }
        public string CurrentFilter {
            get => db.CurrentFilter;
            set => db.CurrentFilter = value;
        }
        public string FixedValue {
            get => db.FixedValue;
            set => db.FixedValue = value;
        }
        public bool HasFixedFilter => !string.IsNullOrWhiteSpace(FixedFilter);

        public string FixedFilter {
            get => db.FixedFilter;
            set => db.FixedFilter = value;
        }

        protected internal void setFixedFilter(string fixedFilter, string fixedValue) {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
        }

        protected internal abstract void setPageValues(string sortOrder, string searchString, in int? pageIndex);

        public Uri GetSortString(Expression<Func<TData, object>> e, Uri page) {
            var name = GetMember.Name(e);
            var sortOrder = getSortOrder(name);

            return new Uri(
                $"{page}?handler=Index&sortOrder={sortOrder}&currentFilter={CurrentFilter}&searchString={SearchString}"
                + $"&fixedFilter={FixedFilter}&fixedValue={FixedValue}", UriKind.Relative);
        }

        protected internal virtual string getSortOrder(string name) {
            if (string.IsNullOrEmpty(SortOrder)) return name;
            if (!SortOrder.StartsWith(name, StringComparison.InvariantCulture)) return name;
            if (SortOrder.EndsWith("_desc", StringComparison.InvariantCulture)) return name;

            return name + "_desc";
        }

        internal static string
            getCurrentFilter(string currentFilter, string searchString, ref int? pageIndex) {
            if (searchString != currentFilter) { pageIndex = 1; }

            return searchString;

        }

        internal static void loadDetails<TDetailObj, TDetailView, TMasterView>(IList<TDetailView> list,
            IRepository<TDetailObj> data, TMasterView item,
            string filter, Func<TDetailObj, TDetailView> create)
            where TMasterView : PeriodView {

            loadDetails(list, data, item?.GetId(), filter, create);
        }

        internal static void loadDetails<TDetailObj, TDetailView>(IList<TDetailView> list,
            IRepository<TDetailObj> data, string value,
            string filter, Func<TDetailObj, TDetailView> create) {
            list.Clear();
            if (value is null) return;

            data.FixedFilter = filter;
            data.FixedValue = value;
            var l = data.Get().GetAwaiter().GetResult();

            foreach (var e in l) { list.Add(create(e)); }
        }

    }

}
