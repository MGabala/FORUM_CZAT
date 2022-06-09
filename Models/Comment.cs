﻿namespace FORUM_CZAT.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentDescription { get; set; } = string.Empty;
        public string CommentAuthor { get; set; }= string.Empty;
        public int PostId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
