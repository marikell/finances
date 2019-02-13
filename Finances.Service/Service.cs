using Finances.Data.Interfaces;
using Finances.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finances.Service
{
    public class Service<T> : IService<T> where T : class
    {
        protected IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void Delete(object key)
        {
            _repository.Delete(key);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll().AsEnumerable();
        }

        public T Get(object key)
        {
            return _repository.Get(key);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}
