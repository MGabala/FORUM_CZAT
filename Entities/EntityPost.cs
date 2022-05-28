

namespace FORUM_CZAT.Entities
{
    public class EntityPost
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }
        
    }
}
