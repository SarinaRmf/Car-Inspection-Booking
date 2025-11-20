using HW20.Domain.Core.Contracts.Repository;
using HW20.Domain.Core.Dtos;
using HW20.Infra.Db.SqlServer.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Infra.Data.Repos.Ef
{
    public class CarModelRepository(AppDbContext _context) : ICarModelRepository
    {
        public List<GetCarModelDto> GetAll()
        {
            return _context.CarModels.Select(c => new GetCarModelDto
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();
        }
    }
}
