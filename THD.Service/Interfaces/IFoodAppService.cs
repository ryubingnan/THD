using THD.Service.Dtos;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace THD.Service.Interfaces
{
    public interface IFoodAppService
    {
        Task<List<FoodDto>> GetListAsync();

        Task<PagedResultDto<FoodDto>> GetListAsync(FoodPagedQueryDto query);

        Task<FoodDto> GetAsync(int id);

        Task<int> AddOrEditAsync(FoodDto input);
        Task<bool> DeleteAsync(int id);
    }
}
