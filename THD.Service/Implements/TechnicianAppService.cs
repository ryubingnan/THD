using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using THD.DataAccess.Models;
using THD.DataAccess.Repositories.Interfaces;
using THD.Service.Dtos;
using THD.Service.Implements.Abstract;
using THD.Service.Interfaces;

namespace THD.Service.Implements
{

    public class TechnicianAppService : AppService, ITechnicianAppService
    {
        private readonly ITechnicianRepository _technicianRepository;

        public TechnicianAppService(IMapper mapper, ITechnicianRepository technicianRepository)
            : base(mapper)
        {
            _technicianRepository = technicianRepository;
        }

        public async Task<TechnicianDto> CreateAsync(TechnicianDto input)
        {
            var technician = Mapper.Map<Technician>(input);

            await _technicianRepository.InsertAsync(technician);

            return Mapper.Map<TechnicianDto>(technician);
        }

        public async Task<TechnicianDto> GetAsync(int id)
        {
            var technician = await _technicianRepository.GetAsync(id);

            return Mapper.Map<TechnicianDto>(technician);
        }

        public async Task<IEnumerable<TechnicianDto>> GetListAsync()
        {
            var technicians = await _technicianRepository.GetListAsync(u => true);

            return Mapper.Map<IEnumerable<TechnicianDto>>(technicians);
        }

        public async Task<PagedResultDto<TechnicianDto>> GetListAsync(TechnicianPagedQueryDto input)
        {
            Expression<Func<Technician, bool>> predicate = e => true;
            if (!string.IsNullOrEmpty(input.Name)) predicate = predicate.And(e => e.Name.Contains(input.Name));
            if (!string.IsNullOrEmpty(input.Email)) predicate = predicate.And(e => e.Email.Contains(input.Email));
            var dto = await GetListAsync<TechnicianPagedQueryDto, Technician, PagedResultDto<TechnicianDto>, TechnicianDto>(input, _technicianRepository, predicate);
            return dto;
        }
    }
}
