using System.Collections.Generic;
using System.Linq;
using Project.Domain.Model;
using Project.Domain.Repositories;
using Project.Infrastructure.Model;
using Project.Infrastructure.Repositories.Entities;

namespace Project.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<IProduct> GetAllProducts()
        {
            using (var context = new EntityContainer())
            {
                return Enumerable.Cast<IProduct>(context.pProducts.Select(product => new Product()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Code = product.Code,
                    Value = (float) (product.Value ?? 0)
                })).ToList();
            }
        }

        public void AddNewProduct(IProduct product)
        {
            using (var context = new EntityContainer())
            {
                var pProduct = new pProduct()
                {
                    Name = product.Name,
                    Code = product.Code,
                    Value = product.Value
                };
                context.pProducts.Add(pProduct);
                context.SaveChanges();
            }
        }

        public void RemoveProduct(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
