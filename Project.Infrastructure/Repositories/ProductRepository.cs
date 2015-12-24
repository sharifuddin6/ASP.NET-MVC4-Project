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

        public IEnumerable<Product> QueryProducts(string query, Search.SearchMethod method, Search.SortBy sort)
        {
            var products = QueryByMethod(query, method);

            switch (sort)
            {
                case Search.SortBy.Relevance:
                    return SortyByRelevance(products);
                case Search.SortBy.Newest:
                case Search.SortBy.Oldest:
                default:
                    return SortyByRelevance(products);
            }
        }

        private IEnumerable<Product> SortyByRelevance(IEnumerable<Product> products)
        {
            return products.OrderByDescending(c => c.MatchCount);
        }

        private IEnumerable<Product> QueryByMethod(string query, Search.SearchMethod method)
        {
            switch (method)
            {
                case Search.SearchMethod.BruteForceTitle:
                    return BruteForceTitle(query);
                case Search.SearchMethod.BruteForceAll:
                    return BruteForceAll(query);
                default:
                    return GetAllProducts();
            }
        }

        public Product GetProduct(string productId)
        {
            using (var context = new EntityContainer())
            {
                int prodId;
                if (!int.TryParse(productId, out prodId)) throw new Exception("Error: Product id is not in correct format");

                var product = context.pProducts.Single(p => p.ProductId == prodId);
                return new Product
                {
                    Id = product.ProductId,
                    Title = product.Title,
                    Author = product.Author,
                    Abstract = product.Abstract,
                    Content = product.Content,
                    Thumbnail = product.Thumbnail
                };
            }
        }

        private IEnumerable<Product> BruteForceTitle(string query)
        {
            using (var context = new EntityContainer())
            {
                var productList = Enumerable.Cast<Product>(context.pProducts.Where(product => product.Title.Contains(query)).Select(product => new Product()
                {
                    Id = product.ProductId, Title = product.Title, Author = product.Author, Abstract = product.Abstract, Content = product.Content, Thumbnail = product.Thumbnail
                })).ToList();

                UpdateProductMatchCount(query, productList, false);

                return productList;
            }
        }

        private IEnumerable<Product> BruteForceAll(string query)
        {
            using (var context = new EntityContainer())
            {
                var productList = Enumerable.Cast<Product>(context.pProducts.Where(product => product.Title.Contains(query) || product.Author.Contains(query) || product.Abstract.Contains(query) || product.Content.Contains(query)).Select(product => new Product()
                {
                    Id = product.ProductId, Title = product.Title, Author = product.Author, Abstract = product.Abstract, Content = product.Content, Thumbnail = product.Thumbnail
                })).ToList();

                UpdateProductMatchCount(query, productList, true);

                return productList;
            }
        }

        private static void UpdateProductMatchCount(string query, IEnumerable<Product> productList, bool allContent)
        {
            foreach (var product in productList)
            {
                var content = !allContent ? product.Title :
                    product.Title + product.Author + product.Abstract + product.Content;
                product.MatchCount = CountMatchedCharacters(content, query);
            }
        }

        private static int CountMatchedCharacters(string content, string query)
        {
            var count = 0;
            for (var i = 0; i <= content.Length - query.Length; i++)
            {
                var substring = content.Substring(i, query.Length);
                if (string.Equals(substring, query, StringComparison.CurrentCultureIgnoreCase))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
