using Finances.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Finances.Data.Repositories
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        private FinancesDbContext _context;

        public Repository(FinancesDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(object key)
        {
            var entity = _context.Set<T>().Find(key);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public T Get(object key)
        {
            return _context.Set<T>().Find(key);
        }
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
