using THD.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.EntityFrameworkCore;
using System.Reflection;

namespace THD.DataAccess.DbContexts
{
    public class OADbContext : EfCoreDbContext<OADbContext>
    {
        public OADbContext(DbContextOptions<OADbContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Technician> Technicians { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplyConfigurations(modelBuilder);
        }

        private void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TechnicianEntityTypeConfiguration());
        }
    }
}
