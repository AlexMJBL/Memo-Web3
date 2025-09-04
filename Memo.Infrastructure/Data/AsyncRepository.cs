using MemoApp.ApplicationCore.Entities;
using MemoApp.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MemoApp.Infrastructure.Data
{
    public class AsyncRepository<TBaseEntity, TKey> : IAsyncRepository<TBaseEntity, TKey> where TBaseEntity : BaseEntity<TKey>
    {
        protected readonly MemoContext _dbContext;

        public AsyncRepository(MemoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(TBaseEntity entity)
        {
            await _dbContext.Set<TBaseEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TBaseEntity entity)
        {
            _dbContext.Set<TBaseEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAsync(TBaseEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<TBaseEntity> GetByIdAsync(TKey id)
        {
            return await _dbContext.Set<TBaseEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TBaseEntity>> ListAsync()
        {
            return await _dbContext.Set<TBaseEntity>().ToListAsync();
        }

        public virtual async Task<IEnumerable<TBaseEntity>> ListAsync(System.Linq.Expressions.Expression<Func<TBaseEntity, bool>> predicate)
        {
            return await _dbContext.Set<TBaseEntity>()
                .Where(predicate)
                .ToListAsync();
        }
    }

}
