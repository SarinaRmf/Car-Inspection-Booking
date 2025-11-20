using HW20.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Dtos._common
{
    public class FilterModel
    {
        public DateTime? Date { get; set; }
        public ManufacturerEnum? Manufacturer { get; set; }

    }
}
