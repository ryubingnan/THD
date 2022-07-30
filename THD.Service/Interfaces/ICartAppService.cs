using THD.Service.Dtos;
using THD.Service.Dtos.Carts;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace THD.Service.Interfaces
{
    public interface ICartAppService
    {
        Task<CartDto> GetAsync(int id);

        Task<List<CartDto>> GetListAsync(string currentUserId);

        Task<bool> TourAddOrUpdateAsync(TourCartQuery input, string currentUserId);

        Task<bool> StayAddOrUpdateAsync(StayCartQuery input, string currentUserId);

        Task<bool> TicketAddOrUpdateAsync(TicketCartQuery input, string currentUserId);

        Task<bool> FoodAddOrUpdateAsync(FoodCartQuery input, string currentUserId);

        Task<bool> PickupAddOrUpdateAsync(PickupCartQuery input, string currentUserId);

        Task<bool> GuideAddOrUpdateAsync(GuideCartQuery input, string currentUserId);

        Task<bool> PlayAddOrUpdateAsync(PlayCartQuery input, string currentUserId);

        Task<bool> CartPayAsync(List<CartDto> carts, string currentUserId);

        Task<int> GetPayTotalPricesAsync(string payId, string currentUserId);
    }
}
