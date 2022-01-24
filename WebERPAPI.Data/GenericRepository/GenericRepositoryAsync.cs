using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.Data.GenericRepository
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _table;

        public GenericRepositoryAsync(DbContext context)
        {
            this._context = context;
            this._context.Configuration.LazyLoadingEnabled = false;
            this._table = context.Set<T>();
        }

        public async void Delete(Expression<Func<T, bool>> predicate)
        {
            T existing = await _table.FindAsync(predicate);
            _table.Remove(existing);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExecuteCommand(string query, params object[] parameters)
        {
            _ = await _context.Database.ExecuteSqlCommandAsync(query, parameters);
            return true;
        }

        public async Task<List<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _table.Where(predicate).ToListAsync();
        }

        public async Task<T> FindOne(Expression<Func<T, bool>> predicate)
        {
            return await _table.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> FindOneUsingSP(string query, params object[] parameters)
        {
            return await _context.Database.SqlQuery<T>(query, parameters).FirstOrDefaultAsync();
        }

        public async Task<List<T>> FindUsingSP(string query, params object[] parameters)
        {
            return await _context.Database.SqlQuery<T>(query, parameters).ToListAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> Insert(T Entity)
        {
            _table.Add(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }

        public async Task<T> Update(T Entity, Expression<Func<T, bool>> predicate)
        {
            T value = await _table.FirstOrDefaultAsync(predicate);
            _context.Entry(value).CurrentValues.SetValues(Entity);
            await _context.SaveChangesAsync();
            return Entity;
        }
    }
}
