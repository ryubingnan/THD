using AutoMapper;

using THD.DataAccess.Models;
using THD.DataAccess.Repositories.Interfaces;
using THD.Service.Dtos;
using THD.Service.Dtos.Users;
using THD.Service.Implements.Abstract;
using THD.Service.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Volo.Abp;

namespace THD.Service.Implements
{
    public class UserAppService : AppService, IUserAppService
    {
        private readonly IUserRepository _userRepository;

        public UserAppService(IMapper mapper, IUserRepository userRepository)
            : base(mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetAsync(int id)
        {
            var user = await _userRepository.GetAsync(id);

            return Mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetListAsync()
        {
            var users = await _userRepository.GetListAsync(u => true);

            return Mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> LoginAsync(UserLoginQuery query)
        {
            var user = await _userRepository.GetAsync(u => u.UserName == query.UserName.ToUpper());

            if (user is null) throw new UserFriendlyException("用户名不存在");

            if (user.IsDelete && user.Identity == "NO") throw new UserFriendlyException("用户已退会");

            if (user.Password != query.Password) throw new UserFriendlyException("用户名或密码错误");

            return Mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> RegisterAsync(RegisterUserDto input)
        {
            var user = Mapper.Map<User>(input);

            var hasExist = (await _userRepository.GetAsync(u => u.UserName == input.UserName)) != null;
            if (hasExist) throw new UserFriendlyException($"{input.UserName} 已存在");

            hasExist = (await _userRepository.GetAsync(u => u.Email == input.Email)) != null;
            if (hasExist) throw new UserFriendlyException($"{input.Email} 已被使用");

            user.Type = "member";
            user.Identity = "OK";

            await _userRepository.InsertAsync(user);

            return Mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateAsync(CreateUserDto input)
        {
            var user = Mapper.Map<User>(input);

            await _userRepository.InsertAsync(user);

            return Mapper.Map<UserDto>(user);
        }

        public async Task RemoveAsync(int id)
        {
            var user = await _userRepository.GetAsync(id);

            if (user is null) return;

            if (user.UserName == "Admin") throw new UserFriendlyException("Can't Remove Admin");

            await _userRepository.DeleteAsync(user);
        }

        public async Task<UserDto> UpdateAsync(int id, UpdateUserDto input)
        {
            var user = await _userRepository.GetAsync(id);
            if (user is null) throw new UserFriendlyException("找不到用户");

            Mapper.Map(input, user);

            await _userRepository.UpdateAsync(user);

            return Mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> VerifyEmailAsync(string token, string email)
        {
            if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(email))
            {
                return null;
            }

            var user = await _userRepository.GetAsync(u => u.Email == email);
            if (user is null || user.EmailConfirmeToken != token)
            {
                return null;
            }

            if (!user.EmailConfirmed)
            {
                user.EmailConfirmed = true;
                await _userRepository.UpdateAsync(user);
            }

            return Mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> EditAsync(UserDto input)
        {
            var user = await _userRepository.GetAsync(input.Id);
            if (user is null) throw new UserFriendlyException("找不到用户");

            Mapper.Map(input, user);

            user = await _userRepository.UpdateAsync(user);

            return Mapper.Map<UserDto>(user);
        }

        public async Task<PagedResultDto<UserDto>> GetListAsync(MemberPagedQueryDto input)
        {
            Expression<Func<User, bool>> predicate = e => true;
            if (!string.IsNullOrEmpty(input.Name)) predicate = predicate.And(e => e.Name.Contains(input.Name));
            if (!string.IsNullOrEmpty(input.Email)) predicate = predicate.And(e => e.Email.Contains(input.Email));
            if (input.IsOff) predicate = predicate.And(e => e.IsDelete);
            else predicate = predicate.And(e => !e.IsDelete && e.Identity == "OK");
            var dto = await GetListAsync<MemberPagedQueryDto, User, PagedResultDto<UserDto>, UserDto>(input, _userRepository, predicate);
            return dto;
        }

        public async Task<bool> MemberAgree(int id)
        {
            var user = await _userRepository.GetAsync(id);
            user.Identity = "NO";
            user = await _userRepository.UpdateAsync(user);
            return user.Id > 0;
        }
    }
}
