namespace POC.Business.Interface
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T : class, new();
    }
}
