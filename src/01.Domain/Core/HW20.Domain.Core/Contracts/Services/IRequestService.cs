using HW20.Domain.Core.Dtos._common;
using HW20.Domain.Core.Dtos.Request;
using HW20.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Contracts.Services
{
    public interface IRequestService
    {
        ResultDto<bool> ValidateDay(ManufacturerEnum manufacturer, DateTime reservationDate);
        ResultDto<bool> CheckCapacity(DateTime reservationDate);
        ResultDto<int> SubmitRequest(CreateRequestDto createRequestDto);
        bool RequestedBefore(int carId, DateTime reservationDate);
        List<GetRequestDto> GetAll();
        List<GetRequestDto> Filter(FilterModel filter);
        GetRequestDto Get(int requestId);
        bool SetApproveValue(int requestId, bool input);
    }
}
