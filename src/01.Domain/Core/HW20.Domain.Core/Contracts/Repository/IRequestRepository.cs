using HW20.Domain.Core.Dtos._common;
using HW20.Domain.Core.Dtos.Request;
using HW20.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Contracts.Repository
{
    public interface IRequestRepository
    {
        bool Create(CreateRequestDto requestDto);
        List<GetRequestDto> GetRequests();
        bool SetApproveValue(int requestId, bool input);
        int GetRequestCount(DateTime reservationDate);
        bool RequestedThisYear(int carId, DateTime reservationDate);
        List<GetRequestDto> Filter(FilterModel filter);
        GetRequestDto Get(int requestId);
    }
}
