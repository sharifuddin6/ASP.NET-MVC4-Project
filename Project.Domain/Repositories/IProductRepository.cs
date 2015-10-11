using System.Collections.Generic;

namespace Project.Domain.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<IProduct> GetAllProducts();

        void AddNewProduct(IProduct product);

        void RemoveProduct(int id);
    }
}
