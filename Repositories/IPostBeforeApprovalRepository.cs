

namespace FORUM_CZAT.Repositories
{
    public interface IPostBeforeApprovalRepository
    {
        public Task<IEnumerable<ModelPost>> GetAllPostsBeforeApprovalAsync();
    }
}
