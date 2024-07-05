namespace EmployeeCensus.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public int Floor { get; set; }
    }
}