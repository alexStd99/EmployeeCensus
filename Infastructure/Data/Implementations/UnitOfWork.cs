using EmployeeCensus.Domain.Entities;
using EmployeeCensus.Application.Interfaces;
using EmployeeCensus.Infastructure.Data.Repositories;

namespace EmployeeCensus.Infastructure.Data.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IEmployeeRepository _employees;
        private IGenericRepository<Department> _departments;
        private IGenericRepository<ProgrammingLanguage> _programmingLanguages;
        private IGenericRepository<Experience> _experiences;
        private IGenericRepository<User> _users;
        private bool _disposed = false;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEmployeeRepository EmployeeRepository => _employees ??= new EmployeeRepository(_context);
        public IGenericRepository<Department> DepartmentRepository => _departments ??= new GenericRepository<Department>(_context);
        public IGenericRepository<ProgrammingLanguage> ProgrammingLanguageRepository => _programmingLanguages ??= new GenericRepository<ProgrammingLanguage>(_context);
        public IGenericRepository<Experience> ExperienceRepository => _experiences ??= new GenericRepository<Experience>(_context);
        public IGenericRepository<User> UserRepository => _users ??= new GenericRepository<User>(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                //освобождение упарвляемых ресурсов

            _context.Dispose();
            _disposed = true;
        }
        ~UnitOfWork() 
        {
            Dispose(false); 
        }
    }
}