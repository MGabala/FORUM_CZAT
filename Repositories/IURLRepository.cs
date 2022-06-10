namespace FORUM_CZAT.Repositories
{
    public interface IURLRepository
    {
        public Task<IEnumerable<HiddenWikiEntity>> GetAllVerifiedUrls();
        public Task<IEnumerable<HiddenWikiEntity>> GetAllUnverifiedUrls();
        public Task AddURL(string url, bool isverified, string description, DateTime creationtime);
        public Task CheckURL(HiddenWikiEntity hiddenWikiEntity);
    }
}
