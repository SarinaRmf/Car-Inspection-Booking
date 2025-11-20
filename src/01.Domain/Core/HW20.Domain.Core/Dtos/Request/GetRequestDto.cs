using HW20.Domain.Core.Entities;
using HW20.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Dtos.Request
{
    public class GetRequestDto
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public string NumberPlate { get; set; }
        public string CarModel { get; set; }
        public ManufacturerEnum Manufacturer { get; set; }
        public string IdentityCode { get; set; }
        public string Phone {  get; set; }
        public bool IsApproved { get; set; }
        public bool Unacceptable { get; set; }
    }
}
