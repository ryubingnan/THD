using THD.DataAccess.Enums;

using System;
using System.ComponentModel.DataAnnotations;

namespace THD.Web.Models.User
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        [Display(Name = "姓名")]
        [Required(ErrorMessage = "{0}不可以为空")]
        public string Name { get; set; }

        public string Phone { get; set; }

        [Display(Name = "会员邮箱")]
        [Required(ErrorMessage = "{0}不可以为空")]
        public string Email { get; set; }

        [Display(Name = "会员地址")]
        [Required(ErrorMessage = "{0}不可以为空")]
        public string Address { get; set; }

        public string QQ { get; set; }

        public string WeChat { get; set; }

        public DateTimeOffset CreateTime { get; set; }

        [Display(Name = "会员身份")]
        [Required(ErrorMessage = "{0}不可以为空")]
        public string Type { get; set; }

        public string GSMC { get; set; }

        public string GSDH { get; set; }

        public string GSYX { get; set; }

        public string GSCZ { get; set; }

        public string GSDZ { get; set; }
    }
}
