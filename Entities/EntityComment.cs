namespace FORUM_CZAT.Entities
{
    public class EntityComment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CommentDescription { get; set; } = string.Empty;
        public string CommentAuthor { get; set; } = string.Empty;
        [ForeignKey("PostId")]
        public AfterApprovalPost? AfterApprovalPost { get; set; }
        public int PostId { get; set; }
      
    }
}
