using System.Collections.Generic;

namespace POC.Business.Interface

{
    public interface IRepository<T> where T : class, new()
    {
        T Create(T entity);

        List<T> GetAllData();

        T GetById(int id);

        T Update(T entity);

        bool Delete(int id);
    }
}
