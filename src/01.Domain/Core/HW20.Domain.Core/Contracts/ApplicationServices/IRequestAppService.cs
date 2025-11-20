using HW20.Domain.Core.Dtos;
using HW20.Domain.Core.Dtos._common;
using HW20.Domain.Core.Dtos.Car;
using HW20.Domain.Core.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Contracts.ApplicationServices
{
    public interface IRequestAppService
    {
        List<GetRequestDto> Filter(FilterModel filter);
        List<GetRequestDto> GetAll();
        GetRequestDto Get(int requestId);
        bool SetApproveValue(int requestId, bool input);
        ResultDto<bool> Submit(CreateCarOwnerDto createCarOwnerDto, CreateRequestDto createRequestDto, CreateCarDto createCarDto);
    }
}
