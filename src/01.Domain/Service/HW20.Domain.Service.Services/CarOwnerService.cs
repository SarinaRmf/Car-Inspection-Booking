using HW20.Domain.Core.Contracts.Repository;
using HW20.Domain.Core.Contracts.Services;
using HW20.Domain.Core.Dtos;
using HW20.Domain.Core.Dtos._common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Service.Services
{
    public class CarOwnerService(ICarOwnerRepository _repo) : ICarOwnerService
    {
        public ResultDto<int> Create(CreateCarOwnerDto createCarOwnerDto)
        {
            if (_repo.IsExist(createCarOwnerDto.IdentityCode))
            {
                return new ResultDto<int> { Data = _repo.GetId(createCarOwnerDto.IdentityCode) };
            }
            var result = _repo.Create(createCarOwnerDto);
            if (result)
            {
                return new ResultDto<int> { Data = _repo.GetId(createCarOwnerDto.IdentityCode) };
            }
            return new ResultDto<int> { IsSuccess = false, Message = "something went wrong" };
        }
    }
}
