using System.Collections.Generic;

namespace EAT.DAL.Interfaces
{
    public interface IRepositorio<T> where T : class, new()
    {
        List<T> GetAll();
        T Get(int entityid);
        void Save(T entity);
        void Update(T entity);
        void Remove(int entityid);
        bool CanRemove(int entityid);
    }
}
