using System;
using System.Collections.Generic;

namespace TankMap.DataAccess
{
    public interface IRepository<T>
    {
        IEnumerable<T> All();
        IEnumerable<T> Where(Func<T, bool> predicate);
        T SingleOrDefault(Func<T, bool> predicate);
        void Save(T entity);
        void Delete(T entity);
        int Count(Func<T, bool> predicate);
    }
}