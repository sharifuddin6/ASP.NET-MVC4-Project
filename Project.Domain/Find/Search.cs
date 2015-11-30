using System.ComponentModel.DataAnnotations;

namespace Project.Domain.Find
{
    public class Search
    {
        public string Query { get; set; }

        public enum SearchMethod
        {
            BruteForce = 0,
            Example1 = 1,
            Example2 = 2,
            Example3 = 3
        }

        [Required(ErrorMessage = "Select one item")]
        public SearchMethod Selection { get; set;}
    }
}
