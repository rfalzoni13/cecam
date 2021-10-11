using System;
using System.Collections.Generic;

namespace Cecam.Domain.Interfaces.Service.Base
{
    public interface IServiceBase<T> : IDisposable where T : class
    {
        void Add(T obj);

        void Update(int id, T obj);

        void Delete(T obj);

        T GetById(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetByQuery(Func<T, bool> predicate);

    }
}
