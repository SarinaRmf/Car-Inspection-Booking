using HW20.Domain.Core.Contracts.ApplicationServices;
using HW20.Domain.Core.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW20.Domain.Service.ApplicationServices
{
    public class CarImageAppService(ICarImageService carImageService) : ICarImageAppService
    {
        public List<string> GetAll(int requestId)
        {
            return carImageService.GetAll(requestId);
        }
    }
}
