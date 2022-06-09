namespace FORUM_CZAT.Repositories
{
    public interface IPostRepository
    {
        public Task<IEnumerable<BeforeApprovalPost>> GetAllPostsBeforeApprovalAsync();
        public Task<IEnumerable<AfterApprovalPost>> GetAllPostsAfterApprovalLast5Async();
        public Task AddPost(string title, string description, string author, string category,DateTime creationtime);
        public Task AddComent(int postid, string description, string author, DateTime creationtime);
    }
}
