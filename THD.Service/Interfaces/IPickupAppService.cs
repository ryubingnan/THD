using THD.Service.Dtos;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace THD.Service.Interfaces
{
    public interface IPickupAppService
    {
        Task<List<PickupDto>> GetListAsync();

        Task<PagedResultDto<PickupDto>> GetListAsync(PickupPagedQueryDto query);

        Task<PickupDto> GetAsync(int id);

        Task<int> AddOrEditAsync(PickupDto input);
        Task<bool> DeleteAsync(int id);
    }
}
