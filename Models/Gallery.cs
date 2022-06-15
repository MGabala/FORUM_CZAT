namespace FORUM_CZAT.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        [NotMapped]
        public IFormFile Upload { get; set; }
        public string ImageFileName { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsVerified { get; set; }
    }
}
