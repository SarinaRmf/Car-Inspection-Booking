using HW20.Domain.Core.Contracts.Repository;
using HW20.Domain.Core.Dtos._common;
using HW20.Domain.Core.Dtos.Request;
using HW20.Domain.Core.Entities;
using HW20.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;

namespace HW20.Infra.Data.Repos.Ef
{
    public class RequestRepository(AppDbContext _context) : IRequestRepository
    {
        public bool Create(CreateRequestDto requestDto)
        {

            var entity = new Request()
            {
                CarId = requestDto.CarId,
                CreatedAt = DateTime.Now,
                IsApproved = false,
                ReservationDate = requestDto.ReservationDate,
                Unacceptable = requestDto.Unacceptable,
                
            };
            _context.Add(entity);
            return _context.SaveChanges() > 0;
        }
        public List<GetRequestDto> GetRequests()
        {
            return _context.Requests.Select(r => new GetRequestDto
            {
                Id = r.Id,
                Phone = r.Car.Owner.Phone,
                CarModel = r.Car.Model.Name,
                IsApproved = r.IsApproved,
                ReservationDate = r.ReservationDate,
                Unacceptable = r.Unacceptable,
                IdentityCode = r.Car.Owner.IdentityCode,
                Manufacturer = r.Car.Manufacturer,
                NumberPlate = r.Car.NumberPlate,
            }).ToList();

        }
        public bool SetApproveValue(int requestId, bool input)
        {
            return _context.Requests.Where(r => r.Id == requestId)
                .ExecuteUpdate(setters => setters
                .SetProperty(r => r.IsApproved, input)) > 0;
        }
        public int GetRequestCount(DateTime reservationDate)
        {
            return _context.Requests.Count(r => r.ReservationDate.Date== reservationDate.Date);
        }
        public bool RequestedThisYear(int carId, DateTime reservationDate)
        {
            return _context.Requests.Any(r => r.CarId == carId && r.ReservationDate.Year == reservationDate.Year);
        }
        public List<GetRequestDto> Filter(FilterModel filter)
        {
            var query = _context.Requests.AsQueryable();

            if (filter.Date.HasValue) {

                query = query.Where(r => r.ReservationDate == filter.Date);
            }
            if(filter.Manufacturer.HasValue)
            {
                query = query.Where(r => r.Car.Manufacturer == filter.Manufacturer);
            }
            return query.Select(r => new GetRequestDto
            {
                Manufacturer = r.Car.Manufacturer,
                Id = r.Id,
                CarModel = r.Car.Model.Name,
                IdentityCode = r.Car.Owner.IdentityCode,
                IsApproved = r.IsApproved,
                NumberPlate = r.Car.NumberPlate,
                Phone = r.Car.Owner.Phone,
                ReservationDate = r.ReservationDate,
                Unacceptable = r.Unacceptable
            }).ToList();

        }

        public GetRequestDto? Get(int requestId)
        {
            return _context.Requests.Where(r => r.Id == requestId).Select(r => new GetRequestDto
            {
                Id = r.Id,
                CarModel = r.Car.Model.Name,
                IsApproved = r.IsApproved,
                IdentityCode=r.Car.Owner.IdentityCode,
                Manufacturer = r.Car.Manufacturer,
                NumberPlate=r.Car.NumberPlate,
                Phone = r.Car.Owner.Phone,
                ReservationDate = r.ReservationDate,
                Unacceptable = r.Unacceptable
            }).FirstOrDefault();
        }
    }
}
