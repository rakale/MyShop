using Abc.Aids.Methods;
using Abc.Data.Common;
using Abc.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Infra.Common {

    public abstract class BaseRepository<TDomain, TData> : ICrudMethods<TDomain>, IRepository
        where TDomain : IEntity<TData>
        where TData : PeriodData, new() {

        protected internal DbContext db;
        protected internal DbSet<TData> dbSet;

        protected BaseRepository(DbContext c, DbSet<TData> s) {
            db = c;
            dbSet = s;
        }

        public virtual async Task<List<TDomain>> Get() {
            var query = createSqlQuery();
            var set = await runSqlQueryAsync(query);

            return toDomainObjectsList(set);
        }

        public async Task<TDomain> Get(string id) {
            if (id is null) return toDomainObject(new TData());

            var d = await getData(id);

            var obj = toDomainObject(d);

            return obj;
        }

        public async Task Delete(string id) {
            if (id is null) return;

            var v = await getData(id);

            if (v is null) return;
            dbSet.Remove(v);
            await db.SaveChangesAsync();
        }

        public async Task Add(TDomain obj) {
            var d = getData(obj);

            if (d is null) return;

            if (isInDatabase(d)) await Update(obj);
            else await dbSet.AddAsync(d);

            await db.SaveChangesAsync();
        }

        public async Task Update(TDomain obj) {
            var d = getData(obj);
            d = copyData(d);
            db.Attach(d).State = EntityState.Modified;

            //TODO Midagi tuleb selle väljakommenteeritud asjadega teha
            //try {
            await db.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException) {
            //    //if (!MeasureViewExists(MeasureView.Id))
            //    //{
            //    //    return NotFound();
            //    //}
            //    //else
            //    //{
            //    throw;
            //    //}
            //}
        }

        public object GetById(string id) => Get(id).GetAwaiter().GetResult();

        protected internal virtual IQueryable<TData> createSqlQuery() {
            var query = from s in dbSet select s;

            return query;
        }

        protected internal abstract TDomain toDomainObject(TData periodData);

        protected abstract Task<TData> getData(string id);

        protected TData getData(TDomain obj) => obj?.Data;

        protected abstract TData getDataById(TData d);

        protected bool isInDatabase(TData d) => getDataById(d) != null;

        internal async Task<List<TData>> runSqlQueryAsync(IQueryable<TData> query)
            => await query.AsNoTracking().ToListAsync();

        internal List<TDomain> toDomainObjectsList(List<TData> set)
            => set.Select(toDomainObject).ToList();

        private TData copyData(TData d) {
            var x = getDataById(d);

            if (x is null) return d;
            Copy.Members(d, x);

            return x;
        }

    }

}