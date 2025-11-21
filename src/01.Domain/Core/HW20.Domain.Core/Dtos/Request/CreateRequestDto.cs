using HW20.Domain.Core.Entities;
using HW20.Domain.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Dtos.Request
{
    public class CreateRequestDto
    {
        public DateTime ReservationDate { get; set; }
        public int CarId { get; set; }
        public bool Unacceptable { get; set; }
        public List<IFormFile>? ImageFiles { get; set; }
    }
}
