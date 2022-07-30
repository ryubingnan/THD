using AutoMapper;

using THD.DataAccess.Models;
using THD.DataAccess.Repositories.Interfaces;
using THD.Service.Dtos;
using THD.Service.Dtos.Pays;
using THD.Service.Implements.Abstract;
using THD.Service.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THD.Service.Implements
{
    public class PayAppService : AppService, IPayAppService
    {
        private readonly IPayRepository _payRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IOrderListRepository _orderListRepository;

        public PayAppService(IMapper mapper, IPayRepository payRepository, ICartRepository cartRepository, IOrderListRepository orderListRepository) : base(mapper)
        {
            _payRepository = payRepository;
            _cartRepository = cartRepository;
            _orderListRepository = orderListRepository;
        }

        public async Task<Tuple<bool, PayInfoDto>> AddAsync(PayQuery input, string currentUserId)
        {
            var carts = await _cartRepository.GetListAsync(t => t.PayId == input.PayId && t.UserId == currentUserId);
            if (!carts.Any()) return new Tuple<bool, PayInfoDto>(false, null);
            var orderLists = Mapper.Map<List<OrderList>>(carts);
            var cartDtos = Mapper.Map<List<CartDto>>(carts);
            orderLists.ForEach(t => t.Id = 0);
            await _orderListRepository.InsertManyAsync(orderLists);

            Pay pay = new Pay
            {
                PayId = input.PayId,
                Status = "NO",
                PayType = input.PayType,
                AllTotalPrice = carts.Sum(t => t.TotalPrice.Value * t.Num.Value).ToString(),
                UserId = currentUserId,
                Datein = DateTime.Now.ToString()
            };
            var entity = await _payRepository.InsertAsync(pay);

            if (entity.Id > 0)
            {
                await _cartRepository.DeleteManyAsync(carts);
            }

            PayInfoDto payInfo = new PayInfoDto
            {
                CartDtos = cartDtos,
                PayDto = Mapper.Map<PayDto>(pay)
            };

            return new Tuple<bool, PayInfoDto>(true, payInfo);
        }
    }
}
