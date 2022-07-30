using THD.DataAccess.Models.Abstract;

using System;
using System.Collections.Generic;
using System.Text;

namespace THD.DataAccess.Models
{
    public class Pay : EntityBase
    {
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
