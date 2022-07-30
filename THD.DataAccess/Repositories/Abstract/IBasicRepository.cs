using THD.DataAccess.Models.Abstract;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace THD.DataAccess.Repositories.Abstract
{
    public interface IBasicRepository<TEntity> : IRepository where TEntity : IEntity
    {
        Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task InsertManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task DeleteAsync(object keyValue, CancellationToken cancellationToken = default);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task DeleteManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task UpdateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}
