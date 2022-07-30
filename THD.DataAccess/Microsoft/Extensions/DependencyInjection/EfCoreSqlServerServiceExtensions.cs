using THD.DataAccess.DbContexts;
using THD.DataAccess.Repositories.Implements;
using THD.DataAccess.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EfCoreSqlServerServiceExtensions
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AppDbContext>(options =>
            {
                var connStr = configuration.GetConnectionString("Default");
                options.UseSqlServer(connStr);
            });
            services.AddDbContextPool<OADbContext>(options =>
            {
                var connStr = configuration.GetConnectionString("OA");
                options.UseSqlServer(connStr);
            });

            services.AddTransient<AppDbContext>();
            services.AddDefaultRepositories<AppDbContext>();
            services.AddTransient<OADbContext>();
            services.AddDefaultRepositories<OADbContext>();

            services.AddCustomRepository<IUserRepository, UserRepository>();
            services.AddCustomRepository<ITourRepository, TourRepository>();
            services.AddCustomRepository<ICartRepository, CartRepository>();
            services.AddCustomRepository<IPayRepository, PayRepository>();
            services.AddCustomRepository<IOrderListRepository, OrderListRepository>();
            services.AddCustomRepository<IStayRepository, StayRepository>();
            services.AddCustomRepository<ITicketRepository, TicketRepository>();
            services.AddCustomRepository<IFoodRepository, FoodRepository>();
            services.AddCustomRepository<IPickupRepository, PickupRepository>();
            services.AddCustomRepository<IGuideRepository, GuideRepository>();
            services.AddCustomRepository<IPlayRepository, PlayRepository>();
            services.AddCustomRepository<ITechnicianRepository, TechnicianRepository>();
            services.AddCustomRepository<IItListInfoRepository, ItListInfoRepository>();
            services.AddCustomRepository<ICorporateRepository, CorporateRepository>();

            return services;
        }
    }
}