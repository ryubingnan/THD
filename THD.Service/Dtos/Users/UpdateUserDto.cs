using THD.DataAccess.Enums;

namespace THD.Service.Dtos
{
    public class UpdateUserDto
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public Gender? Gender { get; set; }
    }
}
