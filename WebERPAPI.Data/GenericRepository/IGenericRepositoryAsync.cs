using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebERPAPI.Data.GenericRepository
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<List<T>> Find(Expression<Func<T, bool>> predicate);

        Task<List<T>> GetAll();

        Task<T> FindOne(Expression<Func<T, bool>> predicate);

        Task<List<T>> FindUsingSP(string query, params object[] parameters);

        Task<T> FindOneUsingSP(string query, params object[] parameters);

        Task<T> Insert(T Entity);

        Task<T> Update(T Entity, Expression<Func<T, bool>> predicate);

        void Delete(Expression<Func<T, bool>> predicate);

        Task<Boolean> ExecuteCommand(string query, params object[] parameters);
    }
}
