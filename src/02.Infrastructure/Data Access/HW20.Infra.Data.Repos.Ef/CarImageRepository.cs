using HW20.Domain.Core.Contracts.Repository;
using HW20.Domain.Core.Entities;
using HW20.Infra.Db.SqlServer.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Infra.Data.Repos.Ef
{
    public class CarImageRepository(AppDbContext _context) : ICarImageRepository
    {
        public void Create(List<CarImage> carImages) { 
        
            _context.CarImages.AddRange(carImages);
            _context.SaveChanges();
        }
        public List<string> GetAll(int requestId)
        {
            return _context.CarImages.Where(i => i.RequestId == requestId).Select(i => i.ImagePath).ToList();
        }
    }
}
