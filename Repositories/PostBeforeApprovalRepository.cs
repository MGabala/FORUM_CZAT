namespace FORUM_CZAT.Repositories
{
    public class PostBeforeApprovalRepository : IPostBeforeApprovalRepository
    {
        private ForumContext _context;
        public PostBeforeApprovalRepository(ForumContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BeforeApprovalPost>> GetAllPostsBeforeApprovalAsync()
        {
            return await _context.PostsBeforeApproval.OrderBy(x => x.Id).ToListAsync();
        }
    }
}
