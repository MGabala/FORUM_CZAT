namespace FORUM_CZAT.Repositories
{
    public class PostRepository : IPostRepository
    {
        private ForumContext _context;
        public PostRepository(ForumContext context)
        {
            _context = context;
        }
        public async Task AddPost(string title, string description, string author, string category,bool isverified, DateTime creationtime)
        {
            await _context.Posts.AddAsync(new Post
            {
                Title = title,
                Description = description,
                Author = author,
                Category = category,
                IsVerified = isverified,
                CreationTime = creationtime
            });
           await _context.SaveChangesAsync();
        }


        public async Task AddComent(int postid,string description, string author, DateTime creationtime)
        {
            await _context.Comments.AddAsync(new Comment
            {
                PostId = postid,
                CommentDescription = description,
                CommentAuthor = author,
                CreationTime = creationtime
                
            });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Post>> GetAllUnverifiedPosts()
        {
            return await _context.Posts.OrderByDescending(x => x.Id).Where(x => x.IsVerified == false).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetLast5Posts()
        {
            return await _context.Posts.OrderByDescending(x => x.Id).Where(x => x.IsVerified == true).Take(5).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetAllVerifiedPosts()
        {
            return await _context.Posts.OrderByDescending(x => x.Id).Where(x => x.IsVerified == true).ToListAsync();
        }
#pragma warning disable CS8602
        public async Task CheckPost(Post post)
        {
            var postforapprove = _context.Posts.SingleOrDefault(x => x.Id == post.Id);
            postforapprove.IsVerified = true;
            await _context.SaveChangesAsync();
        }
        public async Task CheckCategory(Categories category)
        {
            var categoryforapprove = _context.Categories.SingleOrDefault(x => x.Id == category.Id);
            categoryforapprove.IsVerified = true;
            await _context.SaveChangesAsync();
        }
#pragma warning restore CS8602
#pragma warning disable CS8634

        public async Task DeletePost(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(post);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCategory(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }
#pragma warning restore CS8634
        public async Task AddCategory(string category, bool isverified)
        {
            await _context.Categories.AddAsync(new Categories
            {
                Category = category,
                IsVerified = isverified
            });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Categories>> GetAllUnverifiedCategories()
        {
            return await _context.Categories.OrderByDescending(x => x.Id).Where(x => x.IsVerified == false).ToListAsync();

        }
    }
}
