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
        public int QueryTotalResults()
        {
            using (var context = new EntityContainer())
            {
                return context.pProducts.Count();
            }
        }

        public int QueryTotalResults(string query, Search.SearchMethod method)
        {
            using (var context = new EntityContainer())
            {
                switch (method)
                {
                    case Search.SearchMethod.BruteForceTitle:
                        return context.pProducts.Count(product => product.Title.Contains(query));
                    case Search.SearchMethod.BruteForceAll:
                        return context.pProducts.Count(product =>
                               product.Title.Contains(query) || product.Author.Contains(query) ||
                               product.Abstract.Contains(query) || product.Content.Contains(query));
                    default:
                        throw new ArgumentOutOfRangeException(nameof(method), method, null);
                }
            }
        }

        public IEnumerable<Product> QueryProducts(int page = 1)
        {
            using (var context = new EntityContainer())
            {
                var productsPerPage = 3;
                return Enumerable.Cast<Product>(context.pProducts.Select(product => new Product()
                {
                    Id = product.ProductId,
                    Title = product.Title,
                    Author = product.Author,
                    Abstract = product.Abstract,
                    Content = product.Content,
                    Thumbnail = product.Thumbnail
                }))
                .Skip(productsPerPage * (page-1))
                .Take(productsPerPage)
                .ToList();
            }
        }

        public IEnumerable<Product> QueryProducts(string query, Search.SearchMethod method, Search.SortBy sort, int page)
        {
            if (string.IsNullOrEmpty(query))
            {
                return QueryProducts(page);
            }

            var products = QueryByMethod(query, method);

            switch (sort)
            {
                case Search.SortBy.Relevance:
                    return SortyByRelevance(products, page);
                case Search.SortBy.Newest:
                case Search.SortBy.Oldest:
                default:
                    return SortyByRelevance(products, page);
            }
        }

        private IEnumerable<Product> SortyByRelevance(IEnumerable<Product> products, int page)
        {
            var productsPerPage = 3;
            return products.OrderByDescending(c => c.MatchCount)
                           .Skip(productsPerPage * (page - 1))
                           .Take(productsPerPage);
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
                    return QueryProducts();
            }
        }

        public Product GetProduct(int productId)
        {
            using (var context = new EntityContainer())
            {
                var product = context.pProducts.Single(p => p.ProductId == productId);
                return new Product
                {
                    Id = product.ProductId, Title = product.Title, Author = product.Author, Abstract = product.Abstract, Content = product.Content, Thumbnail = product.Thumbnail
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
                var productList = Enumerable.Cast<Product>(context.pProducts.Where(product => product.Title.Contains(query) ||
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

                UpdateProductMatchCount(query, productList, true);

                return productList;
            }
        }

        private static void UpdateProductMatchCount(string query, IEnumerable<Product> productList, bool allContent)
        {
            foreach (var product in productList)
            {
                var content = !allContent ? product.Title : product.Title + product.Author + product.Abstract + product.Content;
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
