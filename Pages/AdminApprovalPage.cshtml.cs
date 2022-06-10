using FORUM_CZAT.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;

namespace FORUM_CZAT.Pages
{
    public class AdminApprovalPageModel : PageModel
    {
        private IPostRepository _repository;
        private IURLRepository _urlrepository;
        private readonly string _connectionString = string.Empty;
        public IEnumerable<BeforeApprovalPost> Posts { get; set; }
        public IEnumerable<HiddenWikiEntity> Urls { get; set; }
        public AdminApprovalPageModel(IConfiguration configuration, IPostRepository repository, IURLRepository urlrepository)
        {
            _connectionString = configuration["ConnectionStrings:DB"];
            _repository = repository;
            _urlrepository = urlrepository;
        }

       public async Task OnGetAsync()
        {
            Posts = await _repository.GetAllPostsBeforeApprovalAsync();
            Urls = await _urlrepository.GetAllUnverifiedUrls();
        }
       public async Task<IActionResult> OnPostPosty(int id, int iddel)
        {
            if (id > 0) 
            {
                var query = $"insert into PostsAfterApproval select * from PostsBeforeApproval where id = {id}";
                var querydel = $"DELETE FROM [PostsBeforeApproval] WHERE id = {id}";
                using (var con = new SqliteConnection(_connectionString))
                using (var cmd = new SqliteCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
                using (var con = new SqliteConnection(_connectionString))
                using (var cmd = new SqliteCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = querydel;
                    cmd.ExecuteNonQuery();
                }
            }
            if (iddel > 0)
            {
                var query = $"DELETE FROM [PostsBeforeApproval] WHERE id = {iddel}";
                using (var con = new SqliteConnection(_connectionString))
                using (var cmd = new SqliteCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
            }
            return RedirectToPage("/AdminApprovalPage");

        }
        public async Task<IActionResult> OnPostURL(int id, int iddel)
        {
            return Page();
        }
    }
}
