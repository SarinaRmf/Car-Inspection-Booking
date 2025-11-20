using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Entities
{
    public class CarOwner : BaseEntity
    {
        public string Phone {  get; set; }
        public string Address { get; set; }
        public string IdentityCode { get; set; }
        public List<Car> Cars { get; set; }
    }
}
