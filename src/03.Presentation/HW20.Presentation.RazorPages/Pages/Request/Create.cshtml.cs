using HW20.Domain.Core.Contracts.ApplicationServices;
using HW20.Domain.Core.Dtos;
using HW20.Domain.Core.Dtos.Car;
using HW20.Domain.Core.Dtos.Request;
using HW20.Domain.Service.ApplicationServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW20.Presentation.RazorPages.Pages.Request
{
    public class CreateModel(ICarModelAppService carModelAppService, IRequestAppService requestAppService) : PageModel
    {
        [BindProperty]
        public CreateCarDto createCarDto { get; set; }
        [BindProperty]
        public CreateCarOwnerDto ownerDto { get; set; }
        [BindProperty]
        public CreateRequestDto requestDto { get; set; }
        public List<GetCarModelDto> CarModels { get; set; }
        public string Message { get; set; }

        public void OnGet()
        {
            CarModels = carModelAppService.GetAll();
        }
        public void OnPost()
        {
            CarModels = carModelAppService.GetAll();

            var result = requestAppService.Submit(ownerDto, requestDto, createCarDto);
            Message = result.Message;
        }
    }
}
