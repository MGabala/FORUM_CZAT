namespace FORUM_CZAT.Entities
{
    public class HiddenWikiEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string WWW { get; set; }
        public bool IsVerified { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }

    }
}
