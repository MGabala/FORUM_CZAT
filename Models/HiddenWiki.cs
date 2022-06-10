namespace FORUM_CZAT.Models
{
    public class HiddenWiki
    {
        public int Id { get; set; }
        public string WWW { get; set; } = null!;
        public bool IsVerified { get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreationTime { get; set; }

    }
}
