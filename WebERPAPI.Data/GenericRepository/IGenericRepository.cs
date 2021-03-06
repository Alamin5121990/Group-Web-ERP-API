using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebERPAPI.Data.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> Find(Expression<Func<T, bool>> predicate);

        List<T> GetAll();

        T FindOne(Expression<Func<T, bool>> predicate);

        List<T> FindUsingSP(string query, params object[] parameters);

        T FindOneUsingSP(string query, params object[] parameters);

        T Insert(T obj);

        T Update(T Entity, Expression<Func<T, bool>> predicate);

        void Delete(Expression<Func<T, bool>> predicate);

        Boolean ExecuteCommand(string query, params object[] parameters);
    }
}