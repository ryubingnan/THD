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
    public class TicketAppService : AppService, ITicketAppService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketAppService(IMapper mapper, ITicketRepository ticketRepository) : base(mapper)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<List<TicketDto>> GetListAsync()
        {
            var tickets = await _ticketRepository.GetListAsync(stay => true);

            var dtos = Mapper.Map<List<TicketDto>>(tickets);
            return dtos;
        }

        public async Task<TicketDto> GetAsync(int id)
        {
            var ticket = await _ticketRepository.GetAsync(id);

            var dto = Mapper.Map<TicketDto>(ticket);
            return dto;
        }

        public async Task<PagedResultDto<TicketDto>> GetListAsync(TicketPagedQueryDto query)
        {
            Expression<Func<Ticket, bool>> predicate = e => true;
            if (!string.IsNullOrEmpty(query.Title)) predicate = predicate.And(e => e.Title.Contains(query.Title));
            if (!string.IsNullOrEmpty(query.Type)) predicate = predicate.And(e => e.Type.Contains(query.Type));
            predicate = predicate.And(t => !t.IsDelete);
            var dto = await GetListAsync<TicketPagedQueryDto, Ticket, PagedResultDto<TicketDto>, TicketDto>(query, _ticketRepository, predicate);

            return dto;
        }

        public async Task<int> AddOrEditAsync(TicketDto input)
        {
            var dto = Mapper.Map<Ticket>(input);
            Ticket ticket;
            if (dto.Id > 0)
            {
                ticket = await _ticketRepository.UpdateAsync(dto);
            }
            else
            {
                ticket = await _ticketRepository.InsertAsync(dto);
            }
            return ticket.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ticket = await _ticketRepository.GetAsync(id);
            if (ticket is null) return false;
            ticket.IsDelete = true;
            await _ticketRepository.UpdateAsync(ticket);
            return true;
        }
    }
}
