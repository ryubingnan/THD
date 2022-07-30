using System;
using System.Collections.Generic;
using System.Text;
using THD.DataAccess.DbContexts;
using THD.DataAccess.Models;
using THD.DataAccess.Repositories.Abstract;
using THD.DataAccess.Repositories.Interfaces;

namespace THD.DataAccess.Repositories.Implements
{
    public class TechnicianRepository : EfCoreRepository<OADbContext, Technician>, ITechnicianRepository
    {
        public TechnicianRepository(OADbContext dbContext) : base(dbContext)
        {
        }
    }
}
