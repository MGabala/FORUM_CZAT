namespace FORUM_CZAT.Entities
{
    public class GalleryEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [NotMapped]
        public IFormFile Upload { get; set; }
        public string ImageFileName { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
