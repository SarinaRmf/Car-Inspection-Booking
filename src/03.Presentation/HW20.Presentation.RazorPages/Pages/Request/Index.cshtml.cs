using HW20.Domain.Core.Contracts.ApplicationServices;
using HW20.Domain.Core.Dtos._common;
using HW20.Domain.Core.Dtos.Request;
using HW20.Presentation.RazorPages.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW20.Presentation.RazorPages.Pages.Request
{
    public class IndexModel(IRequestAppService requestAppService) : BasePageModel
    {
        public List<GetRequestDto> Requests { get; set; }

        [BindProperty]
        public FilterModel filterModel { get; set; }
        public void OnGet()
        {
            Requests = requestAppService.GetAll();
            
        }
        public void OnPost() { 
            Requests = requestAppService.Filter(filterModel);
            
        }
        public IActionResult OnGetAccept(int Id)
        {
            var result = requestAppService.SetApproveValue(Id,true);
            return RedirectToPage("/Request/Index");
        }
        public IActionResult OnGetUnAccept(int Id)
        {
            var result = requestAppService.SetApproveValue(Id, false);
            return RedirectToPage("/Request/Index");
        }
    }
}
