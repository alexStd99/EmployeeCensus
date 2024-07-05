using EmployeeCensus.Domain.Entities;

namespace EmployeeCensus.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }
        IGenericRepository<Department> DepartmentRepository { get; }
        IGenericRepository<ProgrammingLanguage> ProgrammingLanguageRepository { get; }
        IGenericRepository<Experience> ExperienceRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        Task<int> SaveChangesAsync();
    }
}