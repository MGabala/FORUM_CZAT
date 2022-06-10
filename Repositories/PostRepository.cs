﻿namespace FORUM_CZAT.Repositories
{
    public class PostRepository : IPostRepository
    {
        private ForumContext _context;
        public PostRepository(ForumContext context)
        {
            _context = context;
        }
        public async Task AddPost(string title, string description, string author, string category, DateTime creationtime)
        {
            await _context.PostsBeforeApproval.AddAsync(new BeforeApprovalPost
            {
                Title = title,
                Description = description,
                Author = author,
                Category = category,
                CreationTime = creationtime
            });
           await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<BeforeApprovalPost>> GetAllPostsBeforeApprovalAsync()
        {
            return await _context.PostsBeforeApproval.OrderBy(x => x.Id).ToListAsync();
        }
        public async Task<IEnumerable<AfterApprovalPost>> GetAllPostsAfterApprovalLast5Async()
        {
            return await _context.PostsAfterApproval.OrderByDescending(x => x.CreationTime).Take(5).ToListAsync();
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
    }
}
