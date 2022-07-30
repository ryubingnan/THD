using Microsoft.EntityFrameworkCore;

namespace THD.DataAccess.DbContexts
{
    public abstract class EfCoreDbContext<TDbContext> : DbContext
        where TDbContext : DbContext
    {
        public EfCoreDbContext(DbContextOptions<TDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
