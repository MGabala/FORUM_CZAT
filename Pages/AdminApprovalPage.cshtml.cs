using FORUM_CZAT.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;

namespace FORUM_CZAT.Pages
{
    public class AdminApprovalPageModel : PageModel
    {
        private IPostRepository _repository;
        private readonly string _connectionString = string.Empty;
        public IEnumerable<BeforeApprovalPost> Posts { get; set; }
        public AdminApprovalPageModel(IConfiguration configuration, IPostRepository repository)
        {
            _connectionString = configuration["ConnectionStrings:DB"];
            _repository = repository;
        }

       public async Task OnGetAsync()
        {
            Posts = await _repository.GetAllPostsBeforeApprovalAsync();
        }
       public async Task<IActionResult> OnPostAsync(int id, int iddel)
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
    }
}
