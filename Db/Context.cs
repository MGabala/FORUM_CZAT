

namespace FORUM_CZAT.Db
{
    public class Context : DbContext
    {
        public DbSet<EntityPost> Posts { get; set; } = null!;
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

    }
}
