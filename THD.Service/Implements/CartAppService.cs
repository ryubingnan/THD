using AutoMapper;

using THD.DataAccess.Models;
using THD.DataAccess.Repositories.Interfaces;
using THD.Service.Dtos;
using THD.Service.Dtos.Carts;
using THD.Service.Implements.Abstract;
using THD.Service.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THD.Service.Implements
{
    public class CartAppService : AppService, ICartAppService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ITourAppService _tourAppService;
        private readonly IStayAppService _stayAppService;
        private readonly ITicketAppService _ticketAppService;
        private readonly IFoodAppService _foodAppService;
        private readonly IPickupAppService _pickupAppService;
        private readonly IGuideAppService _guideAppService;
        private readonly IPlayAppService _playAppService;

        public CartAppService(IMapper mapper,
            ICartRepository cartRepository,
            ITourAppService tourAppService,
            IStayAppService stayAppService,
            ITicketAppService ticketAppService,
            IFoodAppService foodAppService,
            IPickupAppService pickupAppService,
            IGuideAppService guideAppService,
            IPlayAppService playAppService) : base(mapper)
        {
            _cartRepository = cartRepository;
            _tourAppService = tourAppService;
            _stayAppService = stayAppService;
            _ticketAppService = ticketAppService;
            _foodAppService = foodAppService;
            _pickupAppService = pickupAppService;
            _guideAppService = guideAppService;
            _playAppService = playAppService;
        }

        public async Task<bool> TourAddOrUpdateAsync(TourCartQuery input, string currentUserId)
        {
            var dto = await _tourAppService.GetAsync(input.TourId);
            if (dto is null) return false;

            var pid = input.TourId.ToString();
            var cart = await _cartRepository.GetAsync(t => t.Pid == pid && t.Keyword == "trip" && t.UserId == currentUserId);
            if (cart is null)
            {
                Cart cartDto = new Cart
                {
                    //Pid = pid,
                    //Img1 = dto.Img1,
                    //Type = dto.Type,
                    //Category = dto.Category,
                    //Title = dto.Title,
                    //Price = dto.PriceNew,
                    //Num = 1,
                    //TotalPrice = dto.PriceNew,
                    //UserId = currentUserId,
                    //Datein = DateTime.Now.ToString(),
                    //Keyword = "trip",
                    //DateStart = input.TourStartDate
                };
                var entity = await _cartRepository.InsertAsync(cartDto);
                return entity.Id > 0;
            }
            else
            {
                //cart.Img1 = dto.Img1;
                //cart.Type = dto.Type;
                //cart.Category = dto.Category;
                //cart.Title = dto.Title;
                //cart.Price = dto.PriceNew;
                //cart.Num = 1;
                //cart.TotalPrice = dto.PriceNew;
                //cart.UserId = currentUserId;
                //cart.Datein = DateTime.Now.ToString();
                //cart.Keyword = "trip";
                //cart.DateStart = input.TourStartDate;
                var entity = await _cartRepository.UpdateAsync(cart);
                return entity.Id > 0;
            }
        }

        public async Task<bool> CartPayAsync(List<CartDto> carts, string currentUserId)
        {
            var entitys = await _cartRepository.GetListAsync(t => t.UserId == currentUserId);
            if (!carts.All(t => entitys.Any(e => e.Id == t.Id))) return false;
            foreach (var item in carts)
            {
                var cart = entitys.Find(t => t.Id == item.Id);
                cart.Num = item.Num;
                cart.PayId = item.PayId;
            }
            await _cartRepository.UpdateManyAsync(entitys);
            return true;
        }

        public async Task<CartDto> GetAsync(int id)
        {
            var cart = await _cartRepository.GetAsync(id);
            var dto = Mapper.Map<CartDto>(cart);
            return dto;
        }

        public async Task<List<CartDto>> GetListAsync(string currentUserId)
        {
            var carts = await _cartRepository.GetListAsync(t => t.UserId == currentUserId);
            var dtos = Mapper.Map<List<CartDto>>(carts);
            return dtos;
        }

        public async Task<int> GetPayTotalPricesAsync(string payId, string currentUserId)
        {
            var carts = await _cartRepository.GetListAsync(t => t.PayId == payId && t.UserId == currentUserId);
            if (!carts.Any()) return 0;
            return carts.Sum(t => t.TotalPrice.Value * t.Num.Value);
        }

        public async Task<bool> StayAddOrUpdateAsync(StayCartQuery input, string currentUserId)
        {
            var dto = await _stayAppService.GetAsync(input.StayId);
            if (dto is null) return false;

            var pid = input.StayId.ToString();
            var cart = await _cartRepository.GetAsync(t => t.Pid == pid && t.Keyword == "stay" && t.UserId == currentUserId);
            if (cart is null)
            {
                Cart cartDto = new Cart
                {
                    Pid = pid,
                    Img1 = dto.Img1,
                    Type = dto.Type,
                    Category = dto.Category,
                    Title = dto.Title,
                    Price = dto.PriceNew,
                    Num = 1,
                    TotalPrice = dto.PriceNew,
                    UserId = currentUserId,
                    Datein = DateTime.Now.ToString(),
                    Keyword = "stay",
                    DateStart = input.StayStartDate,
                    DateEnd = input.StayEndDate
                };
                var entity = await _cartRepository.InsertAsync(cartDto);
                return entity.Id > 0;
            }
            else
            {
                cart.Img1 = dto.Img1;
                cart.Type = dto.Type;
                cart.Category = dto.Category;
                cart.Title = dto.Title;
                cart.Price = dto.PriceNew;
                cart.Num = 1;
                cart.TotalPrice = dto.PriceNew;
                cart.UserId = currentUserId;
                cart.Datein = DateTime.Now.ToString();
                cart.Keyword = "stay";
                cart.DateStart = input.StayStartDate;
                cart.DateEnd = input.StayEndDate;
                var entity = await _cartRepository.UpdateAsync(cart);
                return entity.Id > 0;
            }
        }

        public async Task<bool> TicketAddOrUpdateAsync(TicketCartQuery input, string currentUserId)
        {
            var dto = await _ticketAppService.GetAsync(input.TicketId);
            if (dto is null) return false;

            var pid = input.TicketId.ToString();
            var cart = await _cartRepository.GetAsync(t => t.Pid == pid && t.Keyword == "ticket" && t.UserId == currentUserId);
            if (cart is null)
            {
                Cart cartDto = new Cart
                {
                    Pid = pid,
                    Img1 = dto.Img1,
                    Type = dto.Type,
                    Category = dto.Category,
                    Title = dto.Title,
                    Price = dto.PriceNew,
                    Num = 1,
                    TotalPrice = dto.PriceNew,
                    UserId = currentUserId,
                    Datein = DateTime.Now.ToString(),
                    Keyword = "ticket",
                    DateStart = input.TicketStartDate,
                    DateEnd = input.TicketEndDate
                };
                var entity = await _cartRepository.InsertAsync(cartDto);
                return entity.Id > 0;
            }
            else
            {
                cart.Img1 = dto.Img1;
                cart.Type = dto.Type;
                cart.Category = dto.Category;
                cart.Title = dto.Title;
                cart.Price = dto.PriceNew;
                cart.Num = 1;
                cart.TotalPrice = dto.PriceNew;
                cart.UserId = currentUserId;
                cart.Datein = DateTime.Now.ToString();
                cart.Keyword = "ticket";
                cart.DateStart = input.TicketStartDate;
                cart.DateEnd = input.TicketEndDate;
                var entity = await _cartRepository.UpdateAsync(cart);
                return entity.Id > 0;
            }
        }

        public async Task<bool> FoodAddOrUpdateAsync(FoodCartQuery input, string currentUserId)
        {
            var dto = await _foodAppService.GetAsync(input.FoodId);
            if (dto is null) return false;

            var pid = input.FoodId.ToString();
            var cart = await _cartRepository.GetAsync(t => t.Pid == pid && t.Keyword == "food" && t.UserId == currentUserId);
            if (cart is null)
            {
                Cart cartDto = new Cart
                {
                    Pid = pid,
                    Img1 = dto.Img1,
                    Type = dto.Type,
                    Category = dto.Category,
                    Title = dto.Title,
                    Price = dto.PriceNew,
                    Num = 1,
                    TotalPrice = dto.PriceNew,
                    UserId = currentUserId,
                    Datein = DateTime.Now.ToString(),
                    Keyword = "food",
                    DateStart = input.FoodStartDate
                };
                var entity = await _cartRepository.InsertAsync(cartDto);
                return entity.Id > 0;
            }
            else
            {
                cart.Img1 = dto.Img1;
                cart.Type = dto.Type;
                cart.Category = dto.Category;
                cart.Title = dto.Title;
                cart.Price = dto.PriceNew;
                cart.Num = 1;
                cart.TotalPrice = dto.PriceNew;
                cart.UserId = currentUserId;
                cart.Datein = DateTime.Now.ToString();
                cart.Keyword = "food";
                cart.DateStart = input.FoodStartDate;
                var entity = await _cartRepository.UpdateAsync(cart);
                return entity.Id > 0;
            }
        }

        public async Task<bool> PickupAddOrUpdateAsync(PickupCartQuery input, string currentUserId)
        {
            var dto = await _pickupAppService.GetAsync(input.PickupId);
            if (dto is null) return false;

            var pid = input.PickupId.ToString();
            var cart = await _cartRepository.GetAsync(t => t.Pid == pid && t.Keyword == "pickup" && t.UserId == currentUserId);
            if (cart is null)
            {
                Cart cartDto = new Cart
                {
                    Pid = pid,
                    Img1 = dto.Img1,
                    Type = dto.Type,
                    Category = dto.Category,
                    Title = dto.Title,
                    Price = dto.PriceNew,
                    Num = 1,
                    TotalPrice = dto.PriceNew,
                    UserId = currentUserId,
                    Datein = DateTime.Now.ToString(),
                    Keyword = "pickup",
                    DateStart = input.PickupStartDate
                };
                var entity = await _cartRepository.InsertAsync(cartDto);
                return entity.Id > 0;
            }
            else
            {
                cart.Img1 = dto.Img1;
                cart.Type = dto.Type;
                cart.Category = dto.Category;
                cart.Title = dto.Title;
                cart.Price = dto.PriceNew;
                cart.Num = 1;
                cart.TotalPrice = dto.PriceNew;
                cart.UserId = currentUserId;
                cart.Datein = DateTime.Now.ToString();
                cart.Keyword = "pickup";
                cart.DateStart = input.PickupStartDate;
                var entity = await _cartRepository.UpdateAsync(cart);
                return entity.Id > 0;
            }
        }

        public async Task<bool> GuideAddOrUpdateAsync(GuideCartQuery input, string currentUserId)
        {
            var dto = await _guideAppService.GetAsync(input.GuideId);
            if (dto is null) return false;

            var pid = input.GuideId.ToString();
            var cart = await _cartRepository.GetAsync(t => t.Pid == pid && t.Keyword == "guide" && t.UserId == currentUserId);
            if (cart is null)
            {
                Cart cartDto = new Cart
                {
                    Pid = pid,
                    Img1 = dto.Img1,
                    Type = dto.Type,
                    Category = dto.Category,
                    Title = dto.Title,
                    Price = dto.PriceNew,
                    Num = 1,
                    TotalPrice = dto.PriceNew,
                    UserId = currentUserId,
                    Datein = DateTime.Now.ToString(),
                    Keyword = "guide",
                    DateStart = input.GuideStartDate
                };
                var entity = await _cartRepository.InsertAsync(cartDto);
                return entity.Id > 0;
            }
            else
            {
                cart.Img1 = dto.Img1;
                cart.Type = dto.Type;
                cart.Category = dto.Category;
                cart.Title = dto.Title;
                cart.Price = dto.PriceNew;
                cart.Num = 1;
                cart.TotalPrice = dto.PriceNew;
                cart.UserId = currentUserId;
                cart.Datein = DateTime.Now.ToString();
                cart.Keyword = "guide";
                cart.DateStart = input.GuideStartDate;
                var entity = await _cartRepository.UpdateAsync(cart);
                return entity.Id > 0;
            }
        }

        public async Task<bool> PlayAddOrUpdateAsync(PlayCartQuery input, string currentUserId)
        {
            var dto = await _playAppService.GetAsync(input.PlayId);
            if (dto is null) return false;

            var pid = input.PlayId.ToString();
            var cart = await _cartRepository.GetAsync(t => t.Pid == pid && t.Keyword == "play" && t.UserId == currentUserId);
            if (cart is null)
            {
                Cart cartDto = new Cart
                {
                    Pid = pid,
                    Img1 = dto.Img1,
                    Type = dto.Type,
                    Category = "",
                    Title = dto.Title,
                    Price = dto.PriceNew,
                    Num = 1,
                    TotalPrice = dto.PriceNew,
                    UserId = currentUserId,
                    Datein = DateTime.Now.ToString(),
                    Keyword = "play",
                    DateStart = input.PlayStartDate
                };
                var entity = await _cartRepository.InsertAsync(cartDto);
                return entity.Id > 0;
            }
            else
            {
                cart.Img1 = dto.Img1;
                cart.Type = dto.Type;
                cart.Category = "";
                cart.Title = dto.Title;
                cart.Price = dto.PriceNew;
                cart.Num = 1;
                cart.TotalPrice = dto.PriceNew;
                cart.UserId = currentUserId;
                cart.Datein = DateTime.Now.ToString();
                cart.Keyword = "play";
                cart.DateStart = input.PlayStartDate;
                var entity = await _cartRepository.UpdateAsync(cart);
                return entity.Id > 0;
            }
        }
    }
}
