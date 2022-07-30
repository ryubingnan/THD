using THD.DataAccess.DbContexts;
using THD.DataAccess.Models;
using THD.DataAccess.Repositories.Abstract;
using THD.DataAccess.Repositories.Interfaces;

namespace THD.DataAccess.Repositories.Implements
{
    public class UserRepository : EfCoreRepository<OADbContext, User>, IUserRepository
    {
        public UserRepository(OADbContext dbContext) : base(dbContext)
        {
        }
    }
}
