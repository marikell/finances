using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Service.Interfaces
{
    public interface IService<T> where T : class
    {
        void Add(T entity);
        void Delete(object key);
        void Update(T entity);
        T Get(object key);
        IEnumerable<T> GetAll();
    }
}
