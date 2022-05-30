using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FORUM_CZAT.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private SignInManager<IdentityUser> signInManager;
        public LogoutModel(SignInManager<IdentityUser> signInMgr)
        {
            signInManager = signInMgr;
        }
        public async Task OnGetAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
