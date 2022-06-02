namespace FORUM_CZAT.Repositories
{
    public class PostBeforeApprovalRepository : IPostBeforeApprovalRepository
    {
        private Context _context;
        public PostBeforeApprovalRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ModelPost>> GetAllPostsBeforeApprovalAsync()
        {
            return await _context.PostsBeforeApproval.OrderBy(x => x.Id).ToListAsync();
        }
    }
}
