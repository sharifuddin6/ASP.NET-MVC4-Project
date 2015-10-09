using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using Project.Domain.Repositories;
using Project.Infrastructure.Repositories.Entities;
using EntityContainer = Project.Infrastructure.Repositories.Entities.EntityContainer;

namespace Project.Infrastructure.Repositories
{
    public class CollectionRepository : ICollectionRepository
    {
        public IEnumerable<int> GetAllItemsId()
        {
            using (var context = new EntityContainer())
            {
                return context.Legoes
                              .Select(r => r.Id)
                              .ToList();
            }
        }

        public IEnumerable<string> GetAllItemsName()
        {
            using (var context = new EntityContainer())
            {
                return context.Legoes
                              .Select(r => r.Name)
                              .ToList();
            }
        }

        public void AddItem(string code, string name)
        {
            using (var context = new EntityContainer())
            {
                Lego itemCollection = new Lego()
                {
                    Code = code,
                    Name = name
                };
                context.Legoes.Add(itemCollection);
                context.SaveChanges();
            }
        }
    }
}
