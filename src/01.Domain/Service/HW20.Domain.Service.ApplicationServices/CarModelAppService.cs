using HW20.Domain.Core.Contracts.ApplicationServices;
using HW20.Domain.Core.Contracts.Services;
using HW20.Domain.Core.Dtos;

namespace HW20.Domain.Service.ApplicationServices
{
    public class CarModelAppService(ICarModelService carModelService) : ICarModelAppService
    {
        public List<GetCarModelDto> GetAll()
        {
            return carModelService.GetAll();
        }
    }
}
