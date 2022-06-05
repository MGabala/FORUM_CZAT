using FORUM_CZAT.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace FORUM_CZAT.Pages.Categories
{
    public class BoardModel : PageModel
    {
        private IPostRepository _repository;
        private readonly string _connectionString = string.Empty;
        public IEnumerable<AfterApprovalPost> AfterApprovalPost { get; set; }

        public BoardModel(IConfiguration configuration, IPostRepository repository)
        {
            _connectionString = configuration["ConnectionStrings:DB"];
            _repository = repository;
        }
        public async Task OnGetAsync()
        {
         
        }
    }
}