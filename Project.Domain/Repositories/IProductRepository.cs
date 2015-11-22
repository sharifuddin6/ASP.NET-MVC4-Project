using System;
using System.Collections.Generic;

namespace Project.Domain.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product.Product> GetAllProducts();

        Product.Product GetProduct(String productId);
    }
}
