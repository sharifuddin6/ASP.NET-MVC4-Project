using System;
using System.Collections.Generic;
using System.Linq;
using Project.Domain.Find;
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

        public IEnumerable<Product> QueryProducts(string query, Search.SearchMethod selection)
        {
            if (selection == Search.SearchMethod.BruteForceTitle)
            {
                return BruteForceTitle(query);
            }
            if (selection == Search.SearchMethod.BruteForceAll)
            {
                return BruteForceAll(query);
            }
            return GetAllProducts();
        }

        public Product GetProduct(string productId)
        {
            var products = GetAllProducts();
            return products.Single(e => e.Id == Convert.ToInt32(productId));
        }

        private IEnumerable<Product> BruteForceTitle(string query)
        {
            using (var context = new EntityContainer())
            {
                return Enumerable.Cast<Product>(context.pProducts.Where(product => product.Title.Contains(query))
                                                                 .Select(product => new Product()
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

        private IEnumerable<Product> BruteForceAll(string query)
        {
            using (var context = new EntityContainer())
            {
                return Enumerable.Cast<Product>(context.pProducts.Where(product => product.Title.Contains(query) ||
                                                                                   product.Author.Contains(query) ||
                                                                                   product.Abstract.Contains(query) ||
                                                                                   product.Content.Contains(query))
                                                                 .Select(product => new Product()
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
    }
}
