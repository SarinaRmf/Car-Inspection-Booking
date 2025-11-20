using HW20.Domain.Core.Dtos._common;
using HW20.Domain.Core.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Contracts.ApplicationServices
{
    public interface IUserAppService
    {
        ResultDto<UserLoginDto> Login(string username, string password);
    }
}
