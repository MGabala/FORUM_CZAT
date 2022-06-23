namespace FORUM_CZAT.Entities
{
    public class EntityComment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CommentDescription { get; set; } = string.Empty;
        public string CommentAuthor { get; set; } = string.Empty;
        public int PostId { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CreationTime { get; set; }

    }
}
