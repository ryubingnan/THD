using FluentValidation;
using THD.DataAccess.Enums;

namespace THD.Service.Dtos
{
    public class RegisterUserDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string EmailConfirmeToken { get; set; }

        public Gender? Gender { get; set; }

        public string Country { get; set; }

        public string Address { get; set; }

        public string QQ { get; set; }

        public string WeChat { get; set; }
    }

    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(3).MaximumLength(128).WithName("会员ID");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).MaximumLength(128)
                .Equal(x => x.ConfirmPassword).WithMessage("两次密码输入不相同")
                .WithName("密码");
            RuleFor(x => x.Email).NotEmpty().MaximumLength(128).EmailAddress().WithName("电子邮箱");
            RuleFor(x => x.Name).NotEmpty().MaximumLength(128).WithName("真实姓名");
            RuleFor(x => x.Phone).MaximumLength(20).WithName("手机");
            RuleFor(x => x.Country).MaximumLength(50).WithName("国家");
            RuleFor(x => x.Address).MaximumLength(150).WithName("地址");
            RuleFor(x => x.QQ).MaximumLength(150).WithName("QQ");
            RuleFor(x => x.WeChat).MaximumLength(150).WithName("微信");
        }
    }
}
