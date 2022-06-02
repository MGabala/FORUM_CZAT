using FORUM_CZAT.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FORUM_CZAT.Pages
{
    public class AdminApprovalPageModel : PageModel
    {
        private IPostBeforeApprovalRepository _repository;
        private readonly string _connectionString = string.Empty;
        public IEnumerable<ModelPost> Posts { get; set; }
        public AdminApprovalPageModel(IConfiguration configuration, IPostBeforeApprovalRepository repository)
        {
            _connectionString = configuration["ConnectionStrings:DB"];
            _repository = repository;
        }

            public async Task OnGet()
        {
            Posts = await _repository.GetAllPostsBeforeApprovalAsync();
        }
    }
}
