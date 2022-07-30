using THD.DataAccess.DbContexts;
using THD.DataAccess.Models;
using THD.DataAccess.Repositories.Abstract;
using THD.DataAccess.Repositories.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;

namespace THD.DataAccess.Repositories.Implements
{
    public class TicketRepository : EfCoreRepository<AppDbContext, Ticket>, ITicketRepository
    {
        public TicketRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
