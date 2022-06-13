namespace FORUM_CZAT.Entities
{
    public class Categories
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Category { get; set; } = null!;
        public bool IsVerified { get; set; } = false;
    }
}
