using THD.DataAccess.Enums;
using THD.DataAccess.Models.Abstract;

using System;

namespace THD.DataAccess.Models
{
    public class User : EntityBase
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string EmailConfirmeToken { get; set; }

        public Gender? Gender { get; set; }

        public string Country { get; set; }

        public string Address { get; set; }

        public string QQ { get; set; }

        public string WeChat { get; set; }

        public DateTimeOffset CreateTime { get; set; }

        public DateTimeOffset? UpdateTime { get; set; }

        public string Type { get; set; }

        public string Identity { get; set; }

        public int Point { get; set; }

        public string Pic { get; set; }

        public string GSMC { get; set; }

        public string GSDH { get; set; }

        public string GSYX { get; set; }

        public string GSCZ { get; set; }

        public string GSDZ { get; set; }

        public bool IsDelete { get; set; }
    }
}
