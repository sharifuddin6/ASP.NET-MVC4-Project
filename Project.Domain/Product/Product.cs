namespace Project.Domain.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public string Abstract { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }

        public int MatchCount { get; set; }
    }
}
