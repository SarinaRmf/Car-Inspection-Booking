using HW20.Domain.Core.Contracts.Repository;
using HW20.Domain.Core.Dtos.Car;
using HW20.Domain.Core.Entities;
using HW20.Infra.Db.SqlServer.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Infra.Data.Repos.Ef
{
    public class CarRepository(AppDbContext _context) : ICarRepository
    {
        public bool Create(CreateCarDto createCarDto)
        {
            var entity = new Car()
            {
                Manufacturer = createCarDto.Company,
                CreatedAt = DateTime.Now,
                ModelId = createCarDto.ModelId,
                OwnerId = createCarDto.OwnerId,
                ProducedAtYear = createCarDto.ProducedAt,
                NumberPlate = createCarDto.NumberPlate,
                
            };
            _context.Add(entity);
            return _context.SaveChanges() > 0;
        }
        public int GetProducedDate(int cardId)
        {
            return _context.Cars.Where(c => c.Id== cardId).Select(c => c.ProducedAtYear).FirstOrDefault();
        }

        public bool IsExist(string numberPlate)
        {
            return _context.Cars.Any(c => c.NumberPlate==numberPlate);
        }
        public int GetId(string numberPlate) { 
        
            return _context.Cars.Where(c => c.NumberPlate == numberPlate).Select(c => c.Id).FirstOrDefault();
        }
    }
}
