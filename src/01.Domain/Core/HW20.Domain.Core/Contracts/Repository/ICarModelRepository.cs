using HW20.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Core.Contracts.Repository
{
    public interface ICarModelRepository
    {
        List<GetCarModelDto> GetAll();
    }
}
