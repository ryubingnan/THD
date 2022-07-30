using THD.DataAccess.Models.Abstract;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace THD.DataAccess.Repositories.Abstract
{
    public abstract class AdoRepositoryBase<TEntity> : IBasicAdoRepository<TEntity> where TEntity : IEntity
    {
        public abstract Task<TEntity> GetAsync(string sql, CancellationToken cancellationToken = default);

        public abstract Task<TEntity> GetAsync(string sql, object param, CancellationToken cancellationToken = default);

        public abstract Task<List<TEntity>> GetListAsync(string sql, CancellationToken cancellationToken = default);

        public abstract Task<List<TEntity>> GetListAsync(string sql, object param, CancellationToken cancellationToken = default);
    }
}
