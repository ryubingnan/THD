using System;
using System.Collections.Generic;
using System.Text;

namespace THD.Service.Dtos
{
    public class CorporateDto
    {
        public int Id { get; set; }
        public string ContentsofInquiry { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public string Mei { get; set; }
        public string BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ErrorCode { get; set; }
        public string ProposalNumber { get; set; }
        public string Content { get; set; }
    }
}
