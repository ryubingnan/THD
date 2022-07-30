using THD.DataAccess.Models.Abstract;

using System;
using System.Collections.Generic;
using System.Text;

namespace THD.DataAccess.Models
{
    public class Cart : EntityBase
    {
        public string Pid { get; set; }
        public string Img1 { get; set; }
        public string Country { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public int? Price { get; set; }
        public int? Num { get; set; }
        public int? TotalPrice { get; set; }
        public bool? Del { get; set; }
        public string Datein { get; set; }
        public string UserId { get; set; }
        public string Keyword { get; set; }
        public string PayId { get; set; }
        public string Info { get; set; }
        public string DateEnd { get; set; }
        public string DateStart { get; set; }
    }
}
