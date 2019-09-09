using POC.BusinessEntities;
using System.Collections.Generic;

namespace POC.Business.Interface
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();

    }
}
