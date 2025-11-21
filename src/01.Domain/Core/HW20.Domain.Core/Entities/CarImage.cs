using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Entities
{
    public class CarImage : BaseEntity
    {
        public string ImagePath { get; set; }
        public Request Request { get; set; }
        public int RequestId { get; set; }
    }
}


