using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Entities
{
    public class CarModel: BaseEntity
    {
        public List<Car>? Cars { get; set;}
        public string Name { get; set;}
    }
}
