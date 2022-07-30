using System;
using System.Collections.Generic;
using System.Text;

namespace THD.Service.Dtos
{
    public class TechnicianPagedQueryDto : PagedQueryDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
