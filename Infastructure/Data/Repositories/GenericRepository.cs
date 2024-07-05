using EmployeeCensus.Application.Interfaces;
using EmployeeCensus.Domain.Entities;
using EmployeeCensus.Infastructure.Data.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeeCensus.Infastructure.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public void DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Update(entity);
        }

        public async Task<(IEnumerable<TSource> PaginatedCollection, int TotalCount)> ApplyPagination<TSource>(IQueryable<TSource> rows, int pageSize, int pageNumber)
        {
            var paginatedCollection = await rows.Skip(pageSize * pageNumber).Take(pageSize).ToListAsync();
            return (paginatedCollection, rows.Count());
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return _dbSet;
        }

        public virtual IQueryable<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> expression)
        {
            return _dbSet.Include(expression);
        }

        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            var query = Filter(_dbSet, filter);
            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            IQueryable<TEntity> query = _dbSet;
            query = Filter(query, filter);
            return await query.ToListAsync();
        }
        public virtual IEnumerable<TEntity> WhereLazy(Expression<Func<TEntity, bool>>? filter = null)
        {
            IQueryable<TEntity> query = _dbSet;
            query = Filter(query, filter);
            return query;
        }

        private IQueryable<TEntity> Filter(IQueryable<TEntity> data, Expression<Func<TEntity, bool>>? filter) =>
            filter == null ? data : data.Where(filter);


    }
}