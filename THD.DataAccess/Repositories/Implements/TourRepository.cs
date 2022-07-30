using THD.DataAccess.DbContexts;
using THD.DataAccess.Models;
using THD.DataAccess.Repositories.Abstract;
using THD.DataAccess.Repositories.Interfaces;

namespace THD.DataAccess.Repositories.Implements
{
    public class TourRepository : EfCoreRepository<AppDbContext, Tour>, ITourRepository
    {
        public TourRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
