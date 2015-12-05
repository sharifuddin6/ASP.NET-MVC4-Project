namespace Project.Domain.Find
{
    public class Search
    {
        public enum SearchMethod
        {
            BruteForceTitle = 0,
            BruteForceAll = 1,
            Example2 = 2,
            Example3 = 3
        }

        public string Query { get; set; }
        
        public SearchMethod Method { get; set;}
    }
}
