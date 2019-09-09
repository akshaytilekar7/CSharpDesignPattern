using POC.Business.Interface;
using System.Collections.Generic;

namespace POC.Business.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class, new()//EntityAction<T>,
    {
        public T Create(T entity)
        {
            //actual DB call 
            return entity;
        }

        public T GetById(int id)
        {
            //actual DB call 
            return new T();
        }

        public List<T> GetAllData()
        {
            //actual DB call 
            return new List<T>();
        }

        public T Update(T entity)
        {
            //actual DB call 
            return entity;
        }

        public bool Delete(int id)
        {
            //actual DB call 
            return true;
        }
    }
}
