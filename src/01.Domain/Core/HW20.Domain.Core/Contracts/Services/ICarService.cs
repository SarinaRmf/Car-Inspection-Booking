using HW20.Domain.Core.Dtos._common;
using HW20.Domain.Core.Dtos.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Contracts.Services
{
    public interface ICarService
    {
        bool OlderThanFive(int carId);
        ResultDto<int> Create(CreateCarDto createCarDto);
    }
}
