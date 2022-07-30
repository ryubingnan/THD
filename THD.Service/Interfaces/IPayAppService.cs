using THD.Service.Dtos;
using THD.Service.Dtos.Pays;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace THD.Service.Interfaces
{
    public interface IPayAppService
    {
        Task<Tuple<bool, PayInfoDto>> AddAsync(PayQuery input, string currentUserId);
    }
}
