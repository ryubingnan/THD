using THD.DataAccess.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace THD.DataAccess.Repositories.Abstract
{
    public interface IReadonlyRepository<T> : IBasicAdoRepository<T>, IRepository where T : IEntity
    {
        Task<int> CountAsync(CancellationToken cancellationToken = default);

        Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task<long> LongCountAsync(CancellationToken cancellationToken = default);

        Task<long> LongCountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task<T> GetAsync(params object[] keyValues);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate, int limit, int skip, CancellationToken cancellationToken = default);

        Task<List<T>> GetListAsync<TOrderKey>(Expression<Func<T, bool>> predicate, int limit, int skip, Expression<Func<T, TOrderKey>> keySelector, bool isAsc = true, CancellationToken cancellationToken = default);

        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate, int limit, int skip, IEnumerable<OrderCondition> orders, CancellationToken cancellationToken = default);
    }
}
