using FORUM_CZAT.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FORUM_CZAT.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IPostRepository _repository;
        private readonly string _connectionString = string.Empty;
        public IEnumerable<AfterApprovalPost> AfterApprovalPost { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IPostRepository repository)
        {
            _logger = logger;
            _connectionString = configuration["ConnectionStrings:DB"];
            _repository = repository;
        }

        public async Task<IActionResult> OnPostAsync(string title, string description, string category, string author)
        {
            _repository.AddPost(title, description, author, category, DateTime.Now);
            return RedirectToPage("/AfterPostInformation");
        }
    }
}