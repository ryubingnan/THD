using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace THD.Web.Models.User
{
    public class UserPwdViewModel
    {
        public int Id { get; set; }

        [Display(Name = "旧密码")]
        [Required(ErrorMessage = "{0}不可以为空")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "新密码")]
        [Required(ErrorMessage = "{0}不可以为空")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "再次输入新密码")]
        [Required(ErrorMessage = "再次输入新密码")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmePassword { get; set; }
    }
}
