using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace FORUM_CZAT.Pages.Categories
{
    public class AstronomyModel : PageModel
    {
        private readonly string _connectionString = string.Empty;
        public AstronomyModel(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DB"];
        }
        public async Task OnGetAsync()
        {
        }
        public async Task<IActionResult> OnPostAsync(string title, string description, string author)
        {
            string category = "Astronomy";
            var query = $"INSERT INTO [Posts] (Title, Description, Author, Category, CreationTime) VALUES ('{title}','{description}','{author}','{category}','{DateTime.Now}')";
            using (var con = new SqliteConnection(_connectionString))
            using (var cmd = new SqliteCommand())
            {
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            return RedirectToPage("/AfterPostInformation");
        }
    }
}
 