using System;
using System.Collections.Generic;
using System.Text;

namespace THD.Service.Dtos
{
    public class StayCartQuery
    {
        public int StayId { get; set; }
        public string StayStartDate { get; set; }
        public string StayEndDate { get; set; }
    }
}
