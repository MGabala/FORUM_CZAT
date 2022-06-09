using FORUM_CZAT.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace FORUM_CZAT.Pages.Categories
{
    public class BoardModel : PageModel
    {
        private IPostRepository _repository;
        private readonly string _connectionString = string.Empty;
        public IEnumerable<AfterApprovalPost> AfterApprovalPost { get; set; } = null!;
        public IEnumerable<Comment> Comments { get; set; } = null!;
        private ForumContext _context;


        public BoardModel(IConfiguration configuration, IPostRepository repository, ForumContext context)
        {
            _connectionString = configuration["ConnectionStrings:DB"] ?? throw new ArgumentNullException(nameof(configuration));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task OnGetAsync(string category, int id)
        {
            Comments = _context.Comments.Where(x => x.PostId == id);

            if (category == null)
            {
                AfterApprovalPost = await _repository.GetAllPostsAfterApprovalLast5Async();
            }
            else
            {
                AfterApprovalPost = await _context.PostsAfterApproval
                    .Where(x => x.Category == category)
                    .OrderByDescending(x => x.CreationTime)
                    .ToListAsync();
            }
        }
        public async Task<IActionResult> OnPostAsync(int postid, string comment, string author)
        {
            await _repository.AddComent(postid, comment, author, DateTime.Now);
            return RedirectToPage("Index");
        }
    }
}