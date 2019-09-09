using POC.BusinessEntities;

namespace POC.Business.Interface
{
    public interface ISalaryService
    {
        //decimal CalculateGrossSalary();

        Salary AddSalary(Salary salary);

        Salary GetSalaryByEmployeeId(int id);

        bool IsSalaryEven(int sal);

    }
}
