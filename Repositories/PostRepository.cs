namespace FORUM_CZAT.Repositories
{
    public class PostRepository : IPostRepository
    {
        private ForumContext _context;
        public PostRepository(ForumContext context)
        {
            _context = context;
        }
        public void AddPost(string title, string description, string author, string category, DateTime creationtime)
        {
            _context.PostsBeforeApproval.Add(new BeforeApprovalPost
            {
                Title = title,
                Description = description,
                Author = author,
                Category = category,
                CreationTime = creationtime
            });
            _context.SaveChanges();
        }
        public async Task<IEnumerable<BeforeApprovalPost>> GetAllPostsBeforeApprovalAsync()
        {
            return await _context.PostsBeforeApproval.OrderBy(x => x.Id).ToListAsync();
        }
        public async Task<IEnumerable<AfterApprovalPost>> GetAllPostsAfterApprovalLast5Async()
        {
            return await _context.PostsAfterApproval.OrderByDescending(x => x.CreationTime).Take(5).ToListAsync();

        }
        public async Task<IEnumerable<AfterApprovalPost>> GetAllPostsAfterApprovalForAstronomyAsync()
        {
            return await _context.PostsAfterApproval.OrderBy(x => x.Id).Where(x=>x.Category == "Astronomy").ToListAsync();
        }
        public async Task<IEnumerable<AfterApprovalPost>> GetAllPostsAfterApprovalForCryptoCurrenciesAsync()
        {
            return await _context.PostsAfterApproval.OrderBy(x => x.Id).Where(x => x.Category == "CryptoCurrencies").ToListAsync();
        }
        public async Task<IEnumerable<AfterApprovalPost>> GetAllPostsAfterApprovalForProgrammingAsync()
        {
            return await _context.PostsAfterApproval.OrderBy(x => x.Id).Where(x => x.Category == "Programming").ToListAsync();
        }
        public async Task<IEnumerable<AfterApprovalPost>> GetAllPostsAfterApprovalForScienceAsync()
        {
            return await _context.PostsAfterApproval.OrderBy(x => x.Id).Where(x => x.Category == "Science").ToListAsync();

        }



    }
}
