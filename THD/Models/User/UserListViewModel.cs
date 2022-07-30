using THD.DataAccess.Enums;
using THD.DataAccess.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace THD.Web.Models.User
{
    public class UserListViewModel
    {
        public List<UserListItemViewModel> Users { get; set; }
    }

    public class UserListItemViewModel
    {
        public int Id { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public Gender? Gender { get; set; }

        public string GenderDesc => Gender?.GetDescription();

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTimeOffset CreateTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTimeOffset? UpdateTime { get; set; }
    }
}
