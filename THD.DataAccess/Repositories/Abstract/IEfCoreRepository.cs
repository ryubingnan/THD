using THD.DataAccess.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace THD.DataAccess.Repositories.Abstract
{
    public interface IEfCoreRepository<TDbContext, TEntity> : IRepository<TEntity>
        where TDbContext : DbContext
        where TEntity : class, IEntity
    {
        TDbContext DbContext { get; }

        DatabaseFacade Database { get; }

        DbSet<TEntity> DbSet { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
