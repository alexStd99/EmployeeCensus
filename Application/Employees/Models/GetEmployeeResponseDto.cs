using EmployeeCensus.Domain.Enums;

namespace EmployeeCensus.Application.Employees.Models
{
    public class GetEmployeeResponseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string DepartmentName { get; set; }
    }
}
