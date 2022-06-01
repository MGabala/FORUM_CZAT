namespace FORUM_CZAT.Entities
{
    public class EntityNewPost
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Astronomy { get; set; }
        public string CryptoCurrencies { get; set; }
        public string Life { get; set; }
        public string Mathematic { get; set; }
        public string Programming { get; set; }
        public string Psychology { get; set; }
        public string Reading { get; set; }
        public string Religion { get; set; }
        public string Science { get; set; }
        public string SciFi { get; set; }
    }
}
