namespace FORUM_CZAT.Repositories
{
    public class GalleryRepository : IGalleryRepository
    {
        private ForumContext _context;
        public GalleryRepository(ForumContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Gallery>> GetAllUnverifiedMedia()
        {
            return await _context.Gallery.OrderBy(x=>x.Id).Where(x=>x.IsVerified==false).ToListAsync();
        }

        public async Task<IEnumerable<Gallery>> GetAllVerifiedMedia()
        {
            return await _context.Gallery.OrderBy(x => x.Id).Where(x => x.IsVerified == true).ToListAsync();
        }
    }
}
