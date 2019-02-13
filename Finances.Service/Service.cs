using Finances.Data.Interfaces;
using Finances.Data.Models;
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

        public IException Add(T entity)
        {
            IException exception = new ExceptionResult();
            try
            {
                _repository.Add(entity);
            }
            catch (Exception e)
            {
                exception.SetException(e);
            }

            return exception;
        }

        public IException Delete(object key)
        {
            IException exception = new ExceptionResult();
            try
            {
                _repository.Delete(key);
            }
            catch (Exception e)
            {
                exception.SetException(e);
            }

            return exception;
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll().AsEnumerable();
        }

        public T Get(object key)
        {
            return _repository.Get(key);
        }

        public IException Update(T entity)
        {
            IException exception = new ExceptionResult();
            try
            {
                _repository.Update(entity);
            }
            catch (Exception e)
            {
                exception.SetException(e);
            }

            return exception;
        }
    }
}
