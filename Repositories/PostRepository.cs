namespace FORUM_CZAT.Repositories
{
    public class PostRepository : IPostRepository
    {
        private ForumContext _context;
        public PostRepository(ForumContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BeforeApprovalPost>> GetAllPostsBeforeApprovalAsync()
        {
            return await _context.PostsBeforeApproval.OrderBy(x => x.Id).ToListAsync();
        }
        public async Task<IEnumerable<AfterApprovalPost>> GetAllPostsAfterApprovalForAstronomyAsync()
        {
            return await _context.PostsAfterApproval.OrderBy(x => x.Id).Where(x=>x.Category == "Astronomy").ToListAsync();
        }
    }
}
