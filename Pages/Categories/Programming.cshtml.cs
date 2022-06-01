using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FORUM_CZAT.Pages.Categories
{
    public class ProgrammingModel : PageModel
    {
        public async Task OnGetAsync()
        {
        }
        public async Task OnPostAsync(string title, string description, string author, string category = "Programming")
        {
          
        }
    }
}
