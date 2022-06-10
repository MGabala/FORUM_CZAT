

namespace FORUM_CZAT.Pages.HiddenWiki
{
    public class SiteModel : PageModel
    {
        private IURLRepository _repository;
        public IEnumerable<HiddenWikiEntity> Url { get; set; } = null!;
        public SiteModel(IURLRepository repository)
        {
            _repository = repository;
        }

        public async Task OnGetAsync()
            {
            Url = await _repository.GetAllVerifiedUrls();
            }
        public async Task<IActionResult> OnPostAsync(string url, bool isverified, string description)
        {
            _repository.AddURL(url, isverified, description, DateTime.Now);
            return RedirectToPage("/HiddenWiki/AfterUrlInformation");
        }
    }
}
