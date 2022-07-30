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
    public class PlayAppService : AppService, IPlayAppService
    {
        private readonly IPlayRepository _playRepository;

        public PlayAppService(IMapper mapper, IPlayRepository playRepository) : base(mapper)
        {
            _playRepository = playRepository;
        }

        public async Task<int> AddOrEditAsync(PlayDto input)
        {
            var dto = Mapper.Map<Play>(input);
            Play play;
            if (dto.Id > 0)
            {
                play = await _playRepository.UpdateAsync(dto);
            }
            else
            {
                play = await _playRepository.InsertAsync(dto);
            }
            return play.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var play = await _playRepository.GetAsync(id);
            if (play is null) return false;
            play.IsDelete = true;
            await _playRepository.UpdateAsync(play);
            return true;
        }

        public async Task<PlayDto> GetAsync(int id)
        {
            var play = await _playRepository.GetAsync(id);

            var dto = Mapper.Map<PlayDto>(play);
            return dto;
        }

        public async Task<List<PlayDto>> GetListAsync()
        {
            var plays = await _playRepository.GetListAsync(t => true);

            var dtos = Mapper.Map<List<PlayDto>>(plays);
            return dtos;
        }

        public async Task<PagedResultDto<PlayDto>> GetListAsync(PlayPagedQueryDto query)
        {
            Expression<Func<Play, bool>> predicate = e => true;
            if (!string.IsNullOrEmpty(query.Title)) predicate = predicate.And(e => e.Title.Contains(query.Title));
            if (!string.IsNullOrEmpty(query.Type)) predicate = predicate.And(e => e.Type.Contains(query.Type));
            predicate = predicate.And(t => !t.IsDelete);
            var dto = await GetListAsync<PlayPagedQueryDto, Play, PagedResultDto<PlayDto>, PlayDto>(query, _playRepository, predicate);

            return dto;
        }
    }
}
