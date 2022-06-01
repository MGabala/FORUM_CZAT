

namespace FORUM_CZAT.Entities
{
    public class EntityPost
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime CreationTime { get; set; }

    }
}
