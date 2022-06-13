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
           await _context.Urls.AddAsync(new HiddenWikiEntity
            {
                WWW = url,
                IsVerified = isverified,
                Description = description,
                CreationTime = creationtime,
            });
           await _context.SaveChangesAsync();
        }
#pragma warning disable CS8602
        public async Task CheckURL(HiddenWikiEntity hiddenWikiEntity)
        {
            var urlforapprove =  _context.Urls.SingleOrDefault(x => x.Id == hiddenWikiEntity.Id);
            urlforapprove.IsVerified = true;
            await _context.SaveChangesAsync();
        }
#pragma warning restore CS8602
        public async Task DeleteUrl(int id)
        {
            var url = await _context.Urls.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(url);
            await _context.SaveChangesAsync();
        }
    }
}
