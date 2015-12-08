using System.Collections.Generic;
using Project.Domain.Find;

namespace Project.Domain.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product.Product> GetAllProducts();

        IEnumerable<Product.Product> QueryProducts(string query, Search.SearchMethod method, Search.SortBy sort);

        Product.Product GetProduct(string productId);
    }
}
