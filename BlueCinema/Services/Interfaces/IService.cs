using System;
using System.Collections.Generic;

namespace BlueCinema.Services
{
    public interface IService<T>
    {
        IList<T> GetAll();
        void Add(T obj);
        T GetById(Guid id);
        void Remove(Guid id);
        void Update(T obj);
    }
}
