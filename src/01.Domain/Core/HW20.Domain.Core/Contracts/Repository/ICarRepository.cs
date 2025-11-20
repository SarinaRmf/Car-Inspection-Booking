using HW20.Domain.Core.Dtos.Car;
using HW20.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Contracts.Repository
{
    public interface ICarRepository
    {
        bool Create(CreateCarDto createCarDto);
        int GetProducedDate(int carId);
        bool IsExist(string numberPlate);
        int GetId(string numberPlate);
    }
}
