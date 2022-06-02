

namespace FORUM_CZAT.Db
{
    public class ForumContext : DbContext
    {
        public DbSet<ModelPost> PostsBeforeApproval { get; set; } = null!;
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {

        }

    }
}
