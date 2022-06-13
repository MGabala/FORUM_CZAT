using FORUM_CZAT.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace FORUM_CZAT.Pages.Forum
{
    public class BoardModel : PageModel
    {
        private IPostRepository _repository;
        private readonly string _connectionString = string.Empty;
        public IEnumerable<Post> Posts { get; set; } = null!;
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
            Comments = _context.Comments.OrderBy(x => x.Id);
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
        public async Task<IActionResult> OnPostAsync(int postid, string comment, string author)
        {
            await _repository.AddComent(postid, comment, author, DateTime.Now);
            return RedirectToPage("Board");
        }
    }
}