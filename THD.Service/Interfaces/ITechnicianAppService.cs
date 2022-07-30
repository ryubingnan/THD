using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using THD.Service.Dtos;

namespace THD.Service.Interfaces
{
   public interface ITechnicianAppService
    {
        Task<TechnicianDto> GetAsync(int id);

        Task<IEnumerable<TechnicianDto>> GetListAsync();

        Task<TechnicianDto> CreateAsync(TechnicianDto input);

        Task<PagedResultDto<TechnicianDto>> GetListAsync(TechnicianPagedQueryDto input);
    }
}
