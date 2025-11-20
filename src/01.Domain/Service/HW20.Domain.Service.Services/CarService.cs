using HW20.Domain.Core.Contracts.Repository;
using HW20.Domain.Core.Contracts.Services;
using HW20.Domain.Core.Dtos._common;
using HW20.Domain.Core.Dtos.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Service.Services
{
    public class CarService(ICarRepository _repo) : ICarService
    {
        public bool OlderThanFive(int carId)
        {
            return DateTime.Now.Year - _repo.GetProducedDate(carId) > 5;
            
        }
        public ResultDto<int> Create(CreateCarDto createCarDto) {

            if (_repo.IsExist(createCarDto.NumberPlate)){
                return new ResultDto<int> { Data = _repo.GetId(createCarDto.NumberPlate) };
            }

            var result = _repo.Create(createCarDto);
            if (result)
            {
                return new ResultDto<int> { Data=_repo.GetId(createCarDto.NumberPlate) };
            }
            return new ResultDto<int> { IsSuccess = false, Message = "Something went wrong!" };

        }
    }
}
