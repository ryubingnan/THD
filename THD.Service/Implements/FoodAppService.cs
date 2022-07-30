using AutoMapper;

using THD.DataAccess.Models;
using THD.DataAccess.Repositories.Interfaces;
using THD.Service.Dtos;
using THD.Service.Implements.Abstract;
using THD.Service.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace THD.Service.Implements
{
    public class FoodAppService : AppService, IFoodAppService
    {
        private readonly IFoodRepository _foodRepository;

        public FoodAppService(IMapper mapper, IFoodRepository foodRepository) : base(mapper)
        {
            _foodRepository = foodRepository;
        }

        public async Task<List<FoodDto>> GetListAsync()
        {
            var foods = await _foodRepository.GetListAsync(stay => true);

            var dtos = Mapper.Map<List<FoodDto>>(foods);
            return dtos;
        }

        public async Task<FoodDto> GetAsync(int id)
        {
            var food = await _foodRepository.GetAsync(id);

            var dto = Mapper.Map<FoodDto>(food);
            return dto;
        }

        public async Task<PagedResultDto<FoodDto>> GetListAsync(FoodPagedQueryDto query)
        {
            Expression<Func<Food, bool>> predicate = e => true;
            if (!string.IsNullOrEmpty(query.Title)) predicate = predicate.And(e => e.Title.Contains(query.Title));
            if (!string.IsNullOrEmpty(query.Type)) predicate = predicate.And(e => e.Type.Contains(query.Type));
            predicate = predicate.And(t => !t.IsDelete);
            var dto = await GetListAsync<FoodPagedQueryDto, Food, PagedResultDto<FoodDto>, FoodDto>(query, _foodRepository, predicate);

            return dto;
        }

        public async Task<int> AddOrEditAsync(FoodDto input)
        {
            var dto = Mapper.Map<Food>(input);
            Food food;
            if (dto.Id > 0)
            {
                food = await _foodRepository.UpdateAsync(dto);
            }
            else
            {
                food = await _foodRepository.InsertAsync(dto);
            }
            return food.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var food = await _foodRepository.GetAsync(id);
            if (food is null) return false;
            food.IsDelete = true;
            await _foodRepository.UpdateAsync(food);
            return true;
        }
    }
}
