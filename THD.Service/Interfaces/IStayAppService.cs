using THD.Service.Dtos;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace THD.Service.Interfaces
{
    public interface IStayAppService
    {
        Task<List<StayDto>> GetListAsync();

        Task<PagedResultDto<StayDto>> GetListAsync(StayPagedQueryDto query);

        Task<StayDto> GetAsync(int id);

        Task<int> AddOrEditAsync(StayDto input);

        Task<bool> DeleteAsync(int id);
    }
}
