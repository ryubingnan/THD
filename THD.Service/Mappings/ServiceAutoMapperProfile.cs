using AutoMapper;

using THD.DataAccess.Models;
using THD.Service.Dtos;

namespace THD.Service.Mappings
{
    public class ServiceAutoMapperProfile : Profile
    {
        public ServiceAutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, RegisterUserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();

            CreateMap<Tour, TourDto>().ReverseMap();

            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<Cart, OrderList>().ReverseMap();

            CreateMap<Pay, PayDto>().ReverseMap();

            CreateMap<Stay, StayDto>().ReverseMap();

            CreateMap<Ticket, TicketDto>().ReverseMap();

            CreateMap<Food, FoodDto>().ReverseMap();

            CreateMap<Pickup, PickupDto>().ReverseMap();

            CreateMap<Guide, GuideDto>().ReverseMap();

            CreateMap<Play, PlayDto>().ReverseMap();

            CreateMap<Technician, TechnicianDto>().ReverseMap();

            CreateMap<ItListInfo, ItListInfoDto>().ReverseMap();

            CreateMap<Corporate, CorporateDto>().ReverseMap();
        }
    }
}
