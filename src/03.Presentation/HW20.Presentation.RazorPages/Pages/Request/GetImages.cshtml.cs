using HW20.Domain.Core.Contracts.ApplicationServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW20.Presentation.RazorPages.Pages.Request
{
    public class GetImagesModel(ICarImageAppService carImageApp) : PageModel
    {
        public List<string> ImagePaths { get; set; }
        public void OnGet(int id)
        {
            ImagePaths = carImageApp.GetAll(id);
        }
    }
}
