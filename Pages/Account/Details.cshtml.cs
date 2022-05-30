using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FORUM_CZAT.Pages.Account
{
    public class DetailsModel : PageModel
    {
        public string? Cookie { get; set; }
        public void OnGet()
        {
            Cookie = Request.Cookies[".AspNetCore.Identity.Application"];
        }
    }
}