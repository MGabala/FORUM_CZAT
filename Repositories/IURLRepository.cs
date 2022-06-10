namespace FORUM_CZAT.Repositories
{
    public interface IURLRepository
    {
        public Task<IEnumerable<HiddenWikiEntity>> GetAllVerifiedUrls();
    }
}
