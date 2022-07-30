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
    public class StayAppService : AppService, IStayAppService
    {
        private readonly IStayRepository _stayRepository;

        public StayAppService(IMapper mapper, IStayRepository stayRepository) : base(mapper)
        {
            _stayRepository = stayRepository;
        }
        public async Task<List<StayDto>> GetListAsync()
        {
            var stays = await _stayRepository.GetListAsync(stay => true);

            var dtos = Mapper.Map<List<StayDto>>(stays);
            return dtos;
        }

        public async Task<StayDto> GetAsync(int id)
        {
            var stay = await _stayRepository.GetAsync(id);

            var dto = Mapper.Map<StayDto>(stay);
            return dto;
        }

        public async Task<PagedResultDto<StayDto>> GetListAsync(StayPagedQueryDto query)
        {
            Expression<Func<Stay, bool>> predicate = e => true;
            if (!string.IsNullOrEmpty(query.Title)) predicate = predicate.And(e => e.Title.Contains(query.Title));
            if (!string.IsNullOrEmpty(query.Type)) predicate = predicate.And(e => e.Type.Contains(query.Type));
            predicate = predicate.And(t => !t.IsDelete);
            var dto = await GetListAsync<StayPagedQueryDto, Stay, PagedResultDto<StayDto>, StayDto>(query, _stayRepository, predicate);

            return dto;
        }

        public async Task<int> AddOrEditAsync(StayDto input)
        {
            var dto = Mapper.Map<Stay>(input);
            Stay stay;
            if (dto.Id > 0)
            {
                stay = await _stayRepository.UpdateAsync(dto);
            }
            else
            {
                stay = await _stayRepository.InsertAsync(dto);
            }
            return stay.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var stay = await _stayRepository.GetAsync(id);
            if (stay is null) return false;
            stay.IsDelete = true;
            await _stayRepository.UpdateAsync(stay);
            return true;
        }
    }
}
