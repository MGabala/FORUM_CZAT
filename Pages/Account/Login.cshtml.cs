using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FORUM_CZAT.Pages.Account
{
    public class LoginModel : PageModel
    {
        private SignInManager<IdentityUser> signInManager;
        public LoginModel(SignInManager<IdentityUser> signinMgr)
        {
            signInManager = signinMgr;
        }
        [BindProperty]
        public string UserName { get; set; } = string.Empty;
        [BindProperty]
        public string Password { get; set; } = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string? ReturnUrl { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result =
                    await signInManager.PasswordSignInAsync(UserName, Password,
                        false, false);
                if (result.Succeeded)
                {
                    return Redirect(ReturnUrl ?? "/");
                }
                ModelState.AddModelError("", "Invalid username or password");
            }
            return Page();
        }
    }
}