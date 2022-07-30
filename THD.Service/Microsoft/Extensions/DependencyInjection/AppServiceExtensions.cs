using THD.Service.Implements;
using THD.Service.Interfaces;

using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.TryAddScoped<IUserAppService, UserAppService>();
            services.TryAddScoped<ITourAppService, TourAppService>();
            services.TryAddScoped<ICartAppService, CartAppService>();
            services.TryAddScoped<IPayAppService, PayAppService>();
            services.TryAddScoped<IOrderListAppService, OrderListAppService>();
            services.TryAddScoped<IStayAppService, StayAppService>();
            services.TryAddScoped<ITicketAppService, TicketAppService>();
            services.TryAddScoped<IFoodAppService, FoodAppService>();
            services.TryAddScoped<IPickupAppService, PickupAppService>();
            services.TryAddScoped<IGuideAppService, GuideAppService>();
            services.TryAddScoped<IPlayAppService, PlayAppService>();
            services.TryAddScoped<ITechnicianAppService, TechnicianAppService>();
            services.TryAddScoped<IItListInfoAppService, ItListInfoAppService>();
            services.TryAddScoped<ICorporateAppService, CorporateAppService>();

            return services;
        }
    }
}
