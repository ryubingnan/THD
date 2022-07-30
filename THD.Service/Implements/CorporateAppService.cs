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
    public class CorporateAppService : AppService, ICorporateAppService
    {
        private readonly ICorporateRepository _corporateRepository;

        public CorporateAppService(IMapper mapper, ICorporateRepository corporateRepository) : base(mapper)
        {
            _corporateRepository = corporateRepository;
        }

        public async Task<int> AddOrEditAsync(CorporateDto input)
        {
            var dto = Mapper.Map<Corporate>(input);
            Corporate corporate;
            if (dto.Id > 0)
            {
                corporate = await _corporateRepository.UpdateAsync(dto);
            }
            else
            {
                corporate = await _corporateRepository.InsertAsync(dto);
            }
            return corporate.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var corporate = await _corporateRepository.GetAsync(id);
            if (corporate is null) return false;
            await _corporateRepository.UpdateAsync(corporate);
            return true;
        }

        public async Task<CorporateDto> GetAsync(int id)
        {
            var play = await _corporateRepository.GetAsync(id);

            var dto = Mapper.Map<CorporateDto>(play);
            return dto;
        }

        public async Task<List<CorporateDto>> GetListAsync()
        {
            var corporates = await _corporateRepository.GetListAsync(t => true);

            var dtos = Mapper.Map<List<CorporateDto>>(corporates);
            return dtos;
        }

        public async Task<PagedResultDto<CorporateDto>> GetListAsync(CorporatePagedQueryDto query)
        {
            Expression<Func<Corporate, bool>> predicate = e => true;
            var dto = await GetListAsync<CorporatePagedQueryDto, Corporate, PagedResultDto<CorporateDto>, CorporateDto>(query, _corporateRepository, predicate);

            return dto;
        }
    }
}
