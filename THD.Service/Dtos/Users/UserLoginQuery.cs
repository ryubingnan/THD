using FluentValidation;

namespace THD.Service.Dtos
{
    public class UserLoginQuery
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }

    public class UserLoginQueryValidator : AbstractValidator<UserLoginQuery>
    {
        public UserLoginQueryValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithName("会员ID");
            RuleFor(x => x.Password).NotEmpty().WithName("密码");
        }
    }
}
