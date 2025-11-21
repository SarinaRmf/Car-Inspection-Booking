using HW20.Domain.Core.Entities;
using HW20.Domain.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Dtos.Car
{
    public class CreateCarDto
    {
        public string NumberPlate { get; set; }
        public int ProducedAt { get; set; }
        public ManufacturerEnum Company { get; set; }
        public int ModelId { get; set; }
        public int OwnerId { get; set; }
        
    }
}
