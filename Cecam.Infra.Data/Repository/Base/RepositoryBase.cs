using Cecam.Domain.Interfaces.Repository.Base;
using Cecam.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Cecam.Infra.Data.Repository.Base
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        protected DbContext Context { get; private set; }

        public RepositoryBase()
        {
            Context = new CecamContext();
        }

        public void Add(T obj)
        {
            Context.Set<T>().Add(obj);
            Context.SaveChanges();
        }

        public void Delete(T obj)
        {
            Context.Set<T>().Remove(obj);
            Context.SaveChanges();
        }
        public void Update(int id, T obj)
        {
            var existingObj = Context.Set<T>().Find(id);
            Context.Entry(existingObj).CurrentValues.SetValues(obj);
            Context.SaveChanges();
        }

        public T GetById(int id) => Context.Set<T>().Find(id);

        public IEnumerable<T> GetAll() => Context.Set<T>().ToList();

        public IEnumerable<T> GetByQuery(Func<T, bool> predicate) => Context.Set<T>().Where(predicate);

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
