

namespace FORUM_CZAT.Db
{
    public class ForumContext : DbContext
    {
        public DbSet<AfterApprovalPost> PostsAfterApproval { get; set; } = null!;
        public DbSet<BeforeApprovalPost> PostsBeforeApproval { get; set; } = null!;
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {

        }

    }
}
