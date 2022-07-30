using THD.DataAccess.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace THD.DataAccess.Repositories.Abstract
{
    public class EfCoreRepository<TDbContext, TEntity> : EfCoreRepository<TDbContext, TEntity, int>
        where TDbContext : DbContext
        where TEntity : class, IEntity<int>
    {
        public EfCoreRepository(TDbContext dbContext) : base(dbContext)
        {
        }
    }

    public class EfCoreRepository<TDbContext, TEntity, TKey> : IEfCoreRepository<TDbContext, TEntity>
        where TDbContext : DbContext
        where TEntity : class, IEntity<TKey>
        where TKey : struct
    {
        private readonly TDbContext _dbContext;

        public EfCoreRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual TDbContext DbContext => _dbContext;

        public virtual DatabaseFacade Database => DbContext.Database;

        public virtual DbSet<TEntity> DbSet => GetDbSet();

        protected virtual DbSet<TEntity> GetDbSet() => DbContext.Set<TEntity>();

        #region Get

        public Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return DbSet.CountAsync(cancellationToken);
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return DbSet.CountAsync(predicate, cancellationToken);
        }

        public Task<long> LongCountAsync(CancellationToken cancellationToken = default)
        {
            return DbSet.LongCountAsync(cancellationToken);
        }

        public Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return DbSet.LongCountAsync(predicate, cancellationToken);
        }

        public Task<TEntity> GetAsync(object[] keyValues)
        {
            return DbSet.FindAsync(keyValues).AsTask();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            var entity = await DbSet
                .FirstOrDefaultAsync(predicate, cancellationToken);

            return entity;
        }

        public async Task<TEntity> GetAsync(string sql, CancellationToken cancellationToken = default)
        {
            return await DbSet.FromSqlRaw(sql).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        public async Task<TEntity> GetAsync(string sql, object param, CancellationToken cancellationToken = default)
        {
            return await DbSet.FromSqlRaw(sql, parameters: param)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            var entities = await DbSet
                .Where(predicate)
                .ToListAsync(cancellationToken);

            return entities;
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, int limit,
            int skip,
            CancellationToken cancellationToken = default)
        {
            var entities = await DbSet
                .Where(predicate)
                .OrderBy(e => e.Id)
                .Skip(skip)
                .Take(limit)
                .ToListAsync(cancellationToken);

            return entities;
        }

        public async Task<List<TEntity>> GetListAsync<TOrderKey>(Expression<Func<TEntity, bool>> predicate, int limit, int skip, Expression<Func<TEntity, TOrderKey>> keySelector, bool isAsc = true, CancellationToken cancellationToken = default)
        {
            var query = DbSet.Where(predicate);

            query = isAsc ? query.OrderBy(keySelector) : query.OrderByDescending(keySelector);

            var entities = await query
                .Skip(skip)
                .Take(limit)
                .ToListAsync(cancellationToken);

            return entities;
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, int limit, int skip, IEnumerable<OrderCondition> orders, CancellationToken cancellationToken = default)
        {
            var query = DbSet.Where(predicate);

            if (orders?.Any() == true)
            {
                var orderParameter = Expression.Parameter(typeof(TEntity), "e");

                var i = 0;
                foreach (var order in orders)
                {
                    var property = typeof(TEntity).GetProperty(order.Field);
                    var propertyAccess = Expression.MakeMemberAccess(orderParameter, property);
                    var lambda = Expression.Lambda(propertyAccess, orderParameter);

                    var name = string.Empty;
                    if (i == 0)
                    {
                        name = order.IsAsc ? nameof(Queryable.OrderBy) : nameof(Queryable.OrderByDescending);
                    }
                    else
                    {
                        name = order.IsAsc ? nameof(Queryable.ThenBy) : nameof(Queryable.ThenByDescending);
                    }

                    var expression = Expression.Call(typeof(Queryable), name, new Type[] { typeof(TEntity), property.PropertyType }, query.Expression, Expression.Quote(lambda));
                    query = query.Provider.CreateQuery<TEntity>(expression);

                    i++;
                }
            }

            var entities = await query
                .Skip(skip)
                .Take(limit)
                .ToListAsync(cancellationToken);

            return entities;
        }

        public async Task<List<TEntity>> GetListAsync(string sql,
            CancellationToken cancellationToken = default)
        {
            return await DbSet.FromSqlRaw(sql).ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<List<TEntity>> GetListAsync(string sql, object param,
            CancellationToken cancellationToken = default)
        {
            return await DbSet.FromSqlRaw(sql, parameters: param)
                .ToListAsync(cancellationToken: cancellationToken);
        }
        #endregion

        #region Insert
        public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var res = (await DbSet.AddAsync(entity, cancellationToken)).Entity;

            await SaveChangesAsync(cancellationToken);

            return res;
        }

        public async Task InsertManyAsync(IEnumerable<TEntity> entities,
            CancellationToken cancellationToken = default)
        {
            await DbSet.AddRangeAsync(entities, cancellationToken);

            await SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region Update
        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            DbContext.Attach(entity);

            var updatedEntity = DbContext.Update(entity).Entity;

            await SaveChangesAsync(cancellationToken);

            return updatedEntity;
        }

        public async Task UpdateManyAsync(IEnumerable<TEntity> entities,
            CancellationToken cancellationToken = default)
        {
            DbSet.UpdateRange(entities);

            await SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region Delete
        public async Task DeleteAsync(object keyValue, CancellationToken cancellationToken = default)
        {
            var entity = await DbSet.FindAsync(keyValue);
            if (entity != null)
            {
                DbSet.Remove(entity);

                await SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            DbSet.Remove(entity);

            await SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteManyAsync(IEnumerable<TEntity> entities,
            CancellationToken cancellationToken = default)
        {
            DbContext.RemoveRange(entities);

            await SaveChangesAsync(cancellationToken);
        }
        #endregion

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await DbContext.SaveChangesAsync(cancellationToken);
        }
    }

}
