using POC.Business.Interface;

namespace POC.Business.Helper
{
    public class ActionFactory : IActionFactory
    {
        private IEmployeeService _employeeService;
        private IAddressService _addressService;
        private ISalaryService _salaryService;

        public IEmployeeService EmployeeService
        {
            get
            {
                //if (_employeeService == null)
                //    _employeeService = new EmployeeService();

                return _employeeService;
            }

        }

        public IAddressService AddressService
        {
            get
            {
                //if (_employeeService == null)
                //    _employeeService = new EmployeeService();

                return _addressService;
            }

        }

        public ISalaryService SalaryService
        {
            get
            {
                //if (_employeeService == null)
                //    _employeeService = new EmployeeService();

                return _salaryService;
            }

        }

    }
}
