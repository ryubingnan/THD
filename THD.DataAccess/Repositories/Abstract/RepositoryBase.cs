using THD.DataAccess.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace THD.DataAccess.Repositories.Abstract
{
    public abstract class RepositoryBase<T> : AdoRepositoryBase<T>, IRepository<T> where T : IEntity
    {
        public abstract Task<T> InsertAsync(T entity, CancellationToken cancellationToken = default);

        public abstract Task InsertManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        public abstract Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

        public abstract Task DeleteManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        public abstract Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);

        public abstract Task UpdateManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        public abstract Task<int> CountAsync(CancellationToken cancellationToken = default);

        public abstract Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        public abstract Task<long> LongCountAsync(CancellationToken cancellationToken = default);

        public abstract Task<long> LongCountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        public abstract Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        public abstract Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

        public abstract Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate, int limit, int skip, CancellationToken cancellationToken = default);

        public abstract Task<List<T>> GetListAsync<TOrderKey>(Expression<Func<T, bool>> predicate, int limit, int skip, Expression<Func<T, TOrderKey>> keySelector, bool isAsc = true, CancellationToken cancellationToken = default);

        public abstract Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate, int limit, int skip, IEnumerable<OrderCondition> orders, CancellationToken cancellationToken = default);

        public abstract Task DeleteAsync(object keyValue, CancellationToken cancellationToken = default);

        public abstract Task<T> GetAsync(params object[] keyValues);
    }
}
