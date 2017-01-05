using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PluralSightBook.Data.Models;
using PluralSightBook.Data;

namespace PluralSightBook.IntegrationTests.Spikes.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext _context;
        protected DbContext context
        {
            get
            {
                return _context;
            }
        }

        public Repository(DbContext context)
        {
            this._context = context;
        }

        public Repository()
        {
            this._context = new PluralSightBookContext();
        }

        public IEnumerable<T> GetAll()
        {
            return this._context.Set<T>();
        }

        public T GetById(int id)
        {
            return this._context.Set<T>().Find(id);
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> filter)
        {
            return this._context.Set<T>().Where(filter);
        }

        public void Add(T entity)
        {
            this._context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            this._context.Entry(entity).State = System.Data.EntityState.Modified;
        }

        public void Save()
        {
            this._context.SaveChanges();
        }
    }
}