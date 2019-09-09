namespace POC.Business.Interface
{
    public interface IActionFactory
    {
        IEmployeeService EmployeeService { get; }

        IAddressService AddressService { get; }

        ISalaryService SalaryService { get; }
    }
}
