using FORUM_CZAT.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.Sqlite;
using System.Linq;

namespace FORUM_CZAT.Pages.Forum
{
    public class BoardModel : PageModel
    {
        private IPostRepository _repository;
        private readonly string _connectionString = string.Empty;
        public IEnumerable<Post> Posts { get; set; } = null!;
        public IEnumerable<Comment> Comments { get; set; } = null!;
       public List<SelectListItem> Options { get; set; } = null!;
        private ForumContext _context;


        public BoardModel(IConfiguration configuration, IPostRepository repository, ForumContext context)
        {
            _connectionString = configuration["ConnectionStrings:DB"] ?? throw new ArgumentNullException(nameof(configuration));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task OnGetAsync(string category, int id)
        {
            Options = _context.Categories.Where(x=>x.IsVerified==true).Select(x => new SelectListItem
            {
                Value = x.Category,
                Text = x.Category
            }).ToList();

            Comments = _context.Comments.OrderBy(x => x.Id).Where(x=>x.IsVerified==true);
            if (category == null)
            {
                Posts = await _repository.GetLast5Posts();
            }
            else
            {
                Posts = await _context.Posts
                    .Where(x => x.Category == category && x.IsVerified == true)
                    .OrderByDescending(x => x.CreationTime)
                    .ToListAsync();
            }

        }
        public async Task<IActionResult> OnPostAsync(int postid, string comment, string author, bool isverified)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddComent(postid, comment, author, isverified, DateTime.Now);
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