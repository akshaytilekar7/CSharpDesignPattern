using System;

namespace POC.BusinessEntities
{
    public class Employee : Salary
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Designation { get; set; }

        public int AddressId { get; set; }

        public int SalaryId { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
