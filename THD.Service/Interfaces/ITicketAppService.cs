using THD.Service.Dtos;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace THD.Service.Interfaces
{
    public interface ITicketAppService
    {
        Task<List<TicketDto>> GetListAsync();

        Task<PagedResultDto<TicketDto>> GetListAsync(TicketPagedQueryDto query);

        Task<TicketDto> GetAsync(int id);

        Task<int> AddOrEditAsync(TicketDto input);

        Task<bool> DeleteAsync(int id);
    }
}
