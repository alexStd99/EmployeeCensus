using EmployeeCensus.Domain.Entities;

namespace EmployeeCensus.Application.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeesWhithDepartamentAsync(string? searchTerm);
        Task <Employee?> GetEmployeeWhithDepartamentForUpdateAsync(Guid id);
    }
}
