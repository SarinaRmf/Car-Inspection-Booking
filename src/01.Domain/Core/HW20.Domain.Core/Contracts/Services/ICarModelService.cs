using HW20.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Contracts.Services
{
    public interface ICarModelService
    {
        List<GetCarModelDto> GetAll();
    }
}
