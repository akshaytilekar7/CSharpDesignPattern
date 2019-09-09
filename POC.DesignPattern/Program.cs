using POC.Business.Helper;
using POC.Business.Service;

namespace POC.DesignPattern
{
    class Program
    {
        public static void Main()
        {
            var actionFactory = new ActionFactory();
            var repositoryFactory = new RepoitoryFactory();
            EmployeeService employeeService = new EmployeeService(actionFactory, repositoryFactory);
        }
    }
}
