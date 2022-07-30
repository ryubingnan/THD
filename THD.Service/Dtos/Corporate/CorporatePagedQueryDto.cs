using System;
using System.Collections.Generic;
using System.Text;

namespace THD.Service.Dtos
{
    public class CorporatePagedQueryDto : PagedQueryDto
    {
        public string ContentsofInquiry { get; set; }
    }
}
