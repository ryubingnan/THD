using THD.DataAccess.DbContexts;
using THD.DataAccess.Models;
using THD.DataAccess.Repositories.Abstract;
using THD.DataAccess.Repositories.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;

namespace THD.DataAccess.Repositories.Implements
{
    public class CartRepository : EfCoreRepository<AppDbContext, Cart>, ICartRepository
    {
        public CartRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
