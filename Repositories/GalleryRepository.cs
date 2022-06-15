namespace FORUM_CZAT.Repositories
{
    public class GalleryRepository : IGalleryRepository
    {
        private ForumContext _context;
        private IWebHostEnvironment _environment;
        public GalleryRepository(ForumContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task AddMedia(Gallery gallery)
        {
            gallery.ImageFileName = Guid.NewGuid().ToString()+Path.GetExtension(gallery.Upload.FileName);
            //gallery.ImageFileName = gallery.Upload.FileName;
          var file = Path.Combine(_environment.ContentRootPath, "wwwroot/gallery", gallery.ImageFileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await gallery.Upload.CopyToAsync(fileStream);
            }
            gallery.CreationTime = DateTime.Now;
            await _context.Gallery.AddAsync(gallery);
            await _context.SaveChangesAsync();
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
