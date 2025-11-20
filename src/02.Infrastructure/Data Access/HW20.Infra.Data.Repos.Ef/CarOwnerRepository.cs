using HW20.Domain.Core.Contracts.Repository;
using HW20.Domain.Core.Dtos;
using HW20.Domain.Core.Entities;
using HW20.Infra.Db.SqlServer.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Infra.Data.Repos.Ef
{
    public class CarOwnerRepository(AppDbContext _context) : ICarOwnerRepository
    {
        public bool Create(CreateCarOwnerDto createOwnerDto)
        {
            var entity = new CarOwner()
            {
                Address = createOwnerDto.Address,
                CreatedAt = DateTime.Now,
                IdentityCode = createOwnerDto.IdentityCode,
                Phone = createOwnerDto.Phone,
            };
            _context.Owners.Add(entity);
            return _context.SaveChanges() > 0;
        }

        public bool IsExist(string identityCode)
        {
            return _context.Owners.Any(o => o.IdentityCode == identityCode);    
        }

        public int GetId(string identityCode) { 
        
            return _context.Owners.Where(o => o.IdentityCode == identityCode).Select(o => o.Id).FirstOrDefault();
        }
    }
}
