

namespace FORUM_CZAT.Db
{
    public class ForumContext : DbContext
    {
        public DbSet<Post> Posts{ get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<HiddenWikiEntity> Urls { get; set; } = null!;
        public DbSet<Categories> Categories { get; set; } = null!;
        public DbSet<Gallery> Gallery { get; set; } = null!;
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {

        }

    }
}
