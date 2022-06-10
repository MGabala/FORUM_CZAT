namespace FORUM_CZAT.Repositories
{
    public class URLRepository : IURLRepository
    {
        private ForumContext _context;
        public URLRepository(ForumContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<HiddenWikiEntity>> GetAllVerifiedUrls()
        {
            return await _context.Urls.OrderBy(x => x.Id).ToListAsync();
        }
    }
}
