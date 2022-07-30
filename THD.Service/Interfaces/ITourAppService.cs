using THD.Service.Dtos;

using System.Threading.Tasks;

namespace THD.Service.Interfaces
{
    public interface ITourAppService
    {
        Task<PagedResultDto<TourDto>> GetListAsync(TourPagedQueryDto query);

        Task<TourDto> GetAsync(int id);

        Task<int> AddOrEditAsync(TourDto input);

        Task<bool> DeleteAsync(int id);
    }
}
