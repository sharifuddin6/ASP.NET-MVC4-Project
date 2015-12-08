namespace Project.Domain.Find
{
    public class Search
    {
        public enum SearchMethod
        {
            BruteForceTitle = 0,
            BruteForceAll = 1
        }

        public enum SortBy
        {
            Relevance = 0,
            Newest = 1,
            Oldest = 2
        };
    }
}
