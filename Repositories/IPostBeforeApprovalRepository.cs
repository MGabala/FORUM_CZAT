namespace FORUM_CZAT.Repositories
{
    public interface IPostBeforeApprovalRepository
    {
        public Task<IEnumerable<BeforeApprovalPost>> GetAllPostsBeforeApprovalAsync();
    }
}
