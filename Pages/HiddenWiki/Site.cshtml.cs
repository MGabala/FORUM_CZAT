

namespace FORUM_CZAT.Pages.HiddenWiki
{
    public class SiteModel : PageModel
    {
        private IURLRepository _repository;
        public IEnumerable<HiddenWikiEntity> _Url { get; set; } = null!;
        public SiteModel(IURLRepository repository)
        {
            _repository = repository;
        }

        public async Task OnGetAsync()
            {
            _Url = await _repository.GetAllVerifiedUrls();
            }
        public async Task<IActionResult> OnPostAsync(string url, bool isverified, string description)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddURL(url, isverified, description, DateTime.Now);
                return RedirectToPage("/Thanks");
            }
            else
            {
                return Page();
            }
                
        }
    }
}
