using System.Collections.Generic;

namespace Project.Domain.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product.Product> GetAllProducts();

        void AddNewProduct(Product.Product product);

        void RemoveProduct(int id);
    }
}
