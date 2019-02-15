using Finances.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Finances.Service.Interfaces
{
    public interface IService<T> where T : class
    {
        IException Add(T entity);
        IException Delete(object key);
        IException Update(T entity);
        T Get(object key);
        ICollection<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
    }
}
