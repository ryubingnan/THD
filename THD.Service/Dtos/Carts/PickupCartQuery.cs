using System;
using System.Collections.Generic;
using System.Text;

namespace THD.Service.Dtos
{
    public class PickupCartQuery
    {
        public int PickupId { get; set; }
        public string PickupStartDate { get; set; }
        public int Total { get; set; }
    }
}
