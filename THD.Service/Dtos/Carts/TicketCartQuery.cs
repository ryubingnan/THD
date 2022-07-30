using System;
using System.Collections.Generic;
using System.Text;

namespace THD.Service.Dtos
{
    public class TicketCartQuery
    {
        public int TicketId { get; set; }
        public string TicketStartDate { get; set; }
        public string TicketEndDate { get; set; }
    }
}
