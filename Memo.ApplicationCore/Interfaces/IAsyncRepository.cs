using MemoApp.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MemoApp.ApplicationCore.Interfaces
{
    public interface IAsyncRepository<TBaseEntity, TKey> where TBaseEntity : BaseEntity<TKey>
    {
        Task<TBaseEntity> GetByIdAsync(TKey id);
        Task<IEnumerable<TBaseEntity>> ListAsync();
        Task<IEnumerable<TBaseEntity>> ListAsync(Expression<Func<TBaseEntity,bool>> predicate);
        Task AddAsync(TBaseEntity entity);
        Task DeleteAsync(TBaseEntity entity);
        Task EditAsync(TBaseEntity entity);

    }
}
