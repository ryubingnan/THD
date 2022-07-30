using System;
using System.Collections.Generic;
using System.Text;

namespace THD.Service.Dtos.Carts
{
    public class PlayCartQuery
    {
        public int PlayId { get; set; }
        public string PlayStartDate { get; set; }
        public int Total { get; set; }
    }
}
