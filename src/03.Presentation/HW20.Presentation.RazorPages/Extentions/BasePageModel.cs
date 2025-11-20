using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW20.Presentation.RazorPages.Extentions
{
    public class BasePageModel : PageModel
    {
        public bool UserIsLoggedIn()
        {
            return Request.Cookies.Any(x => x.Key == "Id");
        }
    }
}
