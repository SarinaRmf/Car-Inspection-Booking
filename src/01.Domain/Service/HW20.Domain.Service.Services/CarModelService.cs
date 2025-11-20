using HW20.Domain.Core.Contracts.Repository;
using HW20.Domain.Core.Contracts.Services;
using HW20.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Service.Services
{
    public class CarModelService(ICarModelRepository _repo): ICarModelService
    {
        public List<GetCarModelDto> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
