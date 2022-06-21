using FORUM_CZAT.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FORUM_CZAT.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IPostRepository _repository;
        private ForumContext _context;

        private readonly string _connectionString = string.Empty;
        public IEnumerable<Post> AfterApprovalPost { get; set; } = null!;
        public List<SelectListItem> Options { get; set; } = null!;
        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IPostRepository repository, ForumContext context)
        {
            _logger = logger;
            _connectionString = configuration["ConnectionStrings:DB"];
            _repository = repository;
            _context = context;
        }
        public async Task OnGetAsync()
        {
            Options = await _context.Categories.Select(x => new SelectListItem
            {
                Value = x.Category,
                Text = x.Category
            }).ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync(string title, string description, string category, string author, bool isverified=false)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddPost(title, description, author, category, isverified, DateTime.Now);
                return RedirectToPage("/Thanks");
            }
           else
            {
                return Page();
            }
        }
        public async Task<IActionResult> OnPostCategory(string category, bool isverified)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddCategory(category, isverified);
                return RedirectToPage("/Thanks");
            }
            else
            {
                return Page();
            }
               
        }
    }
}