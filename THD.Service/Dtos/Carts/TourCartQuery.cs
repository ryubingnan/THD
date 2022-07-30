using System;
using System.Collections.Generic;
using System.Text;

namespace THD.Service.Dtos
{
    public class TourCartQuery
    {
        public int TourId { get; set; }
        public string TourStartDate { get; set; }
        public int Total { get; set; }
    }
}
