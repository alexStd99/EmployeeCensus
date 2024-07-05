using EmployeeCensus.Domain.Entities;
using System.Linq.Expressions;

namespace EmployeeCensus.Application.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> expression = null);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Update(TEntity entity);
        Task InsertAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
        IQueryable<TEntity> AsQueryable();
        IEnumerable<TEntity> WhereLazy(Expression<Func<TEntity, bool>>? filter = null);
        IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> expression);
    }
}