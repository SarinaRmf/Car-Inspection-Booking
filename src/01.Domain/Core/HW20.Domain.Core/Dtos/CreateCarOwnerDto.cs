using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Dtos
{
    public class CreateCarOwnerDto
    {
        public string Phone { get; set; }
        public string Address { get; set; }
        public string IdentityCode { get; set; }
    }
}
