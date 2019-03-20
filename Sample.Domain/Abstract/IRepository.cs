using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Abstract
{
    public interface IRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        IEnumerable<T> List();
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> ListAsync();
        Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate);        
    }
}
