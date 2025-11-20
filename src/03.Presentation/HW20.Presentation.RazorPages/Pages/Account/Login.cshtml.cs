using HW20.Domain.Core.Contracts.ApplicationServices;
using HW20.Domain.Core.Dtos.User;
using HW20.Domain.Core.Entities;
using HW20.Presentation.RazorPages.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW20.Presentation.RazorPages.Pages.Account
{
    public class LoginModel(IUserAppService userAppService, ICookieService cookieService) : BasePageModel
    {
        [BindProperty]
        public GetUserDto Admin {  get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost() { 
        
            var result = userAppService.Login(Admin.UserName,Admin.Password);
            if (result.IsSuccess)
            {
                cookieService.Set("Id",result.Data.userId.ToString());
                cookieService.Set("Username", result.Data.userName);

                return RedirectToPage("/Request/Index");
            }

            Message = result.Message;
            return Page();
        }
    }
}
