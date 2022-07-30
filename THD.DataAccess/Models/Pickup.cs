using THD.DataAccess.Models.Abstract;

using System;
using System.Collections.Generic;
using System.Text;

namespace THD.DataAccess.Models
{
    public class Pickup : EntityBase
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public int? Price { get; set; }
        public int? PriceNew { get; set; }
        public string Area { get; set; }
        public string Info { get; set; }
        public string Contents { get; set; }
        public string Info1 { get; set; }
        public string Info2 { get; set; }
        public string Info3 { get; set; }
        public string Info4 { get; set; }
        public string Info5 { get; set; }
        public string Info6 { get; set; }
        public string Info7 { get; set; }
        public string Info8 { get; set; }
        public string Info9 { get; set; }
        public string Info10 { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public string Img4 { get; set; }
        public string Img5 { get; set; }
        public string Img6 { get; set; }
        public string Img7 { get; set; }
        public string Img8 { get; set; }
        public string Img9 { get; set; }
        public string Img10 { get; set; }
        public string Datein { get; set; }
        public string Pid { get; set; }
        public string Map { get; set; }
        public string Video { get; set; }
        public string Supplier { get; set; }
        public string Features { get; set; }
        public string Category { get; set; }
        public bool IsDelete { get; set; }
    }
}
