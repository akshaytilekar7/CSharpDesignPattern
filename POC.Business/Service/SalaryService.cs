using POC.Business.Helper;
using POC.Business.Interface;
using POC.BusinessEntities;
using System;
using System.Linq;

namespace POC.Business.Service
{
    public class SalaryService : ISalaryService
    {

        private readonly IActionFactory _actionFactory;
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly HelperSer _helperSer;

        public SalaryService(IActionFactory actionFactory, IRepositoryFactory repositoryFactory, HelperSer HelperSer)
        {
            _actionFactory = actionFactory;
            _repositoryFactory = repositoryFactory;
            _helperSer = HelperSer;
        }

        public Salary GetSalaryByEmployeeId(int id)
        {
            var employee = _actionFactory.EmployeeService.GetAllEmployees().FirstOrDefault(x => x.Id == id);
            if (employee == null)
                throw new Exception(POCConstants.EmployeeNotFound);

            var salary = _repositoryFactory.GetRepository<Salary>().GetById(employee.SalaryId);
            salary.GrossSalary = CalculateGrossSalary(salary);
            salary.IsEven = IsSalaryEven(Convert.ToInt32(salary.GrossSalary));
            return salary;
        }

        public Salary AddSalary(Salary salary)
        {
            salary = _repositoryFactory.GetRepository<Salary>().Create(salary);
            return salary;
        }

        private decimal CalculateGrossSalary(Salary salary)
        {
            return salary.Basic + salary.Incentives + salary.Bonus;
        }

        public bool IsSalaryEven(int sal)
        {
            return _helperSer.IsEven(Convert.ToInt32(sal));
        }
    }
}
