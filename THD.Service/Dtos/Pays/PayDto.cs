using System;
using System.Collections.Generic;
using System.Text;

namespace THD.Service.Dtos
{
    public class PayDto
    {
        public int Id { get; set; }
        public string PayId { get; set; }
        public string Status { get; set; }
        public string PayType { get; set; }
        public string PayDate { get; set; }
        public string AllTotalPrice { get; set; }
        public string UserId { get; set; }
        public string Datein { get; set; }
        public string FromWhere { get; set; }
    }
}
