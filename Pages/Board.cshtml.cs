using FORUM_CZAT.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace FORUM_CZAT.Pages.Categories
{
    public class AstronomyModel : PageModel
    {
        private IPostRepository _repository;
        private readonly string _connectionString = string.Empty;
        public IEnumerable<AfterApprovalPost> AfterApprovalPost { get; set; }

        public AstronomyModel(IConfiguration configuration, IPostRepository repository)
        {
            _connectionString = configuration["ConnectionStrings:DB"];
            _repository = repository;
        }
        public async Task OnGetAsync()
        {
            AfterApprovalPost = await _repository.GetAllPostsAfterApprovalForAstronomyAsync();
        }
        public async Task<IActionResult> OnPostAsync(string title, string description,string category, string author)
        {
            if(category=="Select category")
            {
                return RedirectToPage("/Error");
            }
            else
            {
                _repository.AddPost(title, description, author, category, DateTime.Now);
            }
            //string category = "Astronomy";
           
    //        //var query = $"INSERT INTO [PostsBeforeApproval] (Title, Description, Author, Category, CreationTime) VALUES ('{title}','{description}','{author}','{category}','{DateTime.Now}')";

    //        using (var con = new SqliteConnection(_connectionString))
    //        using (var cmd = new SqliteCommand())
    //        {
    //            cmd.CommandText =
    //@"
    //INSERT INTO [PostsBeforeApproval] 
    //(Title, Description, Author, Category, CreationTime) 
    //VALUES 
    //($title, $description, $author, $category, $creationtime)
    //";
    //            cmd.Parameters.AddWithValue("$title", title);
    //            cmd.Parameters.AddWithValue("$description", description);
    //            cmd.Parameters.AddWithValue("$author", author);
    //            cmd.Parameters.AddWithValue("$category", category);
    //            cmd.Parameters.AddWithValue("$creationtime", DateTime.Now.ToString());


    //            cmd.Connection = con;
    //            con.Open();
    //           // cmd.CommandText = query;
    //            cmd.ExecuteNonQuery();
    //        }
            return RedirectToPage("/AfterPostInformation");
        }
    }
}