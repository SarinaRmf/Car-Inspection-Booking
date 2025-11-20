using HW20.Domain.Core.Contracts.Repository;
using HW20.Domain.Core.Dtos.User;
using HW20.Infra.Db.SqlServer.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Infra.Data.Repos.Ef
{
    public class UserRepository(AppDbContext _context) : IUserRepository
    {
        public UserLoginDto? Login(string username, string password)
        {
            return _context.Users.Where(u => u.Username == username && u.PasswordHash == password)
                .Select(u => new UserLoginDto
                {
                    userId = u.Id,
                    userName = u.Username,
                }).FirstOrDefault();

        }
    }
}
