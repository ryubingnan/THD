using System;
using System.Collections.Generic;
using System.Text;

namespace THD.Service.Dtos
{
    public class ItListInfoPagedQueryDto : PagedQueryDto
    {
        public string Title { get; set; }

        public string Type { get; set; }
    }
}
