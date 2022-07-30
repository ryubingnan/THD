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
    public class ItListInfoAppService : AppService, IItListInfoAppService
    {
        private readonly IItListInfoRepository _itListInfoRepository;

        public ItListInfoAppService(IMapper mapper, IItListInfoRepository itListInfoRepository) : base(mapper)
        {
            _itListInfoRepository = itListInfoRepository;
        }

        public async Task<int> AddOrEditAsync(ItListInfoDto input)
        {
            var dto = Mapper.Map<ItListInfo>(input);
            ItListInfo play;
            if (dto.Id > 0)
            {
                play = await _itListInfoRepository.UpdateAsync(dto);
            }
            else
            {
                play = await _itListInfoRepository.InsertAsync(dto);
            }
            return play.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var play = await _itListInfoRepository.GetAsync(id);
            if (play is null) return false;
            await _itListInfoRepository.DeleteAsync(play);
            return true;
        }

        public async Task<ItListInfoDto> GetAsync(int id)
        {
            var play = await _itListInfoRepository.GetAsync(id);

            var dto = Mapper.Map<ItListInfoDto>(play);
            return dto;
        }

        public async Task<List<ItListInfoDto>> GetListAsync()
        {
            var plays = await _itListInfoRepository.GetListAsync(t => true);

            var dtos = Mapper.Map<List<ItListInfoDto>>(plays);
            return dtos;
        }

        public async Task<PagedResultDto<ItListInfoDto>> GetListAsync(ItListInfoPagedQueryDto query)
        {
            Expression<Func<ItListInfo, bool>> predicate = e => true;
            if (!string.IsNullOrEmpty(query.Title)) predicate = predicate.And(e => e.Title.Contains(query.Title));
            if (!string.IsNullOrEmpty(query.Type)) predicate = predicate.And(e => e.Type.Contains(query.Type));
            var dto = await GetListAsync<ItListInfoPagedQueryDto, ItListInfo, PagedResultDto<ItListInfoDto>, ItListInfoDto>(query, _itListInfoRepository, predicate);

            return dto;
        }
    }
}
