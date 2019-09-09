using POC.Business.DataAccess;
using POC.Business.Interface;

namespace POC.Business.Helper
{
    public class RepoitoryFactory : IRepositoryFactory
    {
        //public IRepository<T> GetRepository<T>() where T : class, new()
        //{
        //    var repo = new Repository<T>();
        //    return repo;
        //}
        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            var repo = new Repository<T>();
            return repo;

        }
    }
}
