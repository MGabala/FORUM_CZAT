namespace FORUM_CZAT.Repositories
{
    public class URLRepository : IURLRepository
    {
        private ForumContext _context;
        public URLRepository(ForumContext context)
        {
            _context = context;
        }
        public Task<HiddenWiki> GetAllVerifiedUrls()
        {
            throw new NotImplementedException();
        }
    }
}
