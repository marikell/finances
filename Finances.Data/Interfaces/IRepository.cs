using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finances.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(object key);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
