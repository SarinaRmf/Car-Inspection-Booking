using HW20.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Entities
{
    public class Car : BaseEntity
    {

        public string NumberPlate { get; set; }
        public int ProducedAtYear { get; set; }
        public ManufacturerEnum Manufacturer { get; set; }
        public CarModel Model { get; set; }
        public int ModelId { get; set; }
        public List<Request>? Requests { get; set; }
        public CarOwner Owner { get; set; }
        public int OwnerId { get; set; }
        public List<CarImage>? CarImages { get; set; }
    }
}
