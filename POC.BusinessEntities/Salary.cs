namespace POC.BusinessEntities
{
    public class Salary
    {
        public int Id { get; set; }
        public decimal Basic { get; set; }
        public decimal Incentives { get; set; }
        public decimal Bonus { get; set; }
        public decimal GrossSalary { get; set; }
        public bool IsEven { get; set; }
    }
}
