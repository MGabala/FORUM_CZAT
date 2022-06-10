namespace FORUM_CZAT.Repositories
{
    public interface IURLRepository
    {
        public Task<HiddenWiki> GetAllVerifiedUrls();
    }
}
