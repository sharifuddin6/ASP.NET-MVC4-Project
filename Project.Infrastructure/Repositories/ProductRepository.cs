using System;
using System.Collections.Generic;
using System.Linq;
using Project.Domain;
using Project.Domain.Repositories;

namespace Project.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private IEnumerable<Product> products; 

        public ProductRepository()
        {
            products = GenerateProducts();
        }

        private static IEnumerable<Product> GenerateProducts()
        {
            return new List<Product>
            {
                new Product()
                {
                    Id = 0,
                    Name = "Shampoo",
                    Stock = 50,
                    DateAdded = DateTime.Now
                },
                new Product()
                {
                    Id = 1,
                    Name = "Conditioner",
                    Stock = 50,
                    DateAdded = DateTime.Now
                },
                new Product()
                {
                    Id = 2,
                    Name = "Gel",
                    Stock = 50,
                    DateAdded = DateTime.Now
                },
                new Product()
                {
                    Id = 3,
                    Name = "Razor",
                    Stock = 50,
                    DateAdded = DateTime.Now
                }
            };
        }

        public Product GetProduct(int id)
        {
            var product = products.Single(p => p.Id == id);
            return new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Stock = product.Stock,
                DateAdded = product.DateAdded
            };
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }
    }
}
