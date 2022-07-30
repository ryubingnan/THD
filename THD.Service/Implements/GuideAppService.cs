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
    public class GuideAppService : AppService, IGuideAppService
    {
        private readonly IGuideRepository _guideRepository;

        public GuideAppService(IMapper mapper, IGuideRepository guideRepository) : base(mapper)
        {
            _guideRepository = guideRepository;
        }

        public async Task<int> AddOrEditAsync(GuideDto input)
        {
            var dto = Mapper.Map<Guide>(input);
            Guide guide;
            if (dto.Id > 0)
            {
                guide = await _guideRepository.UpdateAsync(dto);
            }
            else
            {
                guide = await _guideRepository.InsertAsync(dto);
            }
            return guide.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var guide = await _guideRepository.GetAsync(id);
            if (guide is null) return false;
            guide.IsDelete = true;
            await _guideRepository.UpdateAsync(guide);
            return true;
        }

        public async Task<GuideDto> GetAsync(int id)
        {
            var guide = await _guideRepository.GetAsync(id);

            var dto = Mapper.Map<GuideDto>(guide);
            return dto;
        }

        public async Task<List<GuideDto>> GetListAsync()
        {
            var guides = await _guideRepository.GetListAsync(t => true);

            var dtos = Mapper.Map<List<GuideDto>>(guides);
            return dtos;
        }

        public async Task<PagedResultDto<GuideDto>> GetListAsync(GuidePagedQueryDto query)
        {
            Expression<Func<Guide, bool>> predicate = e => true;
            if (!string.IsNullOrEmpty(query.Title)) predicate = predicate.And(e => e.Title.Contains(query.Title));
            if (!string.IsNullOrEmpty(query.Type)) predicate = predicate.And(e => e.Type.Contains(query.Type));
            predicate = predicate.And(t => !t.IsDelete);
            var dto = await GetListAsync<GuidePagedQueryDto, Guide, PagedResultDto<GuideDto>, GuideDto>(query, _guideRepository, predicate);

            return dto;
        }
    }
}
