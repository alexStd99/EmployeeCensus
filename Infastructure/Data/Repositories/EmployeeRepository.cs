using EmployeeCensus.Application.Interfaces;
using EmployeeCensus.Domain.Entities;
using EmployeeCensus.Infastructure.Data.Implementations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCensus.Infastructure.Data.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Employee>> GetEmployeesWhithDepartamentAsync(string? searchTerm) 
            => string.IsNullOrEmpty(searchTerm)
                ? await AsQueryable().Include(x => x.Department).ToListAsync()
                : await AsQueryable().Include(employee => employee.Department)
                    .Where(employee => employee.FirstName.Contains(searchTerm.Trim()) || employee.LastName.Contains(searchTerm.Trim())).ToListAsync();

        public async Task<Employee?> GetEmployeeWhithDepartamentForUpdateAsync(Guid id)
            => await AsQueryable().Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);
    }
}
