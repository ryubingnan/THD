using THD.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace THD.Web.Models.User
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public Gender? Gender { get; set; }
    }
}
