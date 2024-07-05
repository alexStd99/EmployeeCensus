using EmployeeCensus.Domain.Enums;

namespace EmployeeCensus.Application.Employees.Models
{
    public class UpdateEmployeeDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
