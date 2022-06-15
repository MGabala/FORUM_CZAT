namespace FORUM_CZAT.Pages.Gallery
{
    public class SiteModel : PageModel
    {
        private IWebHostEnvironment _environment;
        private IGalleryRepository _repository;
        [BindProperty]
        public FORUM_CZAT.Models.Gallery Gallery { get; set; }
        public IEnumerable<FORUM_CZAT.Models.Gallery> GalleryList { get; set; }

        public SiteModel(IWebHostEnvironment environment, IGalleryRepository repository)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task OnGetAsync()
        {
            GalleryList = await  _repository.GetAllVerifiedMedia();
        }
        public async Task OnPostAsync()
        {

        }
    }
}
