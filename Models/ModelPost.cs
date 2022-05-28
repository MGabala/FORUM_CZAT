namespace FORUM_CZAT.Models
{
    public class ModelPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
