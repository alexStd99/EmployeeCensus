using EmployeeCensus.Domain.Enums;

namespace EmployeeCensus.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}