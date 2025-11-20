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
        public void Create(int carId, string ImagePath) { 
        
            var carImage = new CarImage
            {
                CarId = carId,  
                ImagePath = ImagePath
            };
            _context.CarImages.Add(carImage);
            _context.SaveChanges();
        }
    }
}
