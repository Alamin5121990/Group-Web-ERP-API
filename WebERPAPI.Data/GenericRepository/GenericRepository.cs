using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace WebERPAPI.Data.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbContext context = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            this.context = context;
            this.context.Configuration.LazyLoadingEnabled = false;
            this.table = this.context.Set<T>();
        }

        //public GenericRepository(DbContext context)
        //{
        //    this.context = context;
        //    this.context.Configuration.LazyLoadingEnabled = false;
        //    this.table = context.Set<T>();
        //}

        // DELETE
        public void Delete(Expression<Func<T, bool>> predicate)
        {
            T existing = table.Find(predicate);
            table.Remove(existing);
            context.SaveChanges();
        }

        // READ
        public List<T> Find(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate).ToList();
        }

        public T FindOne(Expression<Func<T, bool>> predicate)
        {
            return table.FirstOrDefault(predicate);
        }

        public T FindOneUsingSP(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public List<T> FindUsingSP(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Boolean ExecuteCommand(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        // INSERT
        public T Insert(T Entity)
        {
            table.Add(Entity);
            context.SaveChanges();
            return Entity;
        }

        // UPDATE
        public T Update(T Entity, Expression<Func<T, bool>> predicate)
        {
            var originalValues = FindOne(predicate);
            context.Entry(originalValues).CurrentValues.SetValues(Entity);
            context.SaveChanges();
            return originalValues;
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }
    }
}