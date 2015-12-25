using System.Collections.Generic;
using Project.Domain.Find;

namespace Project.Domain.Repositories
{
    public interface IProductRepository
    {
        int QueryTotalResults();

        int QueryTotalResults(string query, Search.SearchMethod method);

        IEnumerable<Product.Product> QueryProducts(int page = 1);

        IEnumerable<Product.Product> QueryProducts(string query, Search.SearchMethod method, Search.SortBy sort, int page);

        Product.Product GetProduct(int productId);
    }
}
