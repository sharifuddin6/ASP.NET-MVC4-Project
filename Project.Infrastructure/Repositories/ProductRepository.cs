using System.Collections.Generic;
using System.Linq;
using Project.Domain.Product;
using Project.Domain.Repositories;
using Project.Infrastructure.Repositories.Entities;

namespace Project.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAllProducts()
        {
            using (var context = new EntityContainer())
            {
                return Enumerable.Cast<Product>(context.pProducts.Select(product => new Product()
                {
                    Id = product.ProductId,
                    Title = product.Title,
                    Author = product.Author,
                    Abstract = product.Abstract,
                    Content = product.Content,
                    Thumbnail = product.Thumbnail
                })).ToList();
            }
        }

        public Product GetProduct(int productId)
        {
            var products = GetAllProducts();
            return products.Single(e => e.Id == productId);
        }

    }
}
