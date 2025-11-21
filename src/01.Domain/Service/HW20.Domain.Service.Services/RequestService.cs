using HW20.Domain.Core.Contracts.Repository;
using HW20.Domain.Core.Contracts.Services;
using HW20.Domain.Core.Dtos;
using HW20.Domain.Core.Dtos._common;
using HW20.Domain.Core.Dtos.Car;
using HW20.Domain.Core.Dtos.Request;
using HW20.Domain.Core.Enums;
using HW20.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Service.Services
{
    public class RequestService(IRequestRepository _repo, ICarService carService) : IRequestService
    {

        public bool IsEvenDate(DateTime date)
        {
            if(date.DayOfWeek == DayOfWeek.Saturday ||
                date.DayOfWeek == DayOfWeek.Monday ||
                date.DayOfWeek == DayOfWeek.Wednesday)
            {
                return true;
            }
            return false;
        }
        public ResultDto<bool> ValidateDay(ManufacturerEnum manufacturer, DateTime reservationDate)
        {
            if (reservationDate.Date < DateTime.Now.Date) {
                return ResultDto<bool>.Failure("لطفا تاریخ درستی را وارد کنید!");
            }
            if (IsEvenDate(reservationDate) && manufacturer == Core.Enums.ManufacturerEnum.SAIPA)
            {
                return ResultDto<bool>.Failure("سایپا  فقط در روزهای فرد پذیرش می شود!");
            }
            if (!IsEvenDate(reservationDate) && manufacturer == Core.Enums.ManufacturerEnum.IranKhodro)
            {
                return ResultDto<bool>.Failure("ایران خودرو فقط در روزهای زوج پذیرش می شود!");
            }
            return ResultDto<bool>.Success("");
        }

        public List<GetRequestDto> GetAll()
        {

            return _repo.GetRequests();
        }

        public ResultDto<bool> CheckCapacity(DateTime reservationDate) { 
        
        
            if(reservationDate.Day % 2 == 0)
            {
                if(_repo.GetRequestCount(reservationDate) > 10)
                {
                    return ResultDto<bool>.Failure("ظرفیت روز تکمیل شده است!");
                }
            }
            else
            {
                if(_repo.GetRequestCount(reservationDate) > 15)
                {
                    return ResultDto<bool>.Failure("ظرفیت روز تکمیل شده است!");
                }
            }
            return ResultDto<bool>.Success("");
        }

        public bool RequestedBefore(int carId,DateTime reservationDate)
        {
            return _repo.RequestedThisYear(carId, reservationDate);
        }
        public ResultDto<int> SubmitRequest(CreateRequestDto createRequestDto) {

            //createRequestDto.ReservationDate = DateConvertor.PersianToGregorian(createRequestDto.ReservationDate);

            var requestId = _repo.Create(createRequestDto);
            if (requestId > 0)
            {
                return ResultDto<int>.Success("در خواست با موفقیت ثبت شد.", requestId);
            }
            return ResultDto<int>.Failure("درخواست ثبت نشد! دوباره تلاش کنید!");
        }

        public List<GetRequestDto> Filter(FilterModel filter) {
        
            return _repo.Filter(filter);
        }

        public GetRequestDto Get(int requestId)
        {
            return _repo.Get(requestId);
        }

        public bool SetApproveValue(int requestId, bool input)
        {
            return _repo.SetApproveValue(requestId, input);
        }

       
    }
}
