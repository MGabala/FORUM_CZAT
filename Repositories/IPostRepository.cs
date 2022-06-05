﻿namespace FORUM_CZAT.Repositories
{
    public interface IPostRepository
    {
        public Task<IEnumerable<BeforeApprovalPost>> GetAllPostsBeforeApprovalAsync();
        public Task<IEnumerable<AfterApprovalPost>> GetAllPostsAfterApprovalForAstronomyAsync();
        public Task<IEnumerable<AfterApprovalPost>> GetAllPostsAfterApprovalLast5Async();
        public Task<IEnumerable<AfterApprovalPost>> GetAllPostsAfterApprovalForCryptoCurrenciesAsync();
        public Task<IEnumerable<AfterApprovalPost>> GetAllPostsAfterApprovalForProgrammingAsync();
        public Task<IEnumerable<AfterApprovalPost>> GetAllPostsAfterApprovalForScienceAsync();
        
        public void AddPost(string title, string description, string author, string category,DateTime creationtime);
    }
}
