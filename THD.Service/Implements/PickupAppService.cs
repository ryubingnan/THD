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
    public class PickupAppService : AppService, IPickupAppService
    {
        private readonly IPickupRepository _pickupRepository;

        public PickupAppService(IMapper mapper, IPickupRepository pickupRepository) : base(mapper)
        {
            _pickupRepository = pickupRepository;
        }

        public async Task<int> AddOrEditAsync(PickupDto input)
        {
            var dto = Mapper.Map<Pickup>(input);
            Pickup pickup;
            if (dto.Id > 0)
            {
                pickup = await _pickupRepository.UpdateAsync(dto);
            }
            else
            {
                pickup = await _pickupRepository.InsertAsync(dto);
            }
            return pickup.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pickup = await _pickupRepository.GetAsync(id);
            if (pickup is null) return false;
            pickup.IsDelete = true;
            await _pickupRepository.UpdateAsync(pickup);
            return true;
        }

        public async Task<PickupDto> GetAsync(int id)
        {
            var pickup = await _pickupRepository.GetAsync(id);

            var dto = Mapper.Map<PickupDto>(pickup);
            return dto;
        }

        public async Task<List<PickupDto>> GetListAsync()
        {
            var pickups = await _pickupRepository.GetListAsync(t => true);

            var dtos = Mapper.Map<List<PickupDto>>(pickups);
            return dtos;
        }

        public async Task<PagedResultDto<PickupDto>> GetListAsync(PickupPagedQueryDto query)
        {
            Expression<Func<Pickup, bool>> predicate = e => true;
            if (!string.IsNullOrEmpty(query.Title)) predicate = predicate.And(e => e.Title.Contains(query.Title));
            if (!string.IsNullOrEmpty(query.Type)) predicate = predicate.And(e => e.Type.Contains(query.Type));
            predicate = predicate.And(t => !t.IsDelete);
            var dto = await GetListAsync<PickupPagedQueryDto, Pickup, PagedResultDto<PickupDto>, PickupDto>(query, _pickupRepository, predicate);

            return dto;
        }
    }
}
