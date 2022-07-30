using THD.Service.Dtos;
using THD.Service.Dtos.Users;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace THD.Service.Interfaces
{
    public interface IUserAppService
    {
        Task<UserDto> LoginAsync(UserLoginQuery query);

        Task<UserDto> RegisterAsync(RegisterUserDto input);

        Task<UserDto> GetAsync(int id);

        Task<IEnumerable<UserDto>> GetListAsync();

        Task<UserDto> CreateAsync(CreateUserDto input);

        Task<UserDto> UpdateAsync(int id, UpdateUserDto input);

        Task RemoveAsync(int id);

        Task<UserDto> VerifyEmailAsync(string token, string email);

        Task<UserDto> EditAsync(UserDto input);

        Task<PagedResultDto<UserDto>> GetListAsync(MemberPagedQueryDto input);

        Task<bool> MemberAgree(int id);
    }
}
