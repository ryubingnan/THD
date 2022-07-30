using THD.Service.Dtos;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace THD.Service.Interfaces
{
    public interface ICorporateAppService
    {
        Task<List<CorporateDto>> GetListAsync();

        Task<PagedResultDto<CorporateDto>> GetListAsync(CorporatePagedQueryDto query);

        Task<CorporateDto> GetAsync(int id);

        Task<int> AddOrEditAsync(CorporateDto input);
        Task<bool> DeleteAsync(int id);
    }
}
