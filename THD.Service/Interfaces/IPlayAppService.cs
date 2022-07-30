using THD.Service.Dtos;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace THD.Service.Interfaces
{
    public interface IPlayAppService
    {
        Task<List<PlayDto>> GetListAsync();

        Task<PagedResultDto<PlayDto>> GetListAsync(PlayPagedQueryDto query);

        Task<PlayDto> GetAsync(int id);

        Task<int> AddOrEditAsync(PlayDto input);
        Task<bool> DeleteAsync(int id);
    }
}
