using System.Collections.Generic;

namespace Project.Domain.Repositories
{
    public interface IProductRepository
    {
        Product GetProduct(int id);

        IEnumerable<Product> GetAllProducts();
    }
}
