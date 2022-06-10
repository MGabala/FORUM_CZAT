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
            return await _context.Urls.OrderBy(x => x.Id).Where(x=>x.IsVerified==true).ToListAsync();
        }
        public async Task<IEnumerable<HiddenWikiEntity>> GetAllUnverifiedUrls()
        {
            return await _context.Urls.OrderBy(x => x.Id).Where(x => x.IsVerified == false).ToListAsync();
        }

        public async Task AddURL(string url, bool isverified, string description, DateTime creationtime)
        {
            _context.Urls.Add(new HiddenWikiEntity
            {
                WWW = url,
                IsVerified = isverified,
                Description = description,
                CreationTime = creationtime,
            });
            _context.SaveChanges();
        }

        public async Task CheckURL(HiddenWikiEntity hiddenWikiEntity)
        {
            var urlforapprove =  _context.Urls.SingleOrDefault(x => x.Id == hiddenWikiEntity.Id);
            urlforapprove.IsVerified = true;
            await _context.SaveChangesAsync();
        }
    }
}
