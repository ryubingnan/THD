using THD.Service.Dtos;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace THD.Service.Interfaces
{
   public interface IGuideAppService
    {
        Task<List<GuideDto>> GetListAsync();

        Task<PagedResultDto<GuideDto>> GetListAsync(GuidePagedQueryDto query);

        Task<GuideDto> GetAsync(int id);

        Task<int> AddOrEditAsync(GuideDto input);
        Task<bool> DeleteAsync(int id);
    }
}
