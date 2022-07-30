using THD.DataAccess.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.EntityFrameworkCore;

using System.Reflection;

namespace THD.DataAccess.DbContexts
{
    public class AppDbContext : EfCoreDbContext<AppDbContext>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Pay> Pays { get; set; }
        public virtual DbSet<OrderList> OrderLists { get; set; }
        public virtual DbSet<Stay> Stays { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Pickup> Pickups { get; set; }
        public virtual DbSet<Guide> Guides { get; set; }
        public virtual DbSet<Play> Plays { get; set; }
        public virtual DbSet<ItListInfo> ItListInfos { get; set; }
        public virtual DbSet<Corporate> Corporates { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplyConfigurations(modelBuilder);
        }

        private void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TourEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CartEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PayEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderListEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StayEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TicketEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FoodEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PickupEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GuideEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlayEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ItListInfoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CorporateEntityTypeConfiguration());
        }
    }
}
