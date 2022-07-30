using System;
using System.Collections.Generic;
using System.Text;

namespace THD.Service.Dtos
{
    public class FoodCartQuery
    {
        public int FoodId { get; set; }
        public string FoodStartDate { get; set; }
        public int Total { get; set; }
    }
}
