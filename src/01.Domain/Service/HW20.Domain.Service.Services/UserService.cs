using HW20.Domain.Core.Contracts.Repository;
using HW20.Domain.Core.Contracts.Services;
using HW20.Domain.Core.Dtos._common;
using HW20.Domain.Core.Dtos.User;
using HW20.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Service.Services
{
    public class UserService(IUserRepository _repo) : IUserService
    {
        public ResultDto<UserLoginDto> Login(string username, string password)
        {

            var result = _repo.Login(username, password.ToMd5Hex());
            if (result is null)
            {
                return new ResultDto<UserLoginDto> { IsSuccess = false, Message = "نام کاربری یا رمز عبور اشتباه است" };
            }
            return new ResultDto<UserLoginDto> { IsSuccess = true, Message = "لاگین با موفقیت انجام شد", Data = result };
        }
    }
}
