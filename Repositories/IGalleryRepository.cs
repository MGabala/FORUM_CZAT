namespace FORUM_CZAT.Repositories
{
    public interface IGalleryRepository
    {
        public Task<IEnumerable<Gallery>> GetAllUnverifiedMedia();
        public Task<IEnumerable<Gallery>> GetAllVerifiedMedia();
    }
}
