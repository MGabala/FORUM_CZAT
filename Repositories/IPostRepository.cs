namespace FORUM_CZAT.Repositories
{
    public interface IPostRepository
    {
        public Task AddPost(string title, string description, string author, string category,bool isverified,DateTime creationtime);
        public Task AddComent(int postid, string description, string author, DateTime creationtime);
        public Task<IEnumerable<Post>> GetAllUnverifiedPosts();
        public Task<IEnumerable<Post>> GetAllVerifiedPosts();
        public Task<IEnumerable<Post>> GetLast5Posts();
        public Task CheckPost(Post post);
        public Task DeletePost(int id);
        public Task AddCategory(string category, bool isverified);
        public Task<IEnumerable<Categories>> GetAllUnverifiedCategories();
        public Task CheckCategory(Categories category);
        public Task DeleteCategory(int id);
    }
}
