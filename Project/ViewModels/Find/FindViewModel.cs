using System.Collections.Generic;
using Project.Domain.Find;

namespace Project.ViewModels.Find
{
    public class FindViewModel
    {
        public IEnumerable<Domain.Product.Product> Products { get; set; }

        public Search.SearchMethod Method { get; set; }

        public Search.SortBy Sort { get; set; }

        public string Query { get; set; }

        public int Page { get; set; }

        public int TotalResult { get; set; }
    }
}
