using System;
using System.Collections.Generic;
using System.Text;

namespace THD.Service.Dtos.Pays
{
    public class PayInfoDto
    {
        public string UserName { get; set; }
        public PayDto PayDto { get; set; }

        public List<CartDto> CartDtos { get; set; }
    }
}
