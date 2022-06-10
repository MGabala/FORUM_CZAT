using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FORUM_CZAT.Pages.HiddenWiki
{
    public class SiteModel : PageModel
    {
        public async Task OnGetAsync()
            {

            }
        public async Task<IActionResult> OnPostAsync()
        {
            return Page();
        }
    }
}
