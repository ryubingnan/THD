using AutoMapper;

using THD.DataAccess.Models;
using THD.DataAccess.Repositories.Interfaces;
using THD.Service.Implements.Abstract;
using THD.Service.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THD.Service.Implements
{
    public class OrderListAppService : AppService, IOrderListAppService
    {
        private readonly IOrderListRepository _orderListRepository;

        public OrderListAppService(IMapper mapper, IOrderListRepository orderListRepository) : base(mapper)
        {
            _orderListRepository = orderListRepository;
        }
    }
}
