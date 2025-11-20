using HW20.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Entities
{
    public class Request : BaseEntity
    {
        
        public DateTime ReservationDate{ get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
        public bool IsApproved { get; set; }
        public bool Unacceptable { get; set; }
    }
}
