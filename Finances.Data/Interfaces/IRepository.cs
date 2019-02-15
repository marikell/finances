using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Finances.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(object key);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Delete(object key);
        void Update(T entity);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
