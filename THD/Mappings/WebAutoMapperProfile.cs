using AutoMapper;

using THD.Service.Dtos;
using THD.Web.Models.Food;
using THD.Web.Models.Guide;
using THD.Web.Models.Home;
using THD.Web.Models.Pickup;
using THD.Web.Models.Play;
using THD.Web.Models.Stay;
using THD.Web.Models.Ticket;
using THD.Web.Models.Tour;
using THD.Web.Models.User;

namespace THD.Web.Mappings
{
    public class WebAutoMapperProfile : Profile
    {
        public WebAutoMapperProfile()
        {
            CreateMap<UserDto, UserListItemViewModel>().ReverseMap();
            CreateMap<UserDto, UserViewModel>().ReverseMap();
            CreateMap<UserDto, EditUserViewModel>().ReverseMap();
            CreateMap<UpdateUserDto, EditUserViewModel>().ReverseMap();

            CreateMap<TourDto, TourViewModel>().ReverseMap();

            CreateMap<StayDto, StayViewModel>().ReverseMap();

            CreateMap<TicketDto, TicketViewModel>().ReverseMap();

            CreateMap<FoodDto, FoodViewModel>().ReverseMap();

            CreateMap<PickupDto, PickupViewModel>().ReverseMap();

            CreateMap<GuideDto, GuideViewModel>().ReverseMap();

            CreateMap<PlayDto, PlayViewModel>().ReverseMap();

            CreateMap<TechnicianDto, TechnicianRegisterModel>().ReverseMap();
        }
    }
}
