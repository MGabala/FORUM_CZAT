namespace FORUM_CZAT.Repositories
{
    public interface IPostRepository
    {
        public Task<IEnumerable<BeforeApprovalPost>> GetAllPostsBeforeApprovalAsync();
        public Task<IEnumerable<AfterApprovalPost>> GetAllPostsAfterApprovalForAstronomyAsync();
    }
}
