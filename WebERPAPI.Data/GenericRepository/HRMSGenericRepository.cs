using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using WebERPAPI.Data.Models.PROCESSERVER;

namespace WebERPAPI.Data.GenericRepository
{
    public class HRMSGenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbContext context = null;
        private DbSet<T> table = null;

        public HRMSGenericRepository()
        {
            this.context = new HRMSEntities();
            this.context.Database.CommandTimeout = 240;
            this.context.Configuration.LazyLoadingEnabled = false;
            this.table = context.Set<T>();
        }

        // DELETE
        public void Delete(Expression<Func<T, bool>> predicate)
        {
            T existing = table.Find(predicate);
            table.Remove(existing);
            context.SaveChanges();
        }
        public void DeleteAll(Expression<Func<T, bool>> predicate)
        {
            List<T> existing = table.Where(predicate).ToList();
            if (existing != null)
            {
                foreach (var tbl in existing) table.Remove(tbl);
            }
            //context.SaveChanges();
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

        // STORED PROCESDURE
        public List<T> FindUsingSP(string query, params object[] parameters)
        {
            return context.Database.SqlQuery<T>(query, parameters).ToList<T>();
        }

        public T FindOneUsingSP(string query, params object[] parameters)
        {
            return context.Database.SqlQuery<T>(query, parameters).FirstOrDefault();
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

        public bool ExecuteCommand(string query, params object[] parameters)
        {
            context.Database.ExecuteSqlCommand(query, parameters);
            return true;
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }
    }
}