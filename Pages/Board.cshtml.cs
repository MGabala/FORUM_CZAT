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
        public async Task OnGetAsync(string category)
        {
            if (category == null)
            {
                AfterApprovalPost = await _repository.GetAllPostsAfterApprovalLast5Async();
            }
            else if(category == "Astronomy")
            {
                AfterApprovalPost = await _repository.GetAllPostsAfterApprovalForAstronomyAsync();
            }
            else if (category == "CryptoCurrencies")
            {
                AfterApprovalPost = await _repository.GetAllPostsAfterApprovalForCryptoCurrenciesAsync();
            }
            else if (category == "Programming")
            {
                AfterApprovalPost = await _repository.GetAllPostsAfterApprovalForProgrammingAsync();
            }
            else if (category == "Science")
            {
                AfterApprovalPost = await _repository.GetAllPostsAfterApprovalForScienceAsync();
            }
        }
    }
}