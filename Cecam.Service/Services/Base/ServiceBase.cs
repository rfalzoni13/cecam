using Cecam.Domain.Interfaces.Repository.Base;
using Cecam.Domain.Interfaces.Service.Base;
using System;
using System.Collections.Generic;

namespace Cecam.Service.Services.Base
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repositoryBase;

        public ServiceBase(IRepositoryBase<T> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public void Add(T obj)
        {
            _repositoryBase.Add(obj);
        }

        public void Delete(T obj)
        {
            _repositoryBase.Delete(obj);
        }

        public void Update(int id, T obj)
        {
            _repositoryBase.Update(id, obj);
        }

        public IEnumerable<T> GetAll() => _repositoryBase.GetAll();

        public T GetById(int id) => _repositoryBase.GetById(id);

        public IEnumerable<T> GetByQuery(Func<T, bool> predicate) => GetByQuery(predicate);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
