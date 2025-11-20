using HW20.Domain.Core.Contracts.Repository;
using HW20.Domain.Core.Dtos._common;
using HW20.Domain.Core.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Contracts.Services
{
    public interface IUserService
    {
        ResultDto<UserLoginDto> Login(string username, string password);
    }
}
