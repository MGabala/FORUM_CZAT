

namespace FORUM_CZAT.Db
{
    public class Context : DbContext
    {
        public DbSet<ModelPost> PostsBeforeApproval { get; set; } = null!;
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

    }
}
