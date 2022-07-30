using AutoMapper;

using THD.DataAccess.Models;
using THD.DataAccess.Repositories.Interfaces;
using THD.Service.Dtos;
using THD.Service.Implements.Abstract;
using THD.Service.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace THD.Service.Implements
{
    public class TourAppService : AppService, ITourAppService
    {
        private readonly ITourRepository _tourRepository;

        public TourAppService(IMapper mapper, ITourRepository tourRepository) : base(mapper)
        {
            _tourRepository = tourRepository;
        }

        public async Task<List<TourDto>> GetListAsync()
        {
            var tours = await _tourRepository.GetListAsync(tour => true);

            var dtos = Mapper.Map<List<TourDto>>(tours);
            return dtos;
        }

        public async Task<TourDto> GetAsync(int id)
        {
            var tour = await _tourRepository.GetAsync(id);

            var dto = Mapper.Map<TourDto>(tour);
            return dto;
        }

        public async Task<PagedResultDto<TourDto>> GetListAsync(TourPagedQueryDto query)
        {
            Expression<Func<Tour, bool>> predicate = e => true;
            if (!string.IsNullOrEmpty(query.Title)) predicate = predicate.And(e => e.Title.Contains(query.Title));
            if (!string.IsNullOrEmpty(query.Type)) predicate = predicate.And(e => e.Type.Contains(query.Type));
            if (!string.IsNullOrEmpty(query.Search)) predicate = predicate.And(e => e.Title.Contains(query.Search) || e.Contents.Contains(query.Search) );
            predicate = predicate.And(t => !t.IsDelete);
            var dto = await GetListAsync<TourPagedQueryDto, Tour, PagedResultDto<TourDto>, TourDto>(query, _tourRepository, predicate);

            return dto;
        }

        public async Task<int> AddOrEditAsync(TourDto input)
        {
            var dto = Mapper.Map<Tour>(input);
            Tour tour;
            if (dto.Id > 0)
            {
                tour = await _tourRepository.UpdateAsync(dto);
            }
            else
            {
                tour = await _tourRepository.InsertAsync(dto);
            }
            return tour.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tour = await _tourRepository.GetAsync(id);
            if (tour is null) return false;
            tour.IsDelete = true;
            await _tourRepository.UpdateAsync(tour);
            return true;
        }
    }
}
