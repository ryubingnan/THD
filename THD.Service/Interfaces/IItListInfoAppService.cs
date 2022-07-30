using THD.Service.Dtos;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace THD.Service.Interfaces
{
    public interface IItListInfoAppService
    {
        Task<List<ItListInfoDto>> GetListAsync();

        Task<PagedResultDto<ItListInfoDto>> GetListAsync(ItListInfoPagedQueryDto query);

        Task<ItListInfoDto> GetAsync(int id);

        Task<int> AddOrEditAsync(ItListInfoDto input);
        Task<bool> DeleteAsync(int id);
    }
}
