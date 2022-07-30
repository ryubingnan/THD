using AutoMapper;
using THD.DataAccess.Models.Abstract;
using THD.DataAccess.Repositories.Abstract;
using THD.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace THD.Service.Implements.Abstract
{
    public abstract class AppService
    {
        public IMapper Mapper { get; protected set; }

        public AppService(IMapper mapper)
        {
            Mapper = mapper;
        }

        public async Task<TPagedResultDto> GetListAsync<TPagedQueryDto, TEntity, TPagedResultDto, TDto>(TPagedQueryDto query, IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate)
            where TPagedQueryDto : PagedQueryDto
            where TEntity : IEntity
            where TPagedResultDto : PagedResultDto<TDto>, new()
        {
            return await GetListCoreAsync<TPagedQueryDto, TEntity, TPagedResultDto, TDto, object>(query, repository, predicate);
        }

        public async Task<TPagedResultDto> GetListAsync<TPagedQueryDto, TEntity, TPagedResultDto, TDto, TOrderKey>(TPagedQueryDto query, IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TOrderKey>> keySelector, bool isAsc = true)
            where TPagedQueryDto : PagedQueryDto
            where TEntity : IEntity
            where TPagedResultDto : PagedResultDto<TDto>, new()
        {
            return await GetListCoreAsync<TPagedQueryDto, TEntity, TPagedResultDto, TDto, TOrderKey>(query, repository, predicate, keySelector: keySelector, isAsc: isAsc);
        }


        public async Task<TPagedResultDto> GetListAsync<TPagedQueryDto, TEntity, TPagedResultDto, TDto>(TPagedQueryDto query, IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate,
            IEnumerable<OrderCondition> orders)
            where TPagedQueryDto : PagedQueryDto
            where TEntity : IEntity
            where TPagedResultDto : PagedResultDto<TDto>, new()
        {
            return await GetListCoreAsync<TPagedQueryDto, TEntity, TPagedResultDto, TDto, object>(query, repository, predicate, orders: orders);
        }

        private async Task<TPagedResultDto> GetListCoreAsync<TPagedQueryDto, TEntity, TPagedResultDto, TDto, TOrderKey>(TPagedQueryDto query, IRepository<TEntity> repository, Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TOrderKey>> keySelector = null, bool isAsc = true, IEnumerable<OrderCondition> orders = null)
            where TPagedQueryDto : PagedQueryDto
            where TEntity : IEntity
            where TPagedResultDto : PagedResultDto<TDto>, new()
        {
            var totalCount = await repository.LongCountAsync(predicate);

            List<TEntity> entities;
            if (keySelector != null)
            {
                entities = await repository.GetListAsync(predicate, query.PageSize, (query.PageIndex - 1) * query.PageSize, keySelector, isAsc);
            }
            else if (orders?.Any() == true)
            {
                entities = await repository.GetListAsync(predicate, query.PageSize, (query.PageIndex - 1) * query.PageSize, orders);
            }
            else
            {
                entities = await repository.GetListAsync(predicate, query.PageSize, (query.PageIndex - 1) * query.PageSize);
            }

            var dto = MapToPagedResultDto<TEntity, TPagedResultDto, TDto>(entities, query.PageIndex, query.PageSize, totalCount);
            return dto;
        }

        public TPagedResultDto MapToPagedResultDto<TEntity, TPagedResultDto, TDto>(IReadOnlyList<TEntity> entities, int pageIndex, int pageSize, long totalCount)
            where TPagedResultDto : PagedResultDto<TDto>, new()
            where TEntity : IEntity
        {
            var items = Mapper.Map<IReadOnlyList<TDto>>(entities);

            return new TPagedResultDto
            {
                Items = items,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }
    }
}
