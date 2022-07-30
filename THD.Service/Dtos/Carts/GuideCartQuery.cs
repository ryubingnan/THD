using System;
using System.Collections.Generic;
using System.Text;

namespace THD.Service.Dtos.Carts
{
    public class GuideCartQuery
    {
        public int GuideId { get; set; }
        public string GuideStartDate { get; set; }
        public int Total { get; set; }
    }
}
