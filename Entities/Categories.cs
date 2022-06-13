namespace FORUM_CZAT.Entities
{
    public class Categories
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Category { get; set; }
    }
}
