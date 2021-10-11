using System;
using System.Collections.Generic;

namespace Cecam.Domain.Interfaces.Repository.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T obj);

        void Update(int id, T obj);

        void Delete(T obj);

        T GetById(int id);

        IEnumerable<T> GetAll();

        //Pode-se utilizar este método para aquisição de resultado mediante a uma busca por Linq
        IEnumerable<T> GetByQuery(Func<T, bool> predicate);
    }
}
