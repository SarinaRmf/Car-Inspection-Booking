using HW20.Domain.Core.Dtos;
using HW20.Domain.Core.Dtos._common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Contracts.Services
{
    public interface ICarOwnerService
    {
        ResultDto<int> Create(CreateCarOwnerDto createCarOwnerDto);
    }
}
