namespace FORUM_CZAT.Pages.Gallery
{
    public class SiteModel : PageModel
    {

        private IGalleryRepository _repository;
        [BindProperty]
        public FORUM_CZAT.Models.Gallery Media { get; set; }
        public IEnumerable<FORUM_CZAT.Models.Gallery> GalleryList { get; set; }

        public SiteModel(IGalleryRepository repository)
        {
            
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task OnGetAsync()
        {
             GalleryList = await  _repository.GetAllUnverifiedMedia();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(Media.Upload != null)
            {
                await _repository.AddMedia(Media);
            }
            return RedirectToPage("/Gallery/Site");
        }
    }
}
