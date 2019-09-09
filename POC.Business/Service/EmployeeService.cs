using POC.Business.Interface;
using POC.BusinessEntities;
using System.Collections.Generic;

namespace POC.Business.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IActionFactory _actionFactory;
        private readonly IRepositoryFactory _repositoryFactory;

        public EmployeeService(IActionFactory actionFactory, IRepositoryFactory repositoryFactory)
        {
            _actionFactory = actionFactory;
            _repositoryFactory = repositoryFactory;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = _repositoryFactory.GetRepository<Employee>().GetAllData();
            return employees;
        }

        public Employee AddEmployees(Employee employee, Address address)
        {

            employee.FullName = employee.FirstName + " " + employee.LastName;
            employee.CreatedDate = StaticHelperSer.GetCurrentDate();
            var add = _actionFactory.AddressService.GetAdreessById(employee.AddressId);
            var data = _actionFactory.AddressService.Create(address);
            employee.Designation = add.Landmark;
            _repositoryFactory.GetRepository<Employee>().Create(employee);
            return employee;
        }

    }
}
