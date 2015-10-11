using System.Collections.Generic;
using Project.Domain.Model;

namespace Project.Domain.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<IProduct> GetAllProducts();

        void AddNewProduct(IProduct product);

        void RemoveProduct(int id);
    }
}
