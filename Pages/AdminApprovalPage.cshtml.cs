using FORUM_CZAT.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;

namespace FORUM_CZAT.Pages
{
    public class AdminApprovalPageModel : AdminPageModel
    {
        private IPostRepository _repository;
        private IURLRepository _urlrepository;
        private ForumContext _context;
        private readonly string _connectionString = string.Empty;
        public IEnumerable<Post> Posts { get; set; } = null!;
        public IEnumerable<HiddenWikiEntity> Urls { get; set; } = null!;
        public IEnumerable<Categories> Categories { get; set; } = null!;

        [BindProperty]
        public HiddenWikiEntity _Url { get; set; } = null!;
        [BindProperty]
        public Post _Post { get; set; } = null!;
        [BindProperty]
        public Categories _Category{ get; set; } = null!;

        public AdminApprovalPageModel(IConfiguration configuration, IPostRepository repository, IURLRepository urlrepository, ForumContext context)
        {
            _connectionString = configuration["ConnectionStrings:DB"];
            _repository = repository;
            _urlrepository = urlrepository;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Categories = await _repository.GetAllUnverifiedCategories();
            Posts = await _repository.GetAllUnverifiedPosts();
            Urls = await _urlrepository.GetAllUnverifiedUrls();
        }
       public async Task<IActionResult> OnPostPosty(int id, int iddel)
        {
            _Post.Id = id;
            if (id > 0)
            {
                await _repository.CheckPost(_Post);
            }
            if (iddel > 0)
            {
                await _repository.DeletePost(iddel);
            }
            return RedirectToPage("/AdminApprovalPage");

        }
        public async Task<IActionResult> OnPostURL(int id, int iddel)
        {
            _Url.Id = id;
            if (id > 0)
            {
                await _urlrepository.CheckURL(_Url);
            }
            if (iddel > 0)
            {
                await _urlrepository.DeleteUrl(iddel);
            }
            return RedirectToPage("/AdminApprovalPage");
        }
        public async Task<IActionResult> OnPostCategories(int id, int iddel)
        {
            _Category.Id = id;
            if (id > 0)
            {
                await _repository.CheckCategory(_Category);
            }
            if(iddel > 0)
            {
                await _repository.DeleteCategory(iddel);
            }
            return RedirectToPage("/AdminApprovalPage");
        }

    }

}
