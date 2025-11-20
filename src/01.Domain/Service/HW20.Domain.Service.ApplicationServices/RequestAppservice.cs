using HW20.Domain.Core.Contracts.ApplicationServices;
using HW20.Domain.Core.Contracts.Services;
using HW20.Domain.Core.Dtos;
using HW20.Domain.Core.Dtos._common;
using HW20.Domain.Core.Dtos.Car;
using HW20.Domain.Core.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Service.ApplicationServices
{
    public class RequestAppservice(IRequestService requestService, ICarOwnerService carOwnerService, ICarService carService) : IRequestAppService
    {
        public List<GetRequestDto> Filter(FilterModel filter)
        {
            return requestService.Filter(filter);
        }

        public GetRequestDto Get(int requestId)
        {
            return requestService.Get(requestId);
        }

        public List<GetRequestDto> GetAll()
        {
            return requestService.GetAll();
        }

        public bool SetApproveValue(int requestId, bool input)
        {
            return requestService.SetApproveValue(requestId, input);
        }

        public ResultDto<bool> Submit(CreateCarOwnerDto createCarOwnerDto, CreateRequestDto createRequestDto , CreateCarDto createCarDto)
        {
            var carOwnerId = carOwnerService.Create(createCarOwnerDto).Data;

            createCarDto.OwnerId = carOwnerId;

            var carId = carService.Create(createCarDto).Data;

            createRequestDto.CarId = carId;

            if (requestService.RequestedBefore(carId, createRequestDto.ReservationDate))
            {
                return ResultDto<bool>.Failure("خودرو فقط یک بار در سال میتواند در خواست معاینه فنی داشته باشد!");
            }

            var checkDay = requestService.ValidateDay(createCarDto.Company,createRequestDto.ReservationDate);
            if(checkDay.IsSuccess == false)
            {
                return ResultDto<bool>.Failure(checkDay.Message);
            }

            var checkCapacity = requestService.CheckCapacity(createRequestDto.ReservationDate);
            if (checkCapacity.IsSuccess == false) {
                return ResultDto<bool>.Failure(checkCapacity.Message);
            }

            if (carService.OlderThanFive(carId))
            {
                createRequestDto.Unacceptable = true;
            }
            var result = requestService.SubmitRequest(createRequestDto);

            
            if (result.IsSuccess == false) {
                return ResultDto<bool>.Failure(result.Message);
            }
            if (createRequestDto.Unacceptable)
            {
                return ResultDto<bool>.Failure("طول عمر خودرو بیشتر از 5 سال است! درخواست پذیرفته نمی شود!.");
            }
            return ResultDto<bool>.Success(result.Message);
        }
    }
}
