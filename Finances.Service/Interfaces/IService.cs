using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Service.Interfaces
{
    public interface IService<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
    }
}
